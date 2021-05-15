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
    public partial class TextboxCustom : UserControl
    {
        string placeholder = "";
        public TextboxCustom()
        {
            InitializeComponent();
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (textBox1.Text == placeholder)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = placeholder;
                textBox1.ForeColor = Color.Gray;
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get => textBox1.Text;
            set {
                textBox1.Text = value;
                if (textBox1.Text == placeholder)
                {
                    textBox1.Text = "";
                    textBox1.ForeColor = Color.Black;
                } else
                {
                    textBox1.ForeColor = Color.Black;
                }
            }
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string Placeholder
        {
            get => placeholder;
            set {
                placeholder = value;
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Text = placeholder;
                    textBox1.ForeColor = Color.Gray;
                }
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public char PasswordChar
        {
            get => textBox1.PasswordChar;
            set => textBox1.PasswordChar = value;
        }

    }

}
