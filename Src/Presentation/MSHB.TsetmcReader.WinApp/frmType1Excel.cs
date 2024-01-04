using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Helper;
using MSHB.TsetmcReader.WinApp.Helper;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;


namespace MSHB.TsetmcReader.WinApp
{
    public partial class frmType1Excel : Form
    {
        public Dictionary<string, InstrumentStockData> StockData = new Dictionary<string, InstrumentStockData>();
        public Dictionary<string, MA_Data> StockMA_Data=new Dictionary<string, MA_Data>();
        public bool loadExcel { get; set; }
        private ConcurrentDictionary<string, decimal> _instrumentIds = new ConcurrentDictionary<string, decimal>();

        private int iAlarmPercentage = 5;

        public frmType1Excel(bool _loadExcel)
        {
            loadExcel = _loadExcel;

            InitializeComponent();
        }

        private void frmType1Excel_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //          GetFilesPath();
            timer1 = new Timer();
            timer1.Interval = 4000;
            timer1.Tick += GetDataFromTSETMC;
            timer1.Start();
        }

        private async void GetDataFromTSETMC(object sender, EventArgs e)
        {
            timer1.Stop();
            #region Instrument Data
            var options = new RestClientOptions("https://old.tsetmc.com/tsev2/data/MarketWatchInit.aspx?h=0&r=0");
            var request = new RestRequest();

            var client = new RestClient(options);
            var response = await client.GetAsync(request);
            string responseMessage = response.Content;
            _instrumentIds.Clear();
            await GetMainInsDataFromTSETMC();
            try
            {
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
            }
            catch { }
            #endregion

            FillDataGrid();
            timer1.Start();
        }
        private async Task GetMainInsDataFromTSETMC()
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
            catch(Exception ex)
            {
          //      MessageBox.Show(ex.Message);
            }

        }
        private void GetFilesPath()
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            string path = ConfigReaderHelper.GetExcelFolderPath();
            folderBrowserDialog1.SelectedPath = ConfigReaderHelper.GetExcelFolderPath();

            var result = folderBrowserDialog1.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            timer1.Stop();
            var waitForm = new frmPleaseWait();
            waitForm.Show(this);
            try
            {
                string selectedFolder = folderBrowserDialog1.SelectedPath;
                foreach (var file in Directory.GetFiles(selectedFolder))
                    loadFromExcel(file);
                ConfigReaderHelper.SetExcelFolderPath(selectedFolder);

                CalculateMA();
                FillDataGrid();
            }
            catch (Exception ex) { ex.ToString(); }
            waitForm.Close();
            timer1.Start();

        }
        void CalculateMA()
        {
            StockMA_Data = new Dictionary<string, MA_Data>();

            foreach (var insData in StockData)
            {
                try
                {
                    MA_Data ma = GetMA( insData.Value);
                    StockMA_Data.Add(insData.Key, ma);
                }
                catch { }
            }

        }

        private static MA_Data GetMA( InstrumentStockData insStockData)
        {
            var insData = insStockData.PricePEList;
            var ma= new MA_Data()
            {
                PE = insData[0].PE,
                PE100 = (insData.Where(x => x.PE > 0).Take(100).Sum(x => x.PE)) / 100,
                Price100 = (insData.Where(x => x.Price > 0).Take(100).Sum(x => x.Price)) / 100,
                Earning100 = (insData.Where(x => x.Earning > 0).Take(100).Sum(x => x.Earning)) / 100,
                PE500 = (insData.Where(x => x.PE > 0).Take(500).Sum(x => x.PE)) / 500,
                Price500 = (insData.Where(x => x.Price > 0).Take(500).Sum(x => x.Price)) / 500,
                Earning500 = (insData.Where(x => x.Earning > 0).Take(500).Sum(x => x.Earning)) / 500             
            };
            if (insStockData.Support > 0)
                ma.Support = (insStockData.Support > ma.Price500) ? ma.Price500 : insStockData.Support;
            else 
                ma.Support = ma.Price500;
            if(ma.Resistance > 0)
                ma.Resistance = (insStockData.Resistance < ma.Price500) ? ma.Price500 : insStockData.Resistance;
            else
                ma.Resistance = ma.Price500;
            return ma;
        }
        
        private void Load_Supp_Res_FromExcel(string filePath)
        {
            var dataTable = ExelReader.ReadExcelFileDOM(filePath);
            if (dataTable == null)
            {
                //         MessageBox.Show("Please close the Excel file or Excel file is empty!");
                return;
            }
            int counter = 0;
            foreach (var row in dataTable.ToArray())
            {
                if (counter < 8 || row == null || row[1] == null)
                {
                    counter++;
                    continue;
                }
                try
                {
                    string key = row[4].ToString();
                    decimal.TryParse(row[2], out decimal support);
                    decimal.TryParse(row[3], out decimal resistance);
                    if (StockData.ContainsKey(key))
                    {
                        StockData[key].Resistance = resistance;
                        StockData[key].Support = support;
                    }
                    else
                    {
                        StockData.Add(key, new InstrumentStockData { Resistance = resistance, Support=support });
                    }
                    UpdateResistanceSupport(key, support, resistance);
                }
                catch { }
            }
        }

        private void UpdateResistanceSupport(string key, decimal support, decimal resistance)
        {
            if (StockMA_Data.ContainsKey(key))
            {
                if (resistance < 1)
                    resistance = StockMA_Data[key].Price500;
                if (support < 1)
                    support = StockMA_Data[key].Price500;

                StockMA_Data[key].Resistance = resistance;
                StockMA_Data[key].Support= support;

                if (StockData.ContainsKey(key))
                {
                    StockData[key].Resistance = resistance;
                    StockData[key].Support = support;
                }
            }
        }

        private void loadFromExcel(string filePath, string insCode = null)
        {
            var dataTable = ExelReader.ReadExcelFileDOM(filePath);
            if (dataTable == null)
            {
                //         MessageBox.Show("Please close the Excel file or Excel file is empty!");
                return;
            }
            if (string.IsNullOrEmpty(insCode))
            {
                FileInfo info = new FileInfo(filePath);
                insCode = info.Name.Split('.')[0];
            }
            else
                insCode = insCode.Trim();
            if (StockData.ContainsKey(insCode) == true)
                StockData.Remove(insCode);
            StockData.Add(insCode, new InstrumentStockData());

            int counter = 0;

            foreach (var row in dataTable.ToArray())
            {
                if (counter < 8 || row == null || row[1] == null)
                {
                    counter++;
                    continue;
                }
                try
                {
                    if (decimal.TryParse(row[6], out decimal price) &&
                        decimal.TryParse(row[15], out decimal pe))
                    {
                        var price_pe = new Price_PE()
                        {
                            PE = pe,
                            Price = price,
                            Earning = pe > 0 ? (price / pe) : -1
                        };
                        StockData[insCode].PricePEList.Add(price_pe);
                    }
                }
                catch { }
                if (StockData[insCode].PricePEList.Count > 600)
                    break;
            }
            decimal lastValidEaring = 0;
            var pricePEList = StockData[insCode].PricePEList;
            for (int k = pricePEList.Count - 1; k >= 0; k--)
            {
                if (pricePEList[k].Earning == -1)
                    pricePEList[k].Earning = lastValidEaring;
                else
                    lastValidEaring = pricePEList[k].Earning;
            }
        }

        private void FillDataGrid()
        {
            if (Freez_CHB.Checked)
                return;
            try
            {
                dg_InsData.AutoGenerateColumns = false;
                dg_InsData.Rows.Clear();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Rows.Clear();
                StockMA_Data.ToList().ForEach(x =>
                {
                    string insCode = x.Key.Split('_')[1];
                    string insName = x.Key.Split('_')[0];
                    try
                    {
                        if (insCode == "1" || insCode == "2")
                            AddDataToGridView1(insCode, insName, x.Value);
                        else
                            AddDataToGrid(insCode, insName, x.Value);
                    }
                    catch(Exception ex)
                    {
                        ex.ToString();
                    }
                });
                
                dataGridView1.ScrollBars = ScrollBars.Both;
                dg_InsData.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void AddDataToGrid( string insCode, string insName,  MA_Data x)
        {
            int dgrow = dg_InsData.Rows.Add();
            dg_InsData["InsCode", dgrow].Value = insCode;
            dg_InsData["InsName", dgrow].Value = insName;
            dg_InsData["PE", dgrow].Value = Math.Round(x.PE, 2);
            dg_InsData["Price100", dgrow].Value = Math.Round(x.Price100, 2);
            dg_InsData["PE100", dgrow].Value = Math.Round(x.PE100, 2);
            dg_InsData["Earning100", dgrow].Value = Math.Round(x.Earning100, 2);
            dg_InsData["Price500", dgrow].Value = Math.Round(x.Price500, 2);
            dg_InsData["PE500", dgrow].Value = Math.Round(x.PE500, 2);
            dg_InsData["Earning500", dgrow].Value = Math.Round(x.Earning500, 2);
            dg_InsData["Support", dgrow].Value = Math.Round(x.Support,2);
            dg_InsData["Resistance", dgrow].Value = Math.Round(x.Resistance,2);
            if (_instrumentIds.ContainsKey(insCode))
            {
                decimal price = 0;
                if (_instrumentIds.TryGetValue(insCode, out price))
                {
                    if (price > 1)
                    {
                        dg_InsData["Price", dgrow].Value = price;
                        decimal earning = x.PE > 0 ? price / x.PE : -1;
                        dg_InsData["Earning", dgrow].Value = Math.Round(earning, 2);
                        dg_InsData["Price_Price100", dgrow].Value =
                            Math.Round((((price - x.Price100) / price) * 100), 2);
                        dg_InsData["Price_Price500", dgrow].Value =
                            Math.Round(((price - x.Price500) / price) * 100, 2);
                        dg_InsData["PE_PE100", dgrow].Value =
                            Math.Round(((x.PE - x.PE100) / x.PE) * 100, 2);
                        dg_InsData["PE_PE500", dgrow].Value =
                            Math.Round(((x.PE - x.PE500) / x.PE) * 100, 2);
                        decimal Price_Support = Math.Round(((price - x.Support) / price) * 100, 2);
                        dg_InsData["Price_Support", dgrow].Value = Price_Support;
                        decimal Price_Resistance = Math.Round(((x.Resistance - price) / price) * 100, 2);
                        dg_InsData["Price_Resistance", dgrow].Value = Price_Resistance;

                        if (Math.Abs(Price_Resistance) < iAlarmPercentage)
                            Add2Alarm($"{insName}-{price}");
                        if (Math.Abs(Price_Support) < iAlarmPercentage)
                            Add2Alarm($"{insName}-{price}");
                    }
                }
            }
        }

        private void Add2Alarm(string alarm)
        {
            while(listBox1.Items.Count > 100)
                listBox1.Items.RemoveAt(listBox1.Items.Count-1);

            if (!listBox1.Items.Contains(alarm))
            {
                listBox1.Items.Insert(0, alarm);
                SendSMS(alarm);
            }
        }

        private void SendSMS(string alarm)
        {
            
        }

        private void AddDataToGridView1(string insCode, string insName, MA_Data x)
        {
            int dgrow = dataGridView1.Rows.Add();
            dataGridView1["InsCode1", dgrow].Value = insCode;
            dataGridView1["InsName1", dgrow].Value = insName;
            dataGridView1["PE1", dgrow].Value = Math.Round(x.PE, 2);
            dataGridView1["Price1001", dgrow].Value = Math.Round(x.Price100, 6);
            dataGridView1["PE1001", dgrow].Value = Math.Round(x.PE100, 2);
            dataGridView1["Earning1001", dgrow].Value = Math.Round(x.Earning100, 2);
            dataGridView1["Price5001", dgrow].Value = Math.Round(x.Price500, 6);
            dataGridView1["PE5001", dgrow].Value = Math.Round(x.PE500, 2);
            dataGridView1["Earning5001", dgrow].Value = Math.Round(x.Earning500, 2);
            if (_instrumentIds.ContainsKey(insCode))
            {
                decimal price = 0;
                if (_instrumentIds.TryGetValue(insCode, out price))
                {
                    if (price > 1)
                    {
                        dataGridView1["Price1", dgrow].Value = price;
                        decimal earning = x.PE > 0 ? price / x.PE : -1;
                        dataGridView1["Earning1", dgrow].Value = Math.Round(earning, 2);
                        dataGridView1["Price_Price1001", dgrow].Value =
                            Math.Round((((price - x.Price100) / price) * 100), 2);
                        dataGridView1["Price_Price5001", dgrow].Value =
                            Math.Round(((price - x.Price500) / price) * 100, 2);
                        dataGridView1["PE_PE1001", dgrow].Value =
                            Math.Round(((x.PE - x.PE100) / x.PE) * 100, 2);
                        dataGridView1["PE_PE5001", dgrow].Value =
                            Math.Round(((x.PE - x.PE500) / x.PE) * 100, 2);
                    }
                }
            }
        }

        private void LocateExcelFile_BT_Click(object sender, EventArgs e)
        {
            GetFilesPath();
        }

        private void LocateMainIndex_BT_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                string insCode = "1";
                string insName = "شاخص کل";
                string key = insName + "_" + insCode;
                loadFromExcel(filePath, key);
                var indexData = StockData.FirstOrDefault(x => x.Key == key);
                if (indexData.Key==key)
                {
                    try
                    {
                        MA_Data ma = GetMA(indexData.Value);
                        StockMA_Data[key]=ma;
                        AddDataToGridView1(insCode, insName, ma);
                    }
                    catch { }
                }
            }

        }

        private void LocateSupRes_BT_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                string insCode = "2";
                string insName = "شاخص کل فرا بورس";
                string key = insName + "_" + insCode;
                loadFromExcel(filePath, key);
                var indexData = StockData.FirstOrDefault(x => x.Key == key);
                if (indexData.Key == key)
                {
                    try
                    {
                        MA_Data ma = GetMA(indexData.Value);
                        StockMA_Data[key] = ma;
                        AddDataToGridView1(insCode, insName, ma);
                    }
                    catch { }
                }
            }
        }

        private void LocateSuppResi_BT_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                Load_Supp_Res_FromExcel(filePath);
            }
        }

        private void TB_AlarmPercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                iAlarmPercentage = int.Parse(TB_AlarmPercentage.Text);
            }
            catch
            {
                iAlarmPercentage = 5;
                TB_AlarmPercentage.Text = "5";
            }
        }

        private void BT_ClearList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
