
namespace MSHB.TsetmcReader.WinApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpenBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.type1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinsStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmClock = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmServiceChecker = new System.Windows.Forms.Timer(this.components);
            this.openExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBase,
            this.tsmTime,
            this.tsmMinimize,
            this.type1ToolStripMenuItem,
            this.WinsStateToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1139, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmBase
            // 
            this.tsmBase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpenBrowser,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.tsmBase.Name = "tsmBase";
            this.tsmBase.Size = new System.Drawing.Size(46, 24);
            this.tsmBase.Text = "File";
            // 
            // tsmOpenBrowser
            // 
            this.tsmOpenBrowser.Enabled = false;
            this.tsmOpenBrowser.Name = "tsmOpenBrowser";
            this.tsmOpenBrowser.Size = new System.Drawing.Size(195, 26);
            this.tsmOpenBrowser.Text = "Start Reading ...";
            this.tsmOpenBrowser.Click += new System.EventHandler(this.tsmOpenBrowser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // tsmTime
            // 
            this.tsmTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmTime.Name = "tsmTime";
            this.tsmTime.Size = new System.Drawing.Size(107, 24);
            this.tsmTime.Text = "System Time";
            // 
            // tsmMinimize
            // 
            this.tsmMinimize.Name = "tsmMinimize";
            this.tsmMinimize.Size = new System.Drawing.Size(14, 24);
            // 
            // type1ToolStripMenuItem
            // 
            this.type1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeDataBaseToolStripMenuItem,
            this.loadExcelToolStripMenuItem,
            this.loadFormToolStripMenuItem,
            this.historyFormToolStripMenuItem});
            this.type1ToolStripMenuItem.Name = "type1ToolStripMenuItem";
            this.type1ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.type1ToolStripMenuItem.Text = "Type 1";
            // 
            // removeDataBaseToolStripMenuItem
            // 
            this.removeDataBaseToolStripMenuItem.Name = "removeDataBaseToolStripMenuItem";
            this.removeDataBaseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            // 
            // loadExcelToolStripMenuItem
            // 
            this.loadExcelToolStripMenuItem.Name = "loadExcelToolStripMenuItem";
            this.loadExcelToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadExcelToolStripMenuItem.Text = "بورس تهران";
            this.loadExcelToolStripMenuItem.Click += new System.EventHandler(this.loadExcelToolStripMenuItem_Click_1);
            // 
            // loadFormToolStripMenuItem
            // 
            this.loadFormToolStripMenuItem.Name = "loadFormToolStripMenuItem";
            this.loadFormToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadFormToolStripMenuItem.Text = "Live Form";
            this.loadFormToolStripMenuItem.Visible = false;
            this.loadFormToolStripMenuItem.Click += new System.EventHandler(this.loadFormToolStripMenuItem_Click);
            // 
            // historyFormToolStripMenuItem
            // 
            this.historyFormToolStripMenuItem.Name = "historyFormToolStripMenuItem";
            this.historyFormToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            // 
            // WinsStateToolStripMenuItem
            // 
            this.WinsStateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascateToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem,
            this.toolStripSeparator2,
            this.CloseAllToolStripMenuItem});
            this.WinsStateToolStripMenuItem.Name = "WinsStateToolStripMenuItem";
            this.WinsStateToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.WinsStateToolStripMenuItem.Text = "Window";
            // 
            // cascateToolStripMenuItem
            // 
            this.cascateToolStripMenuItem.Name = "cascateToolStripMenuItem";
            this.cascateToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.cascateToolStripMenuItem.Text = "Cascade";
            this.cascateToolStripMenuItem.Click += new System.EventHandler(this.cascateToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.verticalToolStripMenuItem.Text = "TileHorizontal";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.horizontalToolStripMenuItem.Text = "TileVertical";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // CloseAllToolStripMenuItem
            // 
            this.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem";
            this.CloseAllToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.CloseAllToolStripMenuItem.Text = "Close All ...";
            this.CloseAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSoftwareToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutSoftwareToolStripMenuItem
            // 
            this.aboutSoftwareToolStripMenuItem.Name = "aboutSoftwareToolStripMenuItem";
            this.aboutSoftwareToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.aboutSoftwareToolStripMenuItem.Text = "About Software";
            this.aboutSoftwareToolStripMenuItem.Click += new System.EventHandler(this.aboutSoftwareToolStripMenuItem_Click);
            // 
            // tmClock
            // 
            this.tmClock.Enabled = true;
            this.tmClock.Interval = 1000;
            this.tmClock.Tick += new System.EventHandler(this.tmClock_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 618);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(1139, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(59, 20);
            this.lbStatus.Text = "Ready...";
            // 
            // frmMain
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1139, 644);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SabaFam TseTmc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmBase;
        private System.Windows.Forms.ToolStripMenuItem tsmTime;
        private System.Windows.Forms.Timer tmClock;
        private System.Windows.Forms.ToolStripMenuItem tsmMinimize;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenBrowser;
        private System.Windows.Forms.Timer tmServiceChecker;
        private System.Windows.Forms.OpenFileDialog openExcelFileDialog;
        private System.Windows.Forms.ToolStripMenuItem WinsStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CloseAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem type1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeDataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSoftwareToolStripMenuItem;
    }
}

