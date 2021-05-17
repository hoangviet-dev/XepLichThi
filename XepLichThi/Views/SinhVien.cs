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
            type = typeof(Models.SinhVien);
            sinhVien = new CtlSinhVien();
            LoadData("");

        }

        public override void LoadData(string search)
        {
            data = sinhVien.getData(search);
            BindData();
        }

        protected override void DeleteData()
        {
            if (ConfirmDelete())
            {
                sinhVien.deleteData(Seleted());
                BindData();
            }
            LoadData("");
        }
    }
}
