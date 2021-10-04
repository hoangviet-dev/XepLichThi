
namespace XepLichThi.Views
{
    partial class XepLich
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.cbxHocKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXepLich = new XepLichThi.Views.Controls.ButtonSmallCustom();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblLichThi = new XepLichThi.Views.Controls.TableCustom();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNamHoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thời gian bắt đầu thi";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cbxNamHoc);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateTimeStart);
            this.panel1.Controls.Add(this.cbxHocKy);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnXepLich);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 450);
            this.panel1.TabIndex = 3;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "dd/MM/yyy";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(17, 201);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(226, 20);
            this.dateTimeStart.TabIndex = 1;
            // 
            // cbxHocKy
            // 
            this.cbxHocKy.BackColor = System.Drawing.Color.White;
            this.cbxHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHocKy.Location = new System.Drawing.Point(16, 50);
            this.cbxHocKy.Name = "cbxHocKy";
            this.cbxHocKy.Size = new System.Drawing.Size(226, 32);
            this.cbxHocKy.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Học kỳ";
            // 
            // btnXepLich
            // 
            this.btnXepLich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnXepLich.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnXepLich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXepLich.Location = new System.Drawing.Point(16, 241);
            this.btnXepLich.Name = "btnXepLich";
            this.btnXepLich.Size = new System.Drawing.Size(227, 50);
            this.btnXepLich.TabIndex = 2;
            this.btnXepLich.Title = "Xếp lịch";
            this.btnXepLich.ButtonClick += new System.EventHandler(this.btnXepLich_ButtonClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tblLichThi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(263, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 396);
            this.panel2.TabIndex = 4;
            // 
            // tblLichThi
            // 
            this.tblLichThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLichThi.Location = new System.Drawing.Point(0, 0);
            this.tblLichThi.Name = "tblLichThi";
            this.tblLichThi.ShowHead = false;
            this.tblLichThi.Size = new System.Drawing.Size(537, 396);
            this.tblLichThi.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(263, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(537, 54);
            this.panel3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(219, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "LỊCH THI";
            // 
            // cbxNamHoc
            // 
            this.cbxNamHoc.BackColor = System.Drawing.Color.White;
            this.cbxNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNamHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNamHoc.Location = new System.Drawing.Point(16, 123);
            this.cbxNamHoc.Name = "cbxNamHoc";
            this.cbxNamHoc.Size = new System.Drawing.Size(226, 32);
            this.cbxNamHoc.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Năm học";
            // 
            // XepLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XepLich";
            this.Text = "XepLich";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Controls.ButtonSmallCustom btnXepLich;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Controls.TableCustom tblLichThi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxHocKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.ComboBox cbxNamHoc;
        private System.Windows.Forms.Label label4;
    }
}