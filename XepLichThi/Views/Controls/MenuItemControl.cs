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
    public partial class MenuItemControl : UserControl
    {

        private string className;
        private bool choose = false;
        public MenuItemControl()
        {
            InitializeComponent();
        }

        public MenuItemControl(string title, string className) : this()
        {
            label1.Text = title;
            this.className = className;
        }

        public string ClassName
        {
            get => "XepLichThi.Views." + className;
            set => className = value;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get => label1.Text;
            set => label1.Text = value;
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public bool Choose
        {
            get => choose;
            set
            {
                choose = value;
                if (value)
                {
                    panel1.BackColor = Color.White;
                    label1.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(233)))));
                }
                else
                {
                    panel1.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(233)))));
                    label1.ForeColor = Color.White;
                }
            }
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
