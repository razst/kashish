namespace Kashish
{
    partial class Form2
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
            this.DeskT = new System.Windows.Forms.Label();
            this.DeskTxb = new System.Windows.Forms.TextBox();
            this.UrlTxb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hourTxb = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.movieTxb = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.urlBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeskT
            // 
            this.DeskT.AutoSize = true;
            this.DeskT.Location = new System.Drawing.Point(265, 138);
            this.DeskT.Name = "DeskT";
            this.DeskT.Size = new System.Drawing.Size(41, 13);
            this.DeskT.TabIndex = 22;
            this.DeskT.Text = ":תיאור";
            // 
            // DeskTxb
            // 
            this.DeskTxb.Location = new System.Drawing.Point(135, 131);
            this.DeskTxb.Name = "DeskTxb";
            this.DeskTxb.Size = new System.Drawing.Size(100, 20);
            this.DeskTxb.TabIndex = 21;
            // 
            // UrlTxb
            // 
            this.UrlTxb.Location = new System.Drawing.Point(135, 48);
            this.UrlTxb.Name = "UrlTxb";
            this.UrlTxb.Size = new System.Drawing.Size(100, 20);
            this.UrlTxb.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = ":קישור";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = ":שעה";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = ":יום";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = ":שם סרט";
            // 
            // hourTxb
            // 
            this.hourTxb.Location = new System.Drawing.Point(199, 222);
            this.hourTxb.Name = "hourTxb";
            this.hourTxb.Size = new System.Drawing.Size(36, 20);
            this.hourTxb.TabIndex = 14;
            this.hourTxb.Text = "13:00";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(35, 178);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 15;
            // 
            // movieTxb
            // 
            this.movieTxb.Location = new System.Drawing.Point(135, 86);
            this.movieTxb.Name = "movieTxb";
            this.movieTxb.Size = new System.Drawing.Size(100, 20);
            this.movieTxb.TabIndex = 13;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(35, 255);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 23;
            this.okBtn.Text = "אישור";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // urlBtn
            // 
            this.urlBtn.Location = new System.Drawing.Point(68, 45);
            this.urlBtn.Name = "urlBtn";
            this.urlBtn.Size = new System.Drawing.Size(42, 23);
            this.urlBtn.TabIndex = 24;
            this.urlBtn.Text = "הצג";
            this.urlBtn.UseVisualStyleBackColor = true;
            this.urlBtn.Click += new System.EventHandler(this.urlBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 290);
            this.Controls.Add(this.urlBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.DeskT);
            this.Controls.Add(this.DeskTxb);
            this.Controls.Add(this.UrlTxb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hourTxb);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.movieTxb);
            this.Name = "Form2";
            this.Text = "עריכת סרט";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DeskT;
        private System.Windows.Forms.TextBox DeskTxb;
        private System.Windows.Forms.TextBox UrlTxb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hourTxb;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox movieTxb;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button urlBtn;
    }
}