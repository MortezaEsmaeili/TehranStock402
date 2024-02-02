namespace MSHB.TsetmcReader.WinApp.Practical_Forms
{
    partial class frmCoins
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Coin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mellat0211 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saderat0310 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ayandeh0411 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saman0412 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Refah0312 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Coin,
            this.Mellat0211,
            this.Saderat0310,
            this.Ayandeh0411,
            this.Saman0412,
            this.Refah0312});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(613, 520);
            this.dataGridView1.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(989, 520);
            this.splitContainer1.SplitterDistance = 613;
            this.splitContainer1.TabIndex = 5;
            // 
            // Coin
            // 
            this.Coin.DataPropertyName = "Coin";
            this.Coin.HeaderText = "نام سکه";
            this.Coin.MinimumWidth = 6;
            this.Coin.Name = "Coin";
            this.Coin.ReadOnly = true;
            this.Coin.Width = 75;
            // 
            // Mellat0211
            // 
            this.Mellat0211.DataPropertyName = "Mellat0211";
            this.Mellat0211.HeaderText = "ملت۰۲۱۱ ";
            this.Mellat0211.MinimumWidth = 6;
            this.Mellat0211.Name = "Mellat0211";
            this.Mellat0211.ReadOnly = true;
            this.Mellat0211.Width = 85;
            // 
            // Saderat0310
            // 
            this.Saderat0310.DataPropertyName = "Saderat0310";
            this.Saderat0310.HeaderText = "صادرات ۰۳۱۰";
            this.Saderat0310.MinimumWidth = 6;
            this.Saderat0310.Name = "Saderat0310";
            this.Saderat0310.ReadOnly = true;
            this.Saderat0310.Width = 105;
            // 
            // Ayandeh0411
            // 
            this.Ayandeh0411.DataPropertyName = "Ayandeh0411";
            this.Ayandeh0411.HeaderText = "آینده ۰۴۱۱";
            this.Ayandeh0411.MinimumWidth = 6;
            this.Ayandeh0411.Name = "Ayandeh0411";
            this.Ayandeh0411.ReadOnly = true;
            this.Ayandeh0411.Width = 91;
            // 
            // Saman0412
            // 
            this.Saman0412.DataPropertyName = "Saman0412";
            this.Saman0412.HeaderText = "سامان ۰۴۱۲";
            this.Saman0412.MinimumWidth = 6;
            this.Saman0412.Name = "Saman0412";
            this.Saman0412.ReadOnly = true;
            this.Saman0412.Width = 99;
            // 
            // Refah0312
            // 
            this.Refah0312.DataPropertyName = "Refah0312";
            this.Refah0312.HeaderText = "رفاه۰۳۱۲";
            this.Refah0312.MinimumWidth = 6;
            this.Refah0312.Name = "Refah0312";
            this.Refah0312.ReadOnly = true;
            this.Refah0312.Width = 87;
            // 
            // frmCoins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 520);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCoins";
            this.Text = "frmCoins";
            this.Load += new System.EventHandler(this.frmCoins_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mellat0211;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saderat0310;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ayandeh0411;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saman0412;
        private System.Windows.Forms.DataGridViewTextBoxColumn Refah0312;
    }
}