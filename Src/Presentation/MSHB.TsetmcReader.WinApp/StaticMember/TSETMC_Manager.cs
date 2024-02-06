using CoinDTO;
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
        private static List<String> coinList = new List<String>();
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
            coinList.Add("16255851958781005");
            coinList.Add("31447590411939048");
            coinList.Add("1626855364269097");
            coinList.Add("71448561759885455");
            coinList.Add("62180931969029505");
            
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
                await GetCoinInformation();

                var logs = responseMessage.Trim().Split(';').Select(x => x.Trim()).ToArray();
                if (logs != null && logs.Length > 0)
                {

                    Parallel.ForEach(logs, item =>
                    //       foreach (var item in logs)
                    {
                        var data = item.Replace("'", "").Trim().Split(',').Select(x => x.Trim()).ToArray();
                        int dataLength = data.Length;
                        if (dataLength > 7 && dataLength<10)
                        {
                            if (data[0] == "16255851958781000")
                            {
                                int x = 0;
                                x ++;
                            }
                            try
                            {
                                if (!decimal.TryParse(data[5], out decimal quantity))
                                { quantity = 0; }
                                if (!_instrumentIds.TryAdd(data[0], quantity))
                                    _instrumentIds.TryAdd(data[0], quantity);
                            }
                            catch { }

                        }
                    });
                }
                #region CoinData
                foreach (var goldCoin in coinList)
                {
                    using (var client1 = new HttpClient())
                    {
                        string url = $"https://cdn.tsetmc.com/api/ClosingPrice/GetClosingPriceInfo/{goldCoin}";
                        string result =
                            await client1.GetStringAsync(url);
                        Root root = JsonSerializer.Deserialize<Root>(result);
                        if(root != null)
                        {
                            _instrumentIds.TryRemove(goldCoin, out _);
                            _instrumentIds.TryAdd(goldCoin, root.closingPriceInfo.pDrCotVal);
                        }
                    }
                }
                #endregion
                lock (lockObject)
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

        private static async Task GetCoinInformation()
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
