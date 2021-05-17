using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XepLichThi.Views.Controls;
using static XepLichThi.Views.Layout;

namespace XepLichThi.Views
{
    public partial class AddData : Form
    {
        private List<PropInfo> lProp;
        public AddData()
        {
            InitializeComponent();
        }

        public AddData(List<PropInfo> lProp) : this()
        {
            this.lProp = lProp;
            LoadProp();
        }

        private void LoadProp()
        {
            pnlAdd.Controls.Clear();
            foreach(PropInfo prop in lProp)
            {
                TextboxGroupCustom tbox = new TextboxGroupCustom();
                tbox.Dock = DockStyle.Top;
                tbox.Title = prop.DisplayName;
                tbox.Text = "";
                tbox.Placeholder = prop.DisplayName;
                pnlAdd.Controls.Add(tbox);
                tbox.BringToFront();
            }
        }

        public List<string> GetValue()
        {
            List<string> res = new List<string>();
            foreach(Control con in pnlAdd.Controls)
            {
                TextboxGroupCustom tbox = (TextboxGroupCustom)con;
                res.Add(tbox.Text);
            }
            return res;
        }

        public event EventHandler AddAction;

        private void buttonSmallCustom1_ButtonClick(object sender, EventArgs e)
        {
            if (AddAction != null)
                AddAction(this, e);
        }
    }
}
