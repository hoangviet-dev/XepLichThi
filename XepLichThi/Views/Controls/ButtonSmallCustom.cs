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
            get => button1.Text;
            set => button1.Text = value;
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public  Color BackgroundColor
        {
            get => button1.BackColor;
            set => button1.BackColor = value;
        }


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;

        private void button1_Click(object sender, EventArgs e)
        {
            this.ButtonClick?.Invoke(this, e);
        }
    }
}
