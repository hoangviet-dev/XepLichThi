
namespace XepLichThi.Views
{
    partial class AddData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSmallCustom1 = new XepLichThi.Views.Controls.ButtonSmallCustom();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAdd
            // 
            this.pnlAdd.AutoSize = true;
            this.pnlAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdd.Location = new System.Drawing.Point(0, 0);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(434, 390);
            this.pnlAdd.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.buttonSmallCustom1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 390);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 60);
            this.panel2.TabIndex = 1;
            // 
            // buttonSmallCustom1
            // 
            this.buttonSmallCustom1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.buttonSmallCustom1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.buttonSmallCustom1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSmallCustom1.Location = new System.Drawing.Point(119, 7);
            this.buttonSmallCustom1.Name = "buttonSmallCustom1";
            this.buttonSmallCustom1.Size = new System.Drawing.Size(190, 50);
            this.buttonSmallCustom1.TabIndex = 0;
            this.buttonSmallCustom1.Title = "THÊM";
            this.buttonSmallCustom1.ButtonClick += new System.EventHandler(this.buttonSmallCustom1_ButtonClick);
            // 
            // AddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(434, 450);
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.panel2);
            this.Name = "AddData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddData";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.Panel panel2;
        private Controls.ButtonSmallCustom buttonSmallCustom1;
    }
}