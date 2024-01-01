namespace MSHB.TsetmcReader.WinApp
{
    partial class frmInsCode
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
            this.label1 = new System.Windows.Forms.Label();
            this.OK_BT = new System.Windows.Forms.Button();
            this.Symbol_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InsCode_txt = new System.Windows.Forms.TextBox();
            this.Cancle_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Symbole:";
            // 
            // OK_BT
            // 
            this.OK_BT.Location = new System.Drawing.Point(129, 135);
            this.OK_BT.Name = "OK_BT";
            this.OK_BT.Size = new System.Drawing.Size(75, 23);
            this.OK_BT.TabIndex = 1;
            this.OK_BT.Text = "Ok";
            this.OK_BT.UseVisualStyleBackColor = true;
            this.OK_BT.Click += new System.EventHandler(this.OK_BT_Click);
            // 
            // Symbol_txt
            // 
            this.Symbol_txt.Location = new System.Drawing.Point(203, 28);
            this.Symbol_txt.Name = "Symbol_txt";
            this.Symbol_txt.ReadOnly = true;
            this.Symbol_txt.Size = new System.Drawing.Size(132, 22);
            this.Symbol_txt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Instrument ID:";
            // 
            // InsCode_txt
            // 
            this.InsCode_txt.Location = new System.Drawing.Point(129, 79);
            this.InsCode_txt.Name = "InsCode_txt";
            this.InsCode_txt.Size = new System.Drawing.Size(281, 22);
            this.InsCode_txt.TabIndex = 4;
            // 
            // Cancle_bt
            // 
            this.Cancle_bt.Location = new System.Drawing.Point(335, 135);
            this.Cancle_bt.Name = "Cancle_bt";
            this.Cancle_bt.Size = new System.Drawing.Size(75, 23);
            this.Cancle_bt.TabIndex = 5;
            this.Cancle_bt.Text = "Cancel";
            this.Cancle_bt.UseVisualStyleBackColor = true;
            this.Cancle_bt.Click += new System.EventHandler(this.Cancle_bt_Click);
            // 
            // frmInsCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 173);
            this.Controls.Add(this.Cancle_bt);
            this.Controls.Add(this.InsCode_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Symbol_txt);
            this.Controls.Add(this.OK_BT);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInsCode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Instrument";
            this.Load += new System.EventHandler(this.frmInsCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK_BT;
        private System.Windows.Forms.TextBox Symbol_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InsCode_txt;
        private System.Windows.Forms.Button Cancle_bt;
    }
}