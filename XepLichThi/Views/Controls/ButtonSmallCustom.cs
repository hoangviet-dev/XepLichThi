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
    public partial class ButtonSmallCustom : UserControl
    {
        public ButtonSmallCustom()
        {
            InitializeComponent();
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string Title
        {
            get => label1.Text;
            set => label1.Text = value;
        }



        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;

        private void label1_Click(object sender, EventArgs e)
        {

            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }
    }
}
