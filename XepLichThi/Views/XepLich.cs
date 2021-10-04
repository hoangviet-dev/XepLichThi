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
            CtlLichThi ctlLichThi = new CtlLichThi();
            foreach (string item in ctlLichThi.getNamHoc())
            {
                cbxNamHoc.Items.Add(item);
            }
            cbxNamHoc.SelectedIndex = 0;
        }

        private void btnXepLich_ButtonClick(object sender, EventArgs e)
        {
            List<LichThi> listLichThi = new List<LichThi>();
            Controllers.XepLich xepLich = new Controllers.XepLich();
            DateTime dateTime = dateTimeStart.Value;
            int hk = int.Parse(cbxHocKy.Text);
            string namhoc = cbxNamHoc.Text;
            listLichThi = xepLich.process(namhoc, hk, dateTime);
            tblLichThi.BindData(listLichThi);
        }
    }
}
