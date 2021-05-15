using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XepLichThi.Controllers;

namespace XepLichThi.Views
{
    public partial class Login : Form
    {
        private CtlLogin ctlLogin;
        public Login()
        {
            InitializeComponent();
            ctlLogin = new CtlLogin();
            lblNotification.Text = "";
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("debug");
            string username = txtUserName.Text;
            string password = txtPasswork.Text;

            if (String.IsNullOrEmpty(username))
            {
                lblNotification.Text = "Tài khoản không được để trống.";
                lblNotification.Focus();
            }
            else if (String.IsNullOrEmpty(password)){
                lblNotification.Text = "Mật khẩu không được để trống.";
            }

            else if (ctlLogin.CheckLogin(username, password))
            {
                Main frm = new Main();
                this.Hide();
                frm.ShowDialog();
                this.Show();
            } 
            else
            {
                lblNotification.Text = "Đăng nhập không thành công, tài khoản hoặc mật khẩu bị sai.";
            }
        }
    }
}
