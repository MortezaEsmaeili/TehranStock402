using MSHB.TsetmcReader.WinApp.StaticMember;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Windows.Forms;

namespace MSHB.TsetmcReader.WinApp.Practical_Forms
{
    public partial class frmCoins : Form
    {

        //public const string RefahCoin = "Refah0312";
        //public const string SamanCoin = "Saman0412";
        //public const string MellatCoin = "Mellat0211";
        //public const string SaderatCoin = "Saderat0310";
        //public const string AyandehCoin = "Ayandeh0411";

        public const string RefahCoin   = "16255851958781000";
        public const string SamanCoin   = "31447590411939048";
        public const string MellatCoin  = "1626855364269097";
        public const string SaderatCoin = "71448561759885455";
        public const string AyandehCoin = "62180931969029505";


        public static ConcurrentDictionary<string, decimal> _coins = new ConcurrentDictionary<string, decimal>();

        public frmCoins()
        {
            _coins.TryAdd(MellatCoin, 0);
            _coins.TryAdd(SaderatCoin, 0);
            _coins.TryAdd(SamanCoin, 0);
            _coins.TryAdd(AyandehCoin, 0);
            _coins.TryAdd(RefahCoin, 0);

            InitializeComponent();
        }

        private void frmCoins_Load(object sender, EventArgs e)
        {
            FillGrid();
            TSETMC_Manager.DataReadyEvent += OnDataDeady;
        }
        private void OnDataDeady()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { FillGrid(); }));
            }
            else
                FillGrid();
        }
        private void UpdateCoinPrices()
        {
            if (TSETMC_Manager.InstrumentIds == null || TSETMC_Manager.InstrumentIds.Count == 0)
                return;
            foreach(var key in _coins.Keys)
            {
                if(TSETMC_Manager.InstrumentIds.ContainsKey(key))
                    _coins[key] = TSETMC_Manager.InstrumentIds[key];
            }
        }
        private void FillGrid()
        {
            try
            {
                UpdateCoinPrices();
                dataGridView1.Rows.Clear();
                var coinInsIds = _coins.Keys.ToList();
                for (int i = 0; i < _coins.Count; i++)
                {
                    int rowID = dataGridView1.Rows.Add();
                    dataGridView1["Coin", rowID].Value = GetPersianName(coinInsIds[i]);
                    dataGridView1["Refah0312", rowID].Value = GetDiffPrice(RefahCoin, coinInsIds[i]);
                    dataGridView1["Saman0412", rowID].Value = GetDiffPrice(SamanCoin, coinInsIds[i]);
                    dataGridView1["Mellat0211", rowID].Value = GetDiffPrice(MellatCoin, coinInsIds[i]);
                    dataGridView1["Saderat0310", rowID].Value = GetDiffPrice(SaderatCoin, coinInsIds[i]);
                    dataGridView1["Ayandeh0411", rowID].Value = GetDiffPrice(AyandehCoin, coinInsIds[i]);
                    dataGridView1.Rows[rowID].Height = 120;
                }
                dataGridView1.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {

            }
        }

        public decimal GetDiffPrice(string coin1, string coin2)
        {
            return _coins[coin1] - _coins[coin2];
        }

        private string GetPersianName(string v)
        {
            switch (v)
            {
                case RefahCoin:
                    return "رفاه ۰۳۱۲";
                case SamanCoin:
                    return "سامان ۰۴۱۲";
                case MellatCoin:
                    return "ملت ۰۲۱۱";
                case AyandehCoin:
                    return "آینده ۰۴۱۱";
                case SaderatCoin:
                    return "صادرات ۰۳۱۰";
            }
            return v;
        }
    }
}
