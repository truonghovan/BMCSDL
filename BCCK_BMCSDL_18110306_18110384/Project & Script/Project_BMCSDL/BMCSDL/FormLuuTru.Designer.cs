namespace BMCSDL
{
    partial class FormLuuTru
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
            this.buttonGuiTT = new System.Windows.Forms.Button();
            this.dataGridViewPassPort = new System.Windows.Forms.DataGridView();
            this.textBoxHoten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTenNV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPassPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mã hồ sơ";
            // 
            // buttonGuiTT
            // 
            this.buttonGuiTT.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonGuiTT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGuiTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuiTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuiTT.Location = new System.Drawing.Point(433, 98);
            this.buttonGuiTT.Name = "buttonGuiTT";
            this.buttonGuiTT.Size = new System.Drawing.Size(171, 36);
            this.buttonGuiTT.TabIndex = 20;
            this.buttonGuiTT.Text = "Gửi thông báo";
            this.buttonGuiTT.UseVisualStyleBackColor = false;
            this.buttonGuiTT.Click += new System.EventHandler(this.buttonGuiTT_Click);
            // 
            // dataGridViewPassPort
            // 
            this.dataGridViewPassPort.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPassPort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPassPort.Location = new System.Drawing.Point(12, 160);
            this.dataGridViewPassPort.Name = "dataGridViewPassPort";
            this.dataGridViewPassPort.RowHeadersWidth = 51;
            this.dataGridViewPassPort.RowTemplate.Height = 24;
            this.dataGridViewPassPort.Size = new System.Drawing.Size(736, 472);
            this.dataGridViewPassPort.TabIndex = 19;
            this.dataGridViewPassPort.Click += new System.EventHandler(this.dataGridViewPassPort_Click);
            // 
            // textBoxHoten
            // 
            this.textBoxHoten.Location = new System.Drawing.Point(175, 98);
            this.textBoxHoten.Multiline = true;
            this.textBoxHoten.Name = "textBoxHoten";
            this.textBoxHoten.Size = new System.Drawing.Size(219, 35);
            this.textBoxHoten.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 36);
            this.label2.TabIndex = 30;
            this.label2.Text = "BỘ PHẬN LƯU TRỮ";
            // 
            // labelTenNV
            // 
            this.labelTenNV.AutoSize = true;
            this.labelTenNV.Location = new System.Drawing.Point(575, 18);
            this.labelTenNV.Name = "labelTenNV";
            this.labelTenNV.Size = new System.Drawing.Size(152, 16);
            this.labelTenNV.TabIndex = 31;
            this.labelTenNV.Text = "Xin chào Hồ Văn Trường";
            this.labelTenNV.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormLuuTru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 644);
            this.Controls.Add(this.labelTenNV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxHoten);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGuiTT);
            this.Controls.Add(this.dataGridViewPassPort);
            this.Name = "FormLuuTru";
            this.Text = "FormLuuTru";
            this.Load += new System.EventHandler(this.FormLuuTru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPassPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGuiTT;
        private System.Windows.Forms.DataGridView dataGridViewPassPort;
        private System.Windows.Forms.TextBox textBoxHoten;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTenNV;
    }
}