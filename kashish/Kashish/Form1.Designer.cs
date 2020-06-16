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
            this.openBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // timeTableView
            // 
            this.timeTableView.AllowUserToAddRows = false;
            this.timeTableView.AllowUserToDeleteRows = false;
            this.timeTableView.AllowUserToOrderColumns = true;
            this.timeTableView.AllowUserToResizeColumns = false;
            this.timeTableView.AllowUserToResizeRows = false;
            this.timeTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timeTableView.Location = new System.Drawing.Point(12, 26);
            this.timeTableView.Name = "timeTableView";
            this.timeTableView.Size = new System.Drawing.Size(238, 373);
            this.timeTableView.TabIndex = 0;
            this.timeTableView.DoubleClick += new System.EventHandler(this.timeTableView_DoubleClick);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(27, 415);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 13;
            this.openBtn.Text = "חדש";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 450);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.timeTableView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeTableView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView timeTableView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button openBtn;
    }
}

