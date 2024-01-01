using MSHB.TsetmcReader.WinApp.General_Forms;
using MSHB.TsetmcReader.WinApp.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSHB.TsetmcReader.WinApp
{
    public partial class frmMain : Form
    {
        private List<Form> OpenWindows = new List<Form>();
        public frmMain()
        {
            InitializeComponent();
        }

        private void tmClock_Tick(object sender, EventArgs e)
        {
            tsmTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the program?", "Exit!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private  void tsmOpenBrowser_Click(object sender, EventArgs e)
        {
        }

        private void notifyIconManage_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            notifyIconManage.Visible = false;
            this.ShowInTaskbar = true;
        }

        private void cascateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var form in OpenWindows)
                form.Close();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadExcelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmType1Excel frmType1 = new frmType1Excel(true);
            frmType1.MdiParent = this;
            OpenWindows.Add(frmType1);
            frmType1.Show();
        }

        private void loadFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmType1Excel frmType1 = new frmType1Excel(false);
            frmType1.MdiParent = this;
            OpenWindows.Add(frmType1);
            frmType1.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmType1Excel frmType1 = new frmType1Excel(true);
            frmType1.MdiParent = this;
            OpenWindows.Add(frmType1);
            frmType1.Show();
        }

        private void aboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog();
        }
    }
}
