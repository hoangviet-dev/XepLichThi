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
    public partial class TagCustom : UserControl
    {
        private string title;
        private string index;
        private bool newItem;

        public TagCustom()
        {
            InitializeComponent();
            btnAllow.Hide();
        }

        public TagCustom(string title, string index, bool newItem = false) : this()
        {
            this.title = title;
            this.index = index;
            this.newItem = newItem;
            txtTitle.Text = title;
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Index
        {
            get => index;
        }

        public bool NewItem
        {
            get => newItem;
            set => newItem = value;
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTitle.Text != title)
            {
                btnAllow.Show();
            } else
            {
                btnAllow.Hide();
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler AllowClick;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler DeleteClick;

        private void btnAllow_Click(object sender, EventArgs e)
        {
            if (AllowClick != null)
                AllowClick(sender, e);
            title = txtTitle.Text;
            btnAllow.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DeleteClick != null)
                DeleteClick(sender, e);
            this.Dispose();
        }
    }
}
