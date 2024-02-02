using System;
using System.Linq;
using System.Windows.Forms;

namespace MSHB.TsetmcReader.WinApp.Practical_Forms
{
    public partial class frmCoins : Form
    {
        

        public frmCoins()
        {
            InitializeComponent();
        }

        private void frmCoins_Load(object sender, EventArgs e)
        {
            FillGrid();

        }

        private void FillGrid()
        {
            dataGridView1.Rows.Clear();
            var coinNames = CoinManager._coins.Keys.ToList();
            for(int i = 0; i < CoinManager._coins.Count; i++)
            {
                int rowID = dataGridView1.Rows.Add();
                dataGridView1["Coin", rowID].Value = GetPersianName(coinNames[i]);               
                dataGridView1["Refah0312", rowID].Value = CoinManager.GetDiffPrice( "Refah0312", coinNames[i]);
                dataGridView1["Saman0412",rowID].Value= CoinManager.GetDiffPrice("Saman0412", coinNames[i]);
                dataGridView1["Mellat0211",rowID].Value= CoinManager.GetDiffPrice("Mellat0211", coinNames[i]); 
                dataGridView1["Saderat0310", rowID].Value= CoinManager.GetDiffPrice("Saderat0310", coinNames[i]);
                dataGridView1["Ayandeh0411",rowID].Value= CoinManager.GetDiffPrice("Ayandeh0411", coinNames[i]);
                dataGridView1.Rows[rowID].Height = 120;
            }
            dataGridView1.ScrollBars = ScrollBars.Both;
        }

        private string GetPersianName(string v)
        {
            switch (v)
            {
                case "Refah0312":
                    return "رفاه ۰۳۱۲";
                case "Saman0412":
                    return "سامان ۰۴۱۲";
                case "Mellat0211":
                    return "ملت ۰۲۱۱";
                case "Ayandeh0411":
                    return "آینده ۰۴۱۱";
                case "Saderat0310":
                    return "صادرات ۰۳۱۰";
            }
            return v;
        }
    }
}
