namespace BMCSDL
{
    partial class FormThongTinPassPort
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
            this.dataGridViewPP = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPP)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPP
            // 
            this.dataGridViewPP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPP.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPP.Name = "dataGridViewPP";
            this.dataGridViewPP.RowHeadersWidth = 51;
            this.dataGridViewPP.RowTemplate.Height = 24;
            this.dataGridViewPP.Size = new System.Drawing.Size(1258, 498);
            this.dataGridViewPP.TabIndex = 0;
            // 
            // FormThongTinPassPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 522);
            this.Controls.Add(this.dataGridViewPP);
            this.Name = "FormThongTinPassPort";
            this.Text = "FormThongTinPassPort";
            this.Load += new System.EventHandler(this.FormThongTinPassPort_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewPP;
    }
}