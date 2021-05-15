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

        public Main()
        {
            InitializeComponent();
            lblTitle.Text = "";
            createMenu();
        }

        public void createMenu()
        {
            lMenu.Add(new Menu("SINH VIÊN", "Student"));
            lMenu.Add(new Menu("LỚP HỌC PHẦN", "Student"));
            lMenu.Add(new Menu("PHÒNG THI", "Student"));
            lMenu.Add(new Menu("DANH MỤC", "Student"));
            lMenu.Add(new Menu("XẾP LỊCH THI", "Student"));

            pnlMenu.Controls.Clear();

            foreach(Menu item in lMenu)
            {
                MenuItemControl mi = new MenuItemControl(item.Title, item.ClassName);
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
                if (objectType != null)
                {
                    Form frm = (Form)Activator.CreateInstance(objectType);
                    frm.Top = 0;
                    frm.Left = 0;
                    frm.TopLevel = false;
                    frm.Dock = DockStyle.Fill;
                    pnlView.Controls.Add(frm);
                    frm.Show();
                }
                if (oldOb != null)
                {
                    ((MenuItemControl)oldOb).Choose = false;
                }
                oldOb = m;
            }
        }
    }
    public class Menu
    {
        string title;
        string className;
        public Menu(string title, string className)
        {
            this.title = title;
            this.className = className;
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public string ClassName
        {
            get => className;
            set => className = value;
        }
    }
}
