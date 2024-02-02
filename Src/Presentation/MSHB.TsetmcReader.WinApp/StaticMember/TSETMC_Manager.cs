using MSHB.TsetmcReader.DTO.DataModel;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.WinApp.StaticMember
{
    public delegate void DataReay();

    public static class TSETMC_Manager
    {
        private static Timer getData_timer;
        private static ConcurrentDictionary<string, decimal> _instrumentIds = new ConcurrentDictionary<string, decimal>();
        public static ConcurrentDictionary<string, decimal> InstrumentIds { get; private set; }
        public static DataReay DataReadyEvent;
        private static bool isBusy = false;
        private static object lockObject = new object();
        public static void Start()
        { }
        static TSETMC_Manager()
        {
            getData_timer = new Timer(GetDataFromTSETMC, null, 100, 4000);
        }
        private static void OnDataReadyEvent()
        {
            if (DataReadyEvent == null)
                return;
            try
            {
                DataReadyEvent.Invoke();
            }
            catch(Exception ex)
            {

            }
        }
        private static async void GetDataFromTSETMC(object state)
        {
            if(isBusy) return;
            isBusy = true;
            #region Instrument Data
            try
            {
                var options = new RestClientOptions("https://old.tsetmc.com/tsev2/data/MarketWatchInit.aspx?h=0&r=0");
                var request = new RestRequest();

                var client = new RestClient(options);
                var response = await client.GetAsync(request);
                string responseMessage = response.Content;
                _instrumentIds.Clear();
                await GetMainInsDataFromTSETMC();

                var logs = responseMessage.Trim().Split(';').Select(x => x.Trim()).ToArray();
                if (logs != null && logs.Length > 0)
                {

                    Parallel.ForEach(logs, item =>
                    //       foreach (var item in logs)
                    {
                        var data = item.Replace("'", "").Trim().Split(',').Select(x => x.Trim()).ToArray();
                        int dataLength = data.Length;
                        if (dataLength > 20)
                        {
                            try
                            {
                                if (!decimal.TryParse(data[6], out decimal quantity))
                                { quantity = 0; }
                                if (!_instrumentIds.TryAdd(data[0], quantity))
                                    _instrumentIds.TryAdd(data[0], quantity);
                            }
                            catch { }

                        }
                    });
                }
                lock(lockObject)
                {
                    InstrumentIds = new ConcurrentDictionary<string, decimal>( _instrumentIds);
                }
                OnDataReadyEvent();
            }
            catch {
            }
            finally { isBusy = false; }
            #endregion

        }
        private static async Task GetMainInsDataFromTSETMC()
        {
            try
            {
                for (int i = 1; i < 3; i++)
                {
                    var client = new HttpClient();
                    string result =
                        await client.GetStringAsync($"https://cdn.tsetmc.com/api/MarketData/GetMarketOverview/{i}");
                    RootMarket marketOverview = JsonSerializer.Deserialize<RootMarket>(result);
                    if (!_instrumentIds.TryAdd($"{i}", (decimal)marketOverview.marketOverview.indexLastValue))
                        _instrumentIds.TryAdd($"{i}", (decimal)marketOverview.marketOverview.indexLastValue);
                }
            }
            catch (Exception ex)
            {
                //      MessageBox.Show(ex.Message);
            }

        }
    }
}
