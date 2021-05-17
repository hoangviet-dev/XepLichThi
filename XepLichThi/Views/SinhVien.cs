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

        public override void AddData(object sender, EventArgs e)
        {
            base.AddData(sender, e);
            AddData add = (AddData)sender;
            List<String> listdata = add.GetValue();
            DateTime ngay;
            try
            {
                ngay = DateTime.Parse(listdata[0]);
            }
            catch
            {
                MessageBox.Show("Dữ liệu ngày không hợp lệ!", "Thông báo");
                return;
            }

            int check = sinhVien.addData(listdata[2], listdata[1], DateTime.Parse(listdata[0]));

            if (check == -1)
            {
                MessageBox.Show("Dữ liệu không được để trống!", "Thông báo");
            }
            else if (check == -2)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo");
            }
            else MessageBox.Show("thêm thành công", "Thông báo");

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
