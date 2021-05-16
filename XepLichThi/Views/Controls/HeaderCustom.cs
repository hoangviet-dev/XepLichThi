using System;
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
    public partial class HeaderCustom : UserControl
    {
        public HeaderCustom()
        {
            InitializeComponent();
        }

        public string GetTimKiem
        {
            get => txtTimKiem.Text;
            set => txtTimKiem.Text = value;
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler SearchClick;

        private void btnTimKiem_ButtonClick(object sender, EventArgs e)
        {
            SearchClick?.Invoke(sender, e);
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler AddClick;

        private void btnThem_ButtonClick(object sender, EventArgs e)
        {
            AddClick?.Invoke(sender, e);
        }
    }
}
