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
    public partial class ListTagsCustom : UserControl
    {
        private List<TagInfo> data;

        public List<TagInfo> Data
        {
            get => data;
            set => data = value;
        }
        public ListTagsCustom()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            fLayout.Controls.Clear();
            foreach(TagInfo _tag in data){
                TagCustom tag = new TagCustom(_tag.title, _tag.id);
                tag.AllowClick += new EventHandler(this.AllowClick);
                fLayout.Controls.Add(tag);
            }
        }



        public class TagInfo
        {
            public string title;
            public string id;
            public TagInfo(string title, string id)
            {
                this.title = title;
                this.id = id;
            }
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler AddAction;


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler UpdateAction;

        private void AllowClick(object sender, EventArgs e)
        {
            TagCustom tag = (TagCustom)sender;
            if (tag.NewItem)
            {
                if (AddAction != null)
                {
                    AddAction(new TagInfo(tag.Title, ""), e);
                } 
            } else
            {
                if (UpdateAction != null)
                {
                    UpdateAction(new TagInfo(tag.Title, tag.Index), e);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TagCustom tag = new TagCustom("", "", true);
            tag.AllowClick += new EventHandler(this.AllowClick);
            fLayout.Controls.Add(tag);
        }
    }
}
