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
        public List<PropInfo> Props;
        protected object data;
        protected Type type; 

        protected string Seleted()
        {
            return tblCus.Selected;
        }
        public Layout()
        {
            InitializeComponent();
            Props = new List<PropInfo>();
        }

        public void getListProp()
        {
            if (type != null)
            {
                PropertyInfo[] propertyInfo = type.GetProperties();
                foreach (PropertyInfo property in propertyInfo)
                {
                    Props.Add(new PropInfo(
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

        public virtual void AddData(object sender, EventArgs e)
        {

        }

        public void OpenAdd()
        {
            AddData frm = new AddData(Props);
            frm.AddAction += new EventHandler(AddData);
            frm.ShowDialog();
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
