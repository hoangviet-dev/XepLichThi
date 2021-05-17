using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XepLichThi.Views.Controls
{
    public partial class TableCustom : UserControl
    {
        private string select;
        private bool showHead;
        public TableCustom()
        {
            InitializeComponent();
            dtgvTable.EnableHeadersVisualStyles = false;
            dtgvTable.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(233)))));
            lblMa.Text = "";
            showHead = true;
        }

        public void BindData(Object data)
        {
            dtgvTable.DataSource = data;
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler DeleteAction;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public bool ShowHead
        {
            get => showHead;
            set
            {
                showHead = value;
                if (value)
                {
                    panel4.Show();
                } else
                {
                    panel4.Hide();
                }
            }
        }

        public string Selected
        {
            get
            {
                return select;
            }
        }

        private void dtgvTable_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            DataGridViewSelectedRowCollection row = dtgvTable.SelectedRows;
            if (row.Count == 1)
            {
                select = row[0].Cells[0].Value.ToString();
                btnXoa.Enabled = true;
            }
            else
            {
                select = "";
                btnXoa.Enabled = false;
            }
            lblMa.Text = select;
        }

        private void btnXoa_ButtonClick(object sender, EventArgs e)
        {
            if (this.DeleteAction != null)
                DeleteAction(this, e);
        }
    }
}
