
namespace XepLichThi.Views.Controls
{
    partial class TextboxGroupCustom
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textboxCustom1 = new XepLichThi.Views.Controls.TextboxCustom();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 37);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(76, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textboxCustom1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 51);
            this.panel2.TabIndex = 1;
            // 
            // textboxCustom1
            // 
            this.textboxCustom1.AutoSize = true;
            this.textboxCustom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxCustom1.Location = new System.Drawing.Point(0, 0);
            this.textboxCustom1.Name = "textboxCustom1";
            this.textboxCustom1.PasswordChar = '\0';
            this.textboxCustom1.Placeholder = "";
            this.textboxCustom1.Size = new System.Drawing.Size(450, 51);
            this.textboxCustom1.TabIndex = 0;
            // 
            // TextboxGroupCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TextboxGroupCustom";
            this.Size = new System.Drawing.Size(450, 88);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private TextboxCustom textboxCustom1;
        private System.Windows.Forms.Label lblTitle;
    }
}
