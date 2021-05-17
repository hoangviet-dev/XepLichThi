using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XepLichThi.Controllers;
using static XepLichThi.Models.DataProvider;

namespace XepLichThi.Views
{
    public partial class PhongThi : XepLichThi.Views.Layout
    {
        private CtlPhongThi phongThi;
        public PhongThi()
        {
            InitializeComponent();
            type = typeof(Models.PhongThi);
            phongThi = new CtlPhongThi();
            LoadData("");

        }

        public override void AddData(object sender, EventArgs e)
        {
            base.AddData(sender, e);
            AddData add = (AddData)sender;
            List<String> listdata = add.GetValue();

            string query = @"SELECT * FROM LoaiPhongThi WHERE LoaiPhongThi = @LoaiPhongThi";
            SqlParam[] sqlParams = { new SqlParam("@LoaiPhongThi", listdata[1]) };
            DataTable data = phongThi.excuteQuery(query, sqlParams);
            int check = data.Rows.Count;

            if (check == 0)
            {
                MessageBox.Show("Không tồn tại loại phòng thi này!", "Thông báo");
                return;
            }

            check = phongThi.addData(listdata[2], data.Rows[0][0].ToString(), int.Parse(listdata[0]));

            if (check == -1)
            {
                MessageBox.Show("Dữ liệu không được để trống!", "Thông báo");
            }
            else if (check == -2)
            {
                MessageBox.Show("Mã phòng thi đã tồn tại!", "Thông báo");
            }
            else if (check == -3)
            {
                MessageBox.Show("Không tồn tại loại phòng thi này!", "Thông báo");
            }
            LoadData("");
        }
        public override void LoadData(string search)
        {
            data = phongThi.getData(search);
            BindData();
        }
        protected override void DeleteData()
        {
            if (ConfirmDelete())
            {
                phongThi.deleteData(Seleted());
                BindData();
            }

            LoadData("");
        }
    }
}
