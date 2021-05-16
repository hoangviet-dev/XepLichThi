using System;
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

        public void BindData()
        {
            if (data != null)
            {
                tblCus.BindData(data);
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
    }
}
