namespace ProjectMgt.Forms
{
    partial class Settings
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
            this.sgWeek = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.edit = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.del = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btCancelWeek = new DevComponents.DotNetBar.ButtonX();
            this.btSaveWeek = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtbxNoteWeek = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtbxWeekName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtEndDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtStartDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate)).BeginInit();
            this.SuspendLayout();
            // 
            // sgWeek
            // 
            this.sgWeek.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgWeek.Location = new System.Drawing.Point(9, 17);
            this.sgWeek.Name = "sgWeek";
            // 
            // 
            // 
            this.sgWeek.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.sgWeek.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.sgWeek.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.sgWeek.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.sgWeek.PrimaryGrid.Columns.Add(this.edit);
            this.sgWeek.PrimaryGrid.Columns.Add(this.del);
            this.sgWeek.Size = new System.Drawing.Size(597, 265);
            this.sgWeek.TabIndex = 0;
            this.sgWeek.Text = "superGridControl1";
            this.sgWeek.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.sgWeek_CellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AllowEdit = false;
            this.gridColumn1.Name = "Week";
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AllowEdit = false;
            this.gridColumn2.Name = "Start Date";
            this.gridColumn2.Width = 110;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AllowEdit = false;
            this.gridColumn3.Name = "End Date";
            this.gridColumn3.Width = 110;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AllowEdit = false;
            this.gridColumn4.Name = "Note";
            this.gridColumn4.Width = 170;
            // 
            // edit
            // 
            this.edit.AllowEdit = false;
            this.edit.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.edit.Name = "";
            this.edit.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.edit.Width = 50;
            // 
            // del
            // 
            this.del.AllowEdit = false;
            this.del.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.del.Name = "";
            this.del.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.del.Width = 50;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.sgWeek);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(12, 217);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(615, 308);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.Text = "List of Week";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btCancelWeek);
            this.groupPanel2.Controls.Add(this.btSaveWeek);
            this.groupPanel2.Controls.Add(this.labelX4);
            this.groupPanel2.Controls.Add(this.labelX3);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Controls.Add(this.txtbxNoteWeek);
            this.groupPanel2.Controls.Add(this.txtbxWeekName);
            this.groupPanel2.Controls.Add(this.dtEndDate);
            this.groupPanel2.Controls.Add(this.dtStartDate);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Location = new System.Drawing.Point(12, 12);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(609, 177);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "Add";
            // 
            // btCancelWeek
            // 
            this.btCancelWeek.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btCancelWeek.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btCancelWeek.Location = new System.Drawing.Point(310, 122);
            this.btCancelWeek.Name = "btCancelWeek";
            this.btCancelWeek.Size = new System.Drawing.Size(75, 23);
            this.btCancelWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btCancelWeek.TabIndex = 9;
            this.btCancelWeek.Text = "Cancel";
            this.btCancelWeek.Click += new System.EventHandler(this.btCancelWeek_Click);
            // 
            // btSaveWeek
            // 
            this.btSaveWeek.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btSaveWeek.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btSaveWeek.Location = new System.Drawing.Point(229, 122);
            this.btSaveWeek.Name = "btSaveWeek";
            this.btSaveWeek.Size = new System.Drawing.Size(75, 23);
            this.btSaveWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btSaveWeek.TabIndex = 8;
            this.btSaveWeek.Text = "Save";
            this.btSaveWeek.Click += new System.EventHandler(this.btSaveWeek_Click);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(128, 93);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "Note";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(128, 65);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "End Date";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(128, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Start Date";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(128, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "Week";
            // 
            // txtbxNoteWeek
            // 
            // 
            // 
            // 
            this.txtbxNoteWeek.Border.Class = "TextBoxBorder";
            this.txtbxNoteWeek.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtbxNoteWeek.Location = new System.Drawing.Point(209, 94);
            this.txtbxNoteWeek.Name = "txtbxNoteWeek";
            this.txtbxNoteWeek.PreventEnterBeep = true;
            this.txtbxNoteWeek.Size = new System.Drawing.Size(267, 22);
            this.txtbxNoteWeek.TabIndex = 3;
            // 
            // txtbxWeekName
            // 
            // 
            // 
            // 
            this.txtbxWeekName.Border.Class = "TextBoxBorder";
            this.txtbxWeekName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtbxWeekName.Location = new System.Drawing.Point(209, 10);
            this.txtbxWeekName.Name = "txtbxWeekName";
            this.txtbxWeekName.PreventEnterBeep = true;
            this.txtbxWeekName.Size = new System.Drawing.Size(267, 22);
            this.txtbxWeekName.TabIndex = 2;
            // 
            // dtEndDate
            // 
            // 
            // 
            // 
            this.dtEndDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtEndDate.ButtonDropDown.Visible = true;
            this.dtEndDate.IsPopupCalendarOpen = false;
            this.dtEndDate.Location = new System.Drawing.Point(209, 66);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtEndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtEndDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndDate.MonthCalendar.DisplayMonth = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtEndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtEndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndDate.MonthCalendar.TodayButtonVisible = true;
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(267, 22);
            this.dtEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtEndDate.TabIndex = 1;
            // 
            // dtStartDate
            // 
            // 
            // 
            // 
            this.dtStartDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtStartDate.ButtonDropDown.Visible = true;
            this.dtStartDate.IsPopupCalendarOpen = false;
            this.dtStartDate.Location = new System.Drawing.Point(209, 38);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStartDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtStartDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStartDate.MonthCalendar.DisplayMonth = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStartDate.MonthCalendar.TodayButtonVisible = true;
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(267, 22);
            this.dtStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtStartDate.TabIndex = 0;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 537);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Week Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgWeek;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn edit;
        private DevComponents.DotNetBar.SuperGrid.GridColumn del;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtbxWeekName;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtEndDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStartDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtbxNoteWeek;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btCancelWeek;
        private DevComponents.DotNetBar.ButtonX btSaveWeek;
    }
}