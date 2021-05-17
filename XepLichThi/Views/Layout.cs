using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XepLichThi.Views
{
    public partial class Layout : Form
    {
        protected Object data;

        protected string Seleted()
        {
            return tblCus.Selected;
        }
        public Layout()
        {
            InitializeComponent();
        }

        public void test()
        {
            if (data != null && data.GetType().ToString().IndexOf("List") > -1)
            {
                object item = ((IEnumerable)data).Cast<object>().ToList()[0];
                Console.WriteLine(item.GetType().GetProperties().Length);
            }
        }



        public void BindData()
        {
            if (data != null)
            {
                tblCus.BindData(data);
                test();
            }
        }

        public virtual void LoadData(string search)
        {

        }

        protected virtual void DeleteData()
        {

        }

        public bool ConfirmDelete()
        {
            return MessageBox.Show("Bạn có đồng ý xoá " + tblCus.Selected, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private void tblCus_DeleteAction(object sender, EventArgs e)
        {
            DeleteData();
        }

        private class PropInfo
        {
            public string Name;
            public string DisplayName;
            public PropInfo(string _name, string _displayName)
            {
                this.Name = _name;
                this.DisplayName = _displayName;
            }
        }
    }
}
