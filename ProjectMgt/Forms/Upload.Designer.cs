namespace ProjectMgt.Forms
{
    partial class Upload
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
            this.txtbxPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btBrowse = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btUpload = new DevComponents.DotNetBar.ButtonX();
            this.cbWeek = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.SuspendLayout();
            // 
            // txtbxPath
            // 
            // 
            // 
            // 
            this.txtbxPath.Border.Class = "TextBoxBorder";
            this.txtbxPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtbxPath.DisabledBackColor = System.Drawing.Color.White;
            this.txtbxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxPath.Location = new System.Drawing.Point(12, 61);
            this.txtbxPath.Name = "txtbxPath";
            this.txtbxPath.PreventEnterBeep = true;
            this.txtbxPath.ReadOnly = true;
            this.txtbxPath.Size = new System.Drawing.Size(367, 22);
            this.txtbxPath.TabIndex = 5;
            // 
            // btBrowse
            // 
            this.btBrowse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btBrowse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btBrowse.Location = new System.Drawing.Point(385, 61);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(75, 23);
            this.btBrowse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btBrowse.TabIndex = 6;
            this.btBrowse.Text = "Browse";
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 30);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(132, 25);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "Select Excel File";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(12, 97);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(118, 23);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "Select Week";
            // 
            // btUpload
            // 
            this.btUpload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btUpload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btUpload.Location = new System.Drawing.Point(163, 217);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(143, 42);
            this.btUpload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btUpload.TabIndex = 10;
            this.btUpload.Text = "Upload";
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // cbWeek
            // 
            this.cbWeek.DisplayMember = "Text";
            this.cbWeek.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWeek.FormattingEnabled = true;
            this.cbWeek.ItemHeight = 17;
            this.cbWeek.Location = new System.Drawing.Point(12, 126);
            this.cbWeek.Name = "cbWeek";
            this.cbWeek.Size = new System.Drawing.Size(446, 23);
            this.cbWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek.TabIndex = 11;
            // 
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 271);
            this.Controls.Add(this.cbWeek);
            this.Controls.Add(this.btUpload);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.txtbxPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Upload";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload";
            this.Load += new System.EventHandler(this.Upload_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtbxPath;
        private DevComponents.DotNetBar.ButtonX btBrowse;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btUpload;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbWeek;
    }
}