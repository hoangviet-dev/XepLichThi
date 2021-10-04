
namespace XepLichThi.Views
{
    partial class Login
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblNotification = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPasswork = new XepLichThi.Views.Controls.TextboxGroupCustom();
            this.txtUserName = new XepLichThi.Views.Controls.TextboxGroupCustom();
            this.buttonCustom1 = new XepLichThi.Views.Controls.ButtonCustom();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 514);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(182, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 430);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblNotification);
            this.panel4.Controls.Add(this.txtPasswork);
            this.panel4.Controls.Add(this.txtUserName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(582, 272);
            this.panel4.TabIndex = 3;
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification.ForeColor = System.Drawing.Color.Red;
            this.lblNotification.Location = new System.Drawing.Point(63, 248);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(51, 20);
            this.lblNotification.TabIndex = 1;
            this.lblNotification.Text = "label2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonCustom1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 338);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 92);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(233)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(582, 66);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐĂNG NHẬP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPasswork
            // 
            this.txtPasswork.Location = new System.Drawing.Point(65, 138);
            this.txtPasswork.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswork.Name = "txtPasswork";
            this.txtPasswork.PasswordChar = '⬤';
            this.txtPasswork.Placeholder = "Mật khẩu";
            this.txtPasswork.Size = new System.Drawing.Size(450, 93);
            this.txtPasswork.TabIndex = 1;
            this.txtPasswork.Title = "Mật khẩu";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(65, 32);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.Placeholder = "Tài khoản";
            this.txtUserName.Size = new System.Drawing.Size(450, 91);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Title = "Tài khoản";
            // 
            // buttonCustom1
            // 
            this.buttonCustom1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(233)))));
            this.buttonCustom1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCustom1.Location = new System.Drawing.Point(119, 20);
            this.buttonCustom1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCustom1.Name = "buttonCustom1";
            this.buttonCustom1.Size = new System.Drawing.Size(333, 60);
            this.buttonCustom1.TabIndex = 2;
            this.buttonCustom1.Title = "ĐĂNG NHẬP";
            this.buttonCustom1.ButtonClick += new System.EventHandler(this.buttonCustom1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(975, 538);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Đăng nhập";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private Controls.TextboxGroupCustom txtUserName;
        private Controls.TextboxGroupCustom txtPasswork;
        private System.Windows.Forms.Label lblNotification;
        private Controls.ButtonCustom buttonCustom1;
    }
}