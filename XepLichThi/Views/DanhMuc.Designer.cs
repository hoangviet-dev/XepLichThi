
namespace XepLichThi.Views
{
    partial class DanhMuc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lTagLoaiPhongThi = new XepLichThi.Views.Controls.ListTagsCustom();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ltagHinhThucThi = new XepLichThi.Views.Controls.ListTagsCustom();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.lTagLoaiPhongThi);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 255);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 102);
            this.panel4.TabIndex = 2;
            // 
            // lTagLoaiPhongThi
            // 
            this.lTagLoaiPhongThi.AutoSize = true;
            this.lTagLoaiPhongThi.Data = null;
            this.lTagLoaiPhongThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTagLoaiPhongThi.Location = new System.Drawing.Point(0, 0);
            this.lTagLoaiPhongThi.Name = "lTagLoaiPhongThi";
            this.lTagLoaiPhongThi.Size = new System.Drawing.Size(800, 102);
            this.lTagLoaiPhongThi.TabIndex = 0;
            this.lTagLoaiPhongThi.Title = "Loại phòng thi";
            this.lTagLoaiPhongThi.AddAction += new System.EventHandler(this.lTagLoaiPhongThi_AddAction);
            this.lTagLoaiPhongThi.UpdateAction += new System.EventHandler(this.lTagLoaiPhongThi_UpdateAction);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.ltagHinhThucThi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 153);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 102);
            this.panel3.TabIndex = 1;
            // 
            // ltagHinhThucThi
            // 
            this.ltagHinhThucThi.AutoSize = true;
            this.ltagHinhThucThi.Data = null;
            this.ltagHinhThucThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltagHinhThucThi.Location = new System.Drawing.Point(0, 0);
            this.ltagHinhThucThi.Name = "ltagHinhThucThi";
            this.ltagHinhThucThi.Size = new System.Drawing.Size(800, 102);
            this.ltagHinhThucThi.TabIndex = 0;
            this.ltagHinhThucThi.Title = "Hình thức thi";
            this.ltagHinhThucThi.AddAction += new System.EventHandler(this.ltagHinhThucThi_AddAction);
            this.ltagHinhThucThi.UpdateAction += new System.EventHandler(this.ltagHinhThucThi_UpdateAction);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 153);
            this.panel2.TabIndex = 0;
            // 
            // DanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DanhMuc";
            this.Text = "DanhMuc";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Controls.ListTagsCustom ltagHinhThucThi;
        private System.Windows.Forms.Panel panel4;
        private Controls.ListTagsCustom lTagLoaiPhongThi;
    }
}