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
    public partial class TextboxGroupCustom : UserControl
    {
        public TextboxGroupCustom()
        {
            InitializeComponent();
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get => textboxCustom1.Text;
            set => textboxCustom1.Text = value;
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string Placeholder
        {
            get => textboxCustom1.Placeholder;
            set => textboxCustom1.Placeholder = value;
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public char PasswordChar
        {
            get => textboxCustom1.PasswordChar;
            set => textboxCustom1.PasswordChar = value;
        }
    }
}
