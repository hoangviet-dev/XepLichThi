using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XepLichThi.Models;

namespace XepLichThi.Views
{
    public partial class XepLich : Form
    {
        //
        public XepLich()
        {
            InitializeComponent();
            cbxHocKy.Items.Add("1");
            cbxHocKy.Items.Add("2");
            cbxHocKy.Items.Add("3");
            cbxHocKy.Text = "1";
        }

        private void btnXepLich_ButtonClick(object sender, EventArgs e)
        {
            List<LichThi> listLichThi = new List<LichThi>();
            Controllers.XepLich xepLich = new Controllers.XepLich();
            DateTime dateTime = dateTimeStart.Value;
            int hk = int.Parse(cbxHocKy.Text);
            int nh = dateTime.Year;
            int nt = nh + 1;
            string namhoc = nh.ToString() + "-" + nt.ToString();
            if (hk>1 || (hk == 1 && dateTime.Month < 3))
            {
                nt = nh - 1;
                namhoc = nt.ToString() + "-" + nh.ToString();
            }
            listLichThi = xepLich.process(namhoc, hk, dateTime);
            tblLichThi.BindData(listLichThi);
        }
    }
}
