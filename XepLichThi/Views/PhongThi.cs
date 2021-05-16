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
    public partial class PhongThi : XepLichThi.Views.Layout
    {
        private CtlPhongThi phongThi;
        public PhongThi()
        {
            InitializeComponent();
            phongThi = new CtlPhongThi();
            loadData("");

        }

        private void loadData(string search)
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
        }
    }
}
