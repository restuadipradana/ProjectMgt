using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using ProjectMgt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMgt.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            GetWeek();
        }

        private Guid? idw;
        private string saveBtMode;

        private void btSaveWeek_Click(object sender, EventArgs e)
        {
            var collection = DbContext.GetInstance().GetCollection<WeekSetting>();
            if (txtbxWeekName.Text != "" && dtStartDate.Text != "" && dtEndDate.Text != "")
            {
                if (dtStartDate.Value > dtEndDate.Value)
                {
                    MessageBox.Show("Invalid date range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                WeekSetting weekSetting = new WeekSetting()
                {
                    Week = txtbxWeekName.Text,
                    StartDate = dtStartDate.Value,
                    EndDate = dtEndDate.Value,
                    Remark = txtbxNoteWeek.Text,
                    CreatedAt = DateTime.Now
                };
                if (saveBtMode != null)
                {
                    collection.Update(idw, weekSetting);
                    MessageBox.Show("Success to edit " + txtbxWeekName.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupPanel2.Text = "Add";
                    groupPanel2.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Default;
                    idw = null;
                    saveBtMode = null;
                }
                else
                {
                    collection.Insert(weekSetting);
                    MessageBox.Show("Success to add " + txtbxWeekName.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtbxWeekName.Clear();
                txtbxNoteWeek.Clear();
                dtStartDate.ResetValue();
                dtEndDate.ResetValue();
                GetWeek();
            }
            else
            {
                MessageBox.Show("Week, Start Date, and End Date field cannot empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancelWeek_Click(object sender, EventArgs e)
        {
            if (saveBtMode != null)
            {
                groupPanel2.Text = "Add";
                groupPanel2.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Default;
                idw = null;
                saveBtMode = null;
            }
            txtbxWeekName.Clear();
            txtbxNoteWeek.Clear();
            dtStartDate.ResetValue();
            dtEndDate.ResetValue();
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (saveBtMode == null)
            {
                dtEndDate.Value = dtStartDate.Value;
            }
        }
        private void GetWeek()
        {
            var collection = DbContext.GetInstance().GetCollection<WeekSetting>();
            sgWeek.PrimaryGrid.Rows.Clear();

            var weeks = (from a in collection.FindAll().OrderByDescending(d => d.StartDate)
                         select a).ToList();
            foreach (WeekSetting a in weeks)
            {
                GridRow row = new GridRow();
                row.Cells.Add(new GridCell(a.Week));
                row.Cells.Add(new GridCell(a.StartDate.ToShortDateString()));
                row.Cells.Add(new GridCell(a.EndDate.ToShortDateString()));
                row.Cells.Add(new GridCell(a.Remark));
                row.Cells.Add(new GridCell("Edit"));
                row.Cells.Add(new GridCell("Delete"));
                row.Cells.Add(new GridCell(a.id));
                row.Cells[6].Visible = false;
                sgWeek.PrimaryGrid.Rows.Add(row);
            }
        }

        private void EditGrid(Guid id)
        {
            var collection = DbContext.GetInstance().GetCollection<WeekSetting>();
            var item = collection.FindById(id);
            txtbxWeekName.Text = item.Week;
            txtbxNoteWeek.Text = item.Remark;
            dtStartDate.Value = item.StartDate;
            dtEndDate.Value = item.EndDate;
            groupPanel2.Text = "Edit";
            groupPanel2.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Orange;
            //collection.Update(id, xx);
        }

        private void RemoveGrid(Guid id)
        {

            var collection = DbContext.GetInstance().GetCollection<WeekSetting>();
            var item = collection.FindById(id).Week.ToString();

            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete " + item, "Delete Week", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                
                collection.Delete(id);
                GetWeek();
            }
        }

        private void sgWeek_CellClick(object sender, GridCellClickEventArgs e)
        {
            var a = e.GridCell.ColumnIndex;
            var b = e.GridCell.RowIndex;
            var c = Guid.Parse(e.GridPanel.GetCell(b, 6).Value?.ToString());

            switch (a)
            {
                case 4: //edit
                    saveBtMode = "edit";
                    idw = c;
                    EditGrid(c);
                    break;
                case 5: //delete
                    RemoveGrid(c);
                    break;
                default:
                    break;
            }


            
        }
    }
}
