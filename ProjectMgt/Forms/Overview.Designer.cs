namespace ProjectMgt.Forms
{
    partial class Overview
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
            this.sgL1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.tabL1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.btUploadDialog = new DevComponents.DotNetBar.ButtonX();
            this.btSettings = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.btSummary = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sgL1
            // 
            this.sgL1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sgL1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgL1.Location = new System.Drawing.Point(0, 0);
            this.sgL1.Name = "sgL1";
            this.sgL1.Size = new System.Drawing.Size(1219, 591);
            this.sgL1.TabIndex = 0;
            this.sgL1.Text = "superGridControl1";
            // 
            // superTabControl1
            // 
            this.superTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.superTabControl1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Location = new System.Drawing.Point(12, 12);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(1219, 616);
            this.superTabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.superTabControl1.TabIndex = 2;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabL1,
            this.superTabItem1});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // tabL1
            // 
            this.tabL1.AttachedControl = this.superTabControlPanel1;
            this.tabL1.GlobalItem = false;
            this.tabL1.Name = "tabL1";
            this.tabL1.Text = "Project Overview";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.sgL1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1219, 591);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabL1;
            // 
            // btUploadDialog
            // 
            this.btUploadDialog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btUploadDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btUploadDialog.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btUploadDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUploadDialog.Location = new System.Drawing.Point(12, 644);
            this.btUploadDialog.Name = "btUploadDialog";
            this.btUploadDialog.Size = new System.Drawing.Size(96, 25);
            this.btUploadDialog.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btUploadDialog.TabIndex = 3;
            this.btUploadDialog.Text = "Upload";
            this.btUploadDialog.Click += new System.EventHandler(this.btUploadDialog_Click);
            // 
            // btSettings
            // 
            this.btSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSettings.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSettings.Location = new System.Drawing.Point(139, 644);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(96, 25);
            this.btSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btSettings.TabIndex = 4;
            this.btSettings.Text = "Setting";
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel2;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "superTabItem1";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1219, 591);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem1;
            // 
            // btSummary
            // 
            this.btSummary.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSummary.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSummary.Location = new System.Drawing.Point(905, 644);
            this.btSummary.Name = "btSummary";
            this.btSummary.Size = new System.Drawing.Size(138, 25);
            this.btSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btSummary.TabIndex = 5;
            this.btSummary.Text = "Project Summary";
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1243, 681);
            this.Controls.Add(this.btSummary);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btUploadDialog);
            this.Controls.Add(this.superTabControl1);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Overview";
            this.Text = "Overview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgL1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabL1;
        private DevComponents.DotNetBar.ButtonX btUploadDialog;
        private DevComponents.DotNetBar.ButtonX btSettings;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.ButtonX btSummary;
    }
}