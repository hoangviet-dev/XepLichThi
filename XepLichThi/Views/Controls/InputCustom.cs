﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XepLichThi.Views.Controls
{
    public partial class InputCustom : UserControl
    {
        public InputCustom()
        {
            InitializeComponent();
        }

        [Category("Text")]
        public string Text
        {
            get {
                return txtInput.Text;
            }

            set
            {
                txtInput.Text = value;
            }
        }
    }
}
