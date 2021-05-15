﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XepLichThi.Controllers;
using XepLichThi.Models;

namespace XepLichThi.Views
{
    public partial class LopHocPhan : XepLichThi.Views.Layout
    {
        CtlLopHocPhan lopHocPhan;
        public LopHocPhan()
        {
            InitializeComponent();
            lopHocPhan = new CtlLopHocPhan();
            LoadData("");
        }

        private void LoadData(string search)
        {
            data = lopHocPhan.GetData(search);
            BindData();
        }
    }
}
