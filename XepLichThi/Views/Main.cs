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

namespace XepLichThi.Views
{
    public partial class Main : Form
    {

        List<Object> lMenu = new List<Object>();
        Object oldOb = null;
        Layout layout = null;

        public Main()
        {
            InitializeComponent();
            lblTitle.Text = "";
            createMenu();
            headerCustom1.Hide();
        }

        public void createMenu()
        {
            lMenu.Add(new Menu("SINH VIÊN", "XepLichThi.Views.SinhVien", true));
            lMenu.Add(new Menu("LỚP HỌC PHẦN", "XepLichThi.Views.LopHocPhan", true));
            lMenu.Add(new Menu("PHÒNG THI", "XepLichThi.Views.PhongThi", true));
            lMenu.Add(new Menu("DANH MỤC", "XepLichThi.Views.DanhMuc", false));
            lMenu.Add(new Menu("XẾP LỊCH THI", "XepLichThi.Views.XepLich", false));

            pnlMenu.Controls.Clear();

            foreach(Menu item in lMenu)
            {
                MenuItemControl mi = new MenuItemControl(item.Title, item.ClassName, item.Header);
                mi.Dock = DockStyle.Top;
                pnlMenu.Controls.Add(mi);
                mi.BringToFront();
                mi.ButtonClick += new System.EventHandler(this.menu_click);
            }
        }

        private void menu_click(object sender, EventArgs e)
        {
            MenuItemControl m = (MenuItemControl)sender;
            if (m != oldOb)
            {
                m.Choose = true;
                lblTitle.Text = m.Text;
                pnlView.Controls.Clear();
                var objectType = Type.GetType(m.ClassName);
                if (m.Header)
                {
                    headerCustom1.Show();
                } else
                {
                    headerCustom1.Hide();
                }
                if (objectType != null)
                {
                    Form frm = (Form)Activator.CreateInstance(objectType);
                    frm.Top = 0;
                    frm.Left = 0;
                    frm.TopLevel = false;
                    frm.Dock = DockStyle.Fill;
                    pnlView.Controls.Add(frm);
                    frm.Show();
                    if (m.Header)
                    {
                        layout = (Layout)frm;
                    } else
                    {
                        layout = null;
                    }
                }
                if (oldOb != null)
                {
                    ((MenuItemControl)oldOb).Choose = false;
                }
                oldOb = m;
            }
        }

        private void headerCustom1_SearchClick(object sender, EventArgs e)
        {
            string search = headerCustom1.GetTimKiem;
            if (layout != null)
            {
                layout.LoadData(search);
            }
        }

        private void headerCustom1_AddClick(object sender, EventArgs e)
        {
            if (layout != null)
            {
                layout.OpenAdd();
            }
        }
    }
    public class Menu
    {
        string title;
        string className;
        bool header;
        public Menu(string title, string className, bool header)
        {
            this.title = title;
            this.className = className;
            this.header = header;
        }

        public string Title
        {
            get => title;
        }

        public string ClassName
        {
            get => className;
        }

        public bool Header
        {
            get => header;
        }
    }
}
