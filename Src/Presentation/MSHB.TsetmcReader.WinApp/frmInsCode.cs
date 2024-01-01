using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSHB.TsetmcReader.WinApp
{
    public partial class frmInsCode : Form
    {
        public string Sembol { get; set; }
        public decimal instrumentID { get; set; }
        public frmInsCode(string _Symbol)
        {
            Sembol = _Symbol;
            InitializeComponent();
        }

        private void OK_BT_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            try
            {
                instrumentID = decimal.Parse(this.InsCode_txt.Text);
            }
            catch(Exception ex)
            {
                ex.ToString();
                MessageBox.Show("InstrumentID is not Correct!");
                return;
            }

            this.Close();
        }

        private void Cancle_bt_Click(object sender, EventArgs e)
        {
            this.DialogResult |= DialogResult.Cancel;
            this.Close();
        }

        private void frmInsCode_Load(object sender, EventArgs e)
        {
            Symbol_txt.Text = Sembol;
        }
    }
}
