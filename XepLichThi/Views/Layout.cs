using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XepLichThi.Views
{
    public partial class Layout : Form
    {
        public List<PropInfo> res;
        protected Object data;

        protected string Seleted()
        {
            return tblCus.Selected;
        }
        public Layout()
        {
            InitializeComponent();
        }

        public void getListProp()
        {
            
            if (data != null && data.GetType().ToString().IndexOf("List") > -1)
            {
                res = new List<PropInfo>();
                object item = ((IEnumerable)data).Cast<object>().ToList()[0];
                //Console.WriteLine(item.GetType().GetProperties().Length);
                PropertyInfo[] propertyInfo = item.GetType().GetProperties();
                foreach (PropertyInfo property in propertyInfo)
                {
                    res.Add(new PropInfo(
                        property.Name, 
                        property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault().DisplayName, 
                        property.GetType())
                        );  
                }
            }
        }



        public void BindData()
        {
            if (data != null)
            {
                tblCus.BindData(data);
                getListProp();
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

        public class PropInfo
        {
            public string Name;
            public string DisplayName;
            public Type TypeData;
            public PropInfo(string Name, string DisplayName, Type TypeData)
            {
                this.Name = Name;
                this.DisplayName = DisplayName;
                this.TypeData = TypeData;
            }
        }
    }
}
