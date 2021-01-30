using DevComponents.DotNetBar.SuperGrid;
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
    public partial class ProjectSummary : Form
    {
        public ProjectSummary()
        {
            InitializeComponent();
        }

        private Guid? idw;
        private int lv;

        private void GetList()
        {
            lv = 0;
            var collection = DbContext.GetInstance().GetCollection<WeekSetting>();
            sgProjSum.PrimaryGrid.Rows.Clear();

            var weeks = (from a in collection.Find(x => x.isUpload == true).OrderByDescending(d => d.StartDate)
                         select a).ToList();
            foreach (WeekSetting a in weeks)
            {
                GridRow row = new GridRow();
                row.Cells.Add(new GridCell(a.Week));
                row.Cells.Add(new GridCell("Delete"));
                row.Cells.Add(new GridCell(a.id));
                row.Cells[2].Visible = false;
                sgProjSum.PrimaryGrid.Rows.Add(row);
            }
        }

        private void ProjectSummary_Load(object sender, EventArgs e)
        {
            GetList();
            sgListUpload.Visible = false;
        }

        private void sgProjSum_CellClick(object sender, GridCellClickEventArgs e)
        {
            var projColl = DbContext.GetInstance().GetCollection<ProjectList>();
            var weekColl = DbContext.GetInstance().GetCollection<WeekSetting>();
            var a = e.GridCell.RowIndex;
            var b = e.GridCell.ColumnIndex;
            if (b == 1)
            {
                idw = Guid.Parse(e.GridPanel.GetCell(a, 2).Value?.ToString());
                DialogResult dr = MessageBox.Show("Are you sure to delete " + e.GridPanel.GetCell(a, 0).Value.ToString() + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    projColl.Delete(x => x.IdWeek == idw);
                    var wsid = weekColl.FindById(idw);
                    wsid.isUpload = false; //get week available to upload
                    weekColl.Update(idw, wsid);
                    GetList();
                    //do something
                }
                else if (dr == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                idw = Guid.Parse(e.GridPanel.GetCell(a, 2).Value?.ToString());
                GetListUpload();
            }
            
        }

        private void GetListUpload()
        {
            lv = 1;
            var projColl = DbContext.GetInstance().GetCollection<ProjectList>();
            var weekColl = DbContext.GetInstance().GetCollection<WeekSetting>();
            sgProjSum.Visible = false;
            sgListUpload.Visible = true;
            var lists = projColl.Find(x => x.IdWeek == idw).ToList();
            var no = 0;
            foreach (var list in lists)
            {
                no++;
                GridRow row = new GridRow();
                DateTime dt;
                row.Cells.Add(new GridCell(no));
                row.Cells.Add(new GridCell(list.System));
                row.Cells.Add(new GridCell(list.ErrKind));
                row.Cells.Add(new GridCell(list.Desc));
                row.Cells.Add(new GridCell(list.Applicant));
                row.Cells.Add(new GridCell(list.PIC));
                row.Cells.Add(new GridCell(list.ReqFormNo));
                row.Cells.Add(new GridCell(list.ReqFormDesc));
                row.Cells.Add(new GridCell(list.Stage));
                row.Cells.Add(new GridCell(DateTime.TryParse(list.UserExpectedDate, out dt) ? Convert.ToDateTime(list.UserExpectedDate).ToString("MM/dd/yyyy") : list.UserExpectedDate));
                row.Cells.Add(new GridCell(DateTime.TryParse(list.StageEstimateFinish, out dt) ? Convert.ToDateTime(list.StageEstimateFinish).ToString("MM/dd/yyyy") : list.StageEstimateFinish));
                row.Cells.Add(new GridCell(DateTime.TryParse(list.StageActualFinish, out dt) ? Convert.ToDateTime(list.StageActualFinish).ToString("MM/dd/yyyy") : list.StageActualFinish));
                row.Cells.Add(new GridCell(DateTime.TryParse(list.TestDateEstimate, out dt) ? Convert.ToDateTime(list.TestDateEstimate).ToString("MM/dd/yyyy") : list.TestDateEstimate));
                row.Cells.Add(new GridCell(DateTime.TryParse(list.ApplyDate, out dt) ? Convert.ToDateTime(list.ApplyDate).ToString("MM/dd/yyyy") : list.ApplyDate));
                row.Cells.Add(new GridCell(list.Memo));
                row.Cells.Add(new GridCell(list.CreatedAt));
                row.Cells.Add(new GridCell(list.id));
                row.Cells[16].Visible = false;
                row.RowHeight = 0;
                sgListUpload.PrimaryGrid.Rows.Add(row);
            }
            sgListUpload.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;

        }

        private void btBack_Click(object sender, EventArgs e)
        {
            switch (lv)
            {
                case 0:
                    this.Close();
                    break;
                case 1:
                    sgListUpload.Visible = false;
                    GetList();
                    sgProjSum.Visible = true;
                    sgListUpload.PrimaryGrid.Rows.Clear();
                    break;
                default:
                    break;
            }
            
        }
    }
}
