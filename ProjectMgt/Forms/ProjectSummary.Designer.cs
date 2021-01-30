namespace ProjectMgt.Forms
{
    partial class ProjectSummary
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
            this.sgProjSum = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.del = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.sgListUpload = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this._id = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.btBack = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // sgProjSum
            // 
            this.sgProjSum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sgProjSum.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgProjSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sgProjSum.Location = new System.Drawing.Point(12, 52);
            this.sgProjSum.Name = "sgProjSum";
            // 
            // 
            // 
            this.sgProjSum.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.sgProjSum.PrimaryGrid.Columns.Add(this.del);
            this.sgProjSum.Size = new System.Drawing.Size(961, 583);
            this.sgProjSum.TabIndex = 0;
            this.sgProjSum.Text = "superGridControl1";
            this.sgProjSum.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.sgProjSum_CellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AllowEdit = false;
            this.gridColumn1.Name = "Week";
            this.gridColumn1.Width = 150;
            // 
            // del
            // 
            this.del.AllowEdit = false;
            this.del.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.del.Name = "";
            this.del.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.del.Width = 80;
            // 
            // sgListUpload
            // 
            this.sgListUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sgListUpload.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgListUpload.Location = new System.Drawing.Point(12, 52);
            this.sgListUpload.Name = "sgListUpload";
            // 
            // 
            // 
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn11);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn12);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn13);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn14);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn15);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn16);
            this.sgListUpload.PrimaryGrid.Columns.Add(this.gridColumn17);
            this.sgListUpload.PrimaryGrid.Columns.Add(this._id);
            this.sgListUpload.Size = new System.Drawing.Size(961, 583);
            this.sgListUpload.TabIndex = 1;
            this.sgListUpload.Text = "superGridControl1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AllowEdit = false;
            this.gridColumn2.Name = "No";
            this.gridColumn2.Width = 35;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AllowEdit = false;
            this.gridColumn3.Name = "System";
            this.gridColumn3.Width = 110;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AllowEdit = false;
            this.gridColumn4.Name = "Error";
            this.gridColumn4.Width = 35;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AllowEdit = false;
            this.gridColumn5.Name = "Description";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AllowEdit = false;
            this.gridColumn6.Name = "Applicant";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AllowEdit = false;
            this.gridColumn7.Name = "PIC";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AllowEdit = false;
            this.gridColumn8.Name = "Request Form No";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AllowEdit = false;
            this.gridColumn9.Name = "Request Form Description";
            this.gridColumn9.Width = 300;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AllowEdit = false;
            this.gridColumn10.Name = "Stage";
            // 
            // gridColumn11
            // 
            this.gridColumn11.AllowEdit = false;
            this.gridColumn11.Name = "Expected Date";
            // 
            // gridColumn12
            // 
            this.gridColumn12.AllowEdit = false;
            this.gridColumn12.Name = "Stage Est. Finish";
            // 
            // gridColumn13
            // 
            this.gridColumn13.AllowEdit = false;
            this.gridColumn13.Name = "Stage Actual Finish";
            // 
            // gridColumn14
            // 
            this.gridColumn14.AllowEdit = false;
            this.gridColumn14.Name = "IT Give TestDate";
            // 
            // gridColumn15
            // 
            this.gridColumn15.AllowEdit = false;
            this.gridColumn15.Name = "ApplyDate";
            // 
            // gridColumn16
            // 
            this.gridColumn16.AllowEdit = false;
            this.gridColumn16.Name = "Memo";
            this.gridColumn16.Width = 350;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AllowEdit = false;
            this.gridColumn17.Name = "Upload Date";
            // 
            // _id
            // 
            this._id.AllowEdit = false;
            this._id.Name = "";
            // 
            // btBack
            // 
            this.btBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBack.Location = new System.Drawing.Point(12, 12);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(69, 34);
            this.btBack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btBack.Symbol = "";
            this.btBack.TabIndex = 3;
            this.btBack.Text = "Back";
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // ProjectSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 653);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.sgListUpload);
            this.Controls.Add(this.sgProjSum);
            this.Name = "ProjectSummary";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProjectSummary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProjectSummary_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgProjSum;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn del;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgListUpload;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16;
        private DevComponents.DotNetBar.SuperGrid.GridColumn _id;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17;
        private DevComponents.DotNetBar.ButtonX btBack;
    }
}