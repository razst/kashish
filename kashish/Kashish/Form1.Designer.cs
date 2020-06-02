namespace Kashish
{
    partial class Form1
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
            this.timeTableView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.movieTxb = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.hourTxb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UrlTxb = new System.Windows.Forms.TextBox();
            this.DeskTxb = new System.Windows.Forms.TextBox();
            this.DeskT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // timeTableView
            // 
            this.timeTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timeTableView.Location = new System.Drawing.Point(12, 26);
            this.timeTableView.Name = "timeTableView";
            this.timeTableView.Size = new System.Drawing.Size(342, 150);
            this.timeTableView.TabIndex = 0;
            this.timeTableView.DoubleClick += new System.EventHandler(this.timeTableView_DoubleClick);
            // 
            // movieTxb
            // 
            this.movieTxb.Location = new System.Drawing.Point(503, 76);
            this.movieTxb.Name = "movieTxb";
            this.movieTxb.Size = new System.Drawing.Size(100, 20);
            this.movieTxb.TabIndex = 1;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(403, 168);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = ":שם סרט";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = ":יום";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(361, 329);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 8;
            this.okBtn.Text = "אישור";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // hourTxb
            // 
            this.hourTxb.Location = new System.Drawing.Point(567, 212);
            this.hourTxb.Name = "hourTxb";
            this.hourTxb.Size = new System.Drawing.Size(36, 20);
            this.hourTxb.TabIndex = 2;
            this.hourTxb.Text = "13:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(633, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = ":שעה";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = ":קישור";
            // 
            // UrlTxb
            // 
            this.UrlTxb.Location = new System.Drawing.Point(503, 38);
            this.UrlTxb.Name = "UrlTxb";
            this.UrlTxb.Size = new System.Drawing.Size(100, 20);
            this.UrlTxb.TabIndex = 10;
            // 
            // DeskTxb
            // 
            this.DeskTxb.Location = new System.Drawing.Point(503, 121);
            this.DeskTxb.Name = "DeskTxb";
            this.DeskTxb.Size = new System.Drawing.Size(100, 20);
            this.DeskTxb.TabIndex = 11;
            // 
            // DeskT
            // 
            this.DeskT.AutoSize = true;
            this.DeskT.Location = new System.Drawing.Point(633, 128);
            this.DeskT.Name = "DeskT";
            this.DeskT.Size = new System.Drawing.Size(41, 13);
            this.DeskT.TabIndex = 12;
            this.DeskT.Text = ":תיאור";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeskT);
            this.Controls.Add(this.DeskTxb);
            this.Controls.Add(this.UrlTxb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hourTxb);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.movieTxb);
            this.Controls.Add(this.timeTableView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeTableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView timeTableView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox movieTxb;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TextBox hourTxb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UrlTxb;
        private System.Windows.Forms.TextBox DeskTxb;
        private System.Windows.Forms.Label DeskT;
    }
}

