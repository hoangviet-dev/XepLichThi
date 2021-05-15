using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XepLichThi.Controllers;

namespace XepLichThi.Views
{
    public partial class SinhVien : XepLichThi.Views.Layout
    {
        private CtlSinhVien sinhVien;
        public SinhVien()
        {
            InitializeComponent();
            sinhVien = new CtlSinhVien();
            loadData("");

        }

        private void loadData(string search)
        {
            data = sinhVien.getData(search);
            BindData();
        }

    }
}
