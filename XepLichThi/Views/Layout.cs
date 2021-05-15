using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XepLichThi.Views
{
    public partial class Layout : Form
    {
        protected Object data;
        public Layout()
        {
            InitializeComponent();
        }

        protected void BindData()
        {
            if (data != null)
            {
                tblCus.BindData(data);
            }
        }
    }
}
