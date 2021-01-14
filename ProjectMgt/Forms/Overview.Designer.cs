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
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabL1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.sgL2 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn19 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tabL2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.sgL3 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn20 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn21 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn22 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn23 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn24 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn25 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn26 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn27 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn28 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn29 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn30 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn31 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn32 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn33 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tabL3 = new DevComponents.DotNetBar.SuperTabItem();
            this.btUploadDialog = new DevComponents.DotNetBar.ButtonX();
            this.btSettings = new DevComponents.DotNetBar.ButtonX();
            this.btSummary = new DevComponents.DotNetBar.ButtonX();
            this.btRefresh = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // sgL1
            // 
            this.sgL1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sgL1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgL1.Location = new System.Drawing.Point(0, -3);
            this.sgL1.Name = "sgL1";
            // 
            // 
            // 
            this.sgL1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.sgL1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.sgL1.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.sgL1.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.sgL1.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.sgL1.PrimaryGrid.ReadOnly = true;
            this.sgL1.Size = new System.Drawing.Size(1219, 591);
            this.sgL1.SizingStyle = DevComponents.DotNetBar.SuperGrid.Style.StyleType.Default;
            this.sgL1.TabIndex = 0;
            this.sgL1.Text = "superGridControl1";
            this.sgL1.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.sgL1_CellDoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Name = "Applicant";
            this.gridColumn1.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Name = "IT PIC";
            this.gridColumn2.Width = 85;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Name = "Request Form No.";
            this.gridColumn3.Width = 135;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn4.Name = "Description";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Name = "id";
            this.gridColumn5.Visible = false;
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
            this.superTabControl1.Controls.Add(this.superTabControlPanel3);
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
            this.tabL2,
            this.tabL3});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock;
            this.superTabControl1.Text = "superTabControl1";
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
            // tabL1
            // 
            this.tabL1.AttachedControl = this.superTabControlPanel1;
            this.tabL1.GlobalItem = false;
            this.tabL1.Name = "tabL1";
            this.tabL1.Text = "Project Overview";
            this.tabL1.Click += new System.EventHandler(this.tabL1_Click);
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.sgL2);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1219, 591);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabL2;
            // 
            // sgL2
            // 
            this.sgL2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sgL2.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgL2.Location = new System.Drawing.Point(0, -3);
            this.sgL2.Name = "sgL2";
            // 
            // 
            // 
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn11);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn12);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn13);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn14);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn16);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn17);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn19);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn18);
            this.sgL2.PrimaryGrid.Columns.Add(this.gridColumn15);
            this.sgL2.Size = new System.Drawing.Size(1219, 591);
            this.sgL2.TabIndex = 0;
            this.sgL2.Text = "superGridControl1";
            this.sgL2.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.sgL2_CellDoubleClick);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Name = "Applicant";
            this.gridColumn6.Width = 80;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Name = "IT PIC";
            this.gridColumn7.Width = 80;
            // 
            // gridColumn8
            // 
            this.gridColumn8.FillWeight = 130;
            this.gridColumn8.Name = "Request Form No.";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Name = "Request Form Description";
            this.gridColumn9.Width = 300;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Name = "Stage";
            this.gridColumn10.Width = 95;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Name = "Expected Finish Date";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Name = "Estimate Stage Finish";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Name = "Actual Finish Date";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Name = "IT Est. give Test Date";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Name = "Apply Date";
            // 
            // gridColumn17
            // 
            this.gridColumn17.Name = "Memo";
            this.gridColumn17.Width = 430;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Name = "Week";
            this.gridColumn19.Width = 80;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Name = "Upload Time";
            this.gridColumn18.Width = 120;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Name = "id";
            this.gridColumn15.Visible = false;
            // 
            // tabL2
            // 
            this.tabL2.AttachedControl = this.superTabControlPanel2;
            this.tabL2.GlobalItem = false;
            this.tabL2.Name = "tabL2";
            this.tabL2.Text = "SubOv";
            this.tabL2.Click += new System.EventHandler(this.tabL2_Click);
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.sgL3);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(1219, 591);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.tabL3;
            // 
            // sgL3
            // 
            this.sgL3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sgL3.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgL3.Location = new System.Drawing.Point(0, -3);
            this.sgL3.Name = "sgL3";
            // 
            // 
            // 
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn20);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn21);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn22);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn23);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn24);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn25);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn26);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn27);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn28);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn29);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn30);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn31);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn32);
            this.sgL3.PrimaryGrid.Columns.Add(this.gridColumn33);
            this.sgL3.Size = new System.Drawing.Size(1219, 591);
            this.sgL3.TabIndex = 6;
            this.sgL3.Text = "superGridControl1";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Name = "Applicant";
            this.gridColumn20.Width = 80;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Name = "IT PIC";
            this.gridColumn21.Width = 80;
            // 
            // gridColumn22
            // 
            this.gridColumn22.FillWeight = 130;
            this.gridColumn22.Name = "Request Form No.";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Name = "Request Form Description";
            this.gridColumn23.Width = 300;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Name = "Stage";
            this.gridColumn24.Width = 95;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Name = "Expected Finish Date";
            // 
            // gridColumn26
            // 
            this.gridColumn26.Name = "Estimate Stage Finish";
            // 
            // gridColumn27
            // 
            this.gridColumn27.Name = "Actual Finish Date";
            // 
            // gridColumn28
            // 
            this.gridColumn28.Name = "IT Est. give Test Date";
            // 
            // gridColumn29
            // 
            this.gridColumn29.Name = "Apply Date";
            // 
            // gridColumn30
            // 
            this.gridColumn30.Name = "Memo";
            this.gridColumn30.Width = 430;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Name = "Week";
            this.gridColumn31.Width = 80;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Name = "Upload Time";
            this.gridColumn32.Width = 120;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Name = "id";
            this.gridColumn33.Visible = false;
            // 
            // tabL3
            // 
            this.tabL3.AttachedControl = this.superTabControlPanel3;
            this.tabL3.GlobalItem = false;
            this.tabL3.Name = "tabL3";
            this.tabL3.Text = "Stage";
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
            // btRefresh
            // 
            this.btRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btRefresh.Location = new System.Drawing.Point(300, 645);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(60, 23);
            this.btRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btRefresh.TabIndex = 6;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1243, 681);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btSummary);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btUploadDialog);
            this.Controls.Add(this.superTabControl1);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Overview";
            this.Text = "Overview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Overview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
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
        private DevComponents.DotNetBar.SuperTabItem tabL2;
        private DevComponents.DotNetBar.ButtonX btSummary;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgL2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem tabL3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn19;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgL3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn20;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn21;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn22;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn23;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn24;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn25;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn26;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn27;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn28;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn29;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn30;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn31;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn32;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn33;
        private DevComponents.DotNetBar.ButtonX btRefresh;
    }
}