using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XepLichThi.Controllers;
using static XepLichThi.Views.Controls.ListTagsCustom;

namespace XepLichThi.Views
{
    public partial class DanhMuc : Form
    {
        private CtlLoaiPhongThi ctlLoaiPhongThi;
        public DanhMuc()
        {
            InitializeComponent();
            ctlLoaiPhongThi = new CtlLoaiPhongThi();
            LoadDataLoaiPhongThi("");
        }

        private void LoadDataLoaiPhongThi(string search)
        {
            List<TagInfo> l = new List<TagInfo>();
            List<Models.LoaiPhongThi> lPT = ctlLoaiPhongThi.getData(search);

            foreach(Models.LoaiPhongThi pt in lPT)
            {
                l.Add(new TagInfo(pt.loaiPhongThi, pt.maLoaiPhongThi));
            }

            lTagLoaiPhongThi.Data = l;
            lTagLoaiPhongThi.BindData();
        }

        private void ltagHinhThucThi_AddAction(object sender, EventArgs e)
        {
            TagInfo tag = (TagInfo)sender;

        }

        private void lTagLoaiPhongThi_AddAction(object sender, EventArgs e)
        {
            TagInfo tag = (TagInfo)sender;
            //tag.

        }

        private void ltagHinhThucThi_UpdateAction(object sender, EventArgs e)
        {
            TagInfo tag = (TagInfo)sender;

        }

        private void lTagLoaiPhongThi_UpdateAction(object sender, EventArgs e)
        {
            TagInfo tag = (TagInfo)sender;
            ctlLoaiPhongThi.updateData(tag.id, tag.title, "");

        }
    }
}
