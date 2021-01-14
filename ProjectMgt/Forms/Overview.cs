using DevComponents.DotNetBar.SuperGrid;
using OfficeOpenXml;
using ProjectMgt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMgt.Forms
{
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
        }

        private Guid _id;
        private int level;

        private void btUploadDialog_Click(object sender, EventArgs e)
        {
            Upload upload = new Upload();
            upload.ShowDialog();
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void Overview_Load(object sender, EventArgs e)
        {
            Get1List();
        }

        private void sgL1_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            var a = e.GridCell.RowIndex;
            _id = Guid.Parse(e.GridPanel.GetCell(a, 4).Value?.ToString());
            Get2List();
        }

        private void sgL2_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            var a = e.GridCell.RowIndex;
            _id = Guid.Parse(e.GridPanel.GetCell(a, 13).Value?.ToString());
            Get3List();
        }

        private void tabL2_Click(object sender, EventArgs e)
        {
            tabL3.Visible = false;
            superTabControl1.SelectedTabIndex = 1;
            level = 2;
        }

        private void tabL1_Click(object sender, EventArgs e)
        {
            tabL3.Visible = false;
            tabL2.Visible = false;
            superTabControl1.SelectedTabIndex = 0;
            level = 1;
            
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Get1List();
        }


        //--------

        private List<ProjectList> GetAll(int a)
        {
            var list = new List<ProjectList>();

            var col = DbContext.GetInstance().GetCollection<ProjectList>();
            //select * from K_tbl where CreatedAt in (select max(CreatedAt) from K_tbl group by ReqFormNo, ReqFormDesc, Stage)

            List<DateTime> awx = new List<DateTime>();

            if (a == 1) //L1
            {
                awx = (from x in col.FindAll().OrderByDescending(d => d.CreatedAt)
                       group x by new { x.ReqFormNo, x.ReqFormDesc }
                        into xx
                       select xx.Max(m => m.CreatedAt)
                        ).ToList();
            }
            else if (a == 2) //L2
            {
                awx = (from x in col.FindAll().OrderByDescending(d => d.CreatedAt)
                       group x by new { x.ReqFormNo, x.ReqFormDesc, x.Stage }
                        into xx
                       select xx.Max(m => m.CreatedAt)
                        ).ToList();
            }

            var detx = from x in col.FindAll().OrderByDescending(d => d.ReqFormNo)
                       where awx.Contains(x.CreatedAt)
                       select x;


            foreach (ProjectList _id in detx)
            {
                DateTime dt;
                _id.ApplyDate = DateTime.TryParse(_id.ApplyDate, out dt) ? Convert.ToDateTime(_id.ApplyDate).ToString("MM/dd/yyyy") : _id.ApplyDate;
                _id.TestDateEstimate = DateTime.TryParse(_id.TestDateEstimate, out dt) ? Convert.ToDateTime(_id.TestDateEstimate).ToString("MM/dd/yyyy") : _id.TestDateEstimate;
                _id.StageActualFinish = DateTime.TryParse(_id.StageActualFinish, out dt) ? Convert.ToDateTime(_id.StageActualFinish).ToString("MM/dd/yyyy") : _id.StageActualFinish;
                _id.StageEstimateFinish = DateTime.TryParse(_id.StageEstimateFinish, out dt) ? Convert.ToDateTime(_id.StageEstimateFinish).ToString("MM/dd/yyyy") : _id.StageEstimateFinish;
                _id.UserExpectedDate = DateTime.TryParse(_id.UserExpectedDate, out dt) ? Convert.ToDateTime(_id.UserExpectedDate).ToString("MM/dd/yyyy") : _id.UserExpectedDate;
                list.Add(_id);
            }

            return list;
        }

        private List<L1list> GetL1Data()
        {
            var list = new List<L1list>();
            var all = GetAll(1);

            foreach (var idx in all)
            {
                L1list l1 = new L1list()
                {
                    _id = idx.id,
                    Applicant = idx.Applicant,
                    ITPIC = idx.PIC,
                    RequestFrom = idx.ReqFormNo,
                    Description = idx.ReqFormDesc
                };
                list.Add(l1);
            }

            return list;
        }

        private void Get1List()
        {
            sgL1.PrimaryGrid.Rows.Clear();
            tabL2.Visible = false;
            tabL3.Visible = false;
            foreach (L1list cell in GetL1Data())
            {
                GridRow row = new GridRow();
                row.Cells.Add(new GridCell(cell.Applicant));
                row.Cells.Add(new GridCell(cell.ITPIC));
                row.Cells.Add(new GridCell(cell.RequestFrom));
                row.Cells.Add(new GridCell(cell.Description));
                row.Cells.Add(new GridCell(cell._id));
                row.RowHeight = 0;
                sgL1.PrimaryGrid.Rows.Add(row);

            }
            sgL1.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            level = 1;
        }

        private void Get2List() //L2
        {
            sgL2.PrimaryGrid.Rows.Clear();
            tabL2.Visible = true;
            tabL3.Visible = false;
            superTabControl1.SelectedTabIndex = 1;
            var col = DbContext.GetInstance().GetCollection<ProjectList>();
            var colweek = DbContext.GetInstance().GetCollection<WeekSetting>();
            var selected = col.FindById(_id);
            var groupL2 = (from b in GetAll(2)
                      where b.ReqFormDesc == selected.ReqFormDesc && b.ReqFormNo == selected.ReqFormNo
                      select b).ToList();
            var weeks = colweek.FindAll().ToList();

            var items = (from c in groupL2
                          join d in weeks on c.IdWeek equals d.id 
                          select new {c.Applicant, c.PIC, c.ReqFormNo, c.ReqFormDesc, c.Stage, c.UserExpectedDate, c.StageEstimateFinish, c.StageActualFinish, c.TestDateEstimate,
                          c.ApplyDate, c.Memo, c.CreatedAt, c.id, d.Week }).ToArray();
            tabL2.Text = selected.ReqFormNo + " - " + (selected.ReqFormDesc.Length > 20 ? Regex.Replace(selected.ReqFormDesc.Substring(0, 20), @"\t|\n|\r", " ") : selected.ReqFormDesc);
            foreach (var l2 in items)
            {
                GridRow row = new GridRow();
                row.Cells.Add(new GridCell(l2.Applicant));
                row.Cells.Add(new GridCell(l2.PIC));
                row.Cells.Add(new GridCell(l2.ReqFormNo));
                row.Cells.Add(new GridCell(l2.ReqFormDesc));
                row.Cells.Add(new GridCell(l2.Stage));
                row.Cells.Add(new GridCell(l2.UserExpectedDate));
                row.Cells.Add(new GridCell(l2.StageEstimateFinish));
                row.Cells.Add(new GridCell(l2.StageActualFinish));
                row.Cells.Add(new GridCell(l2.TestDateEstimate));
                row.Cells.Add(new GridCell(l2.ApplyDate));
                row.Cells.Add(new GridCell(l2.Memo));
                row.Cells.Add(new GridCell(l2.Week));
                row.Cells.Add(new GridCell(l2.CreatedAt));
                row.Cells.Add(new GridCell(l2.id));
                row.RowHeight = 0;
                sgL2.PrimaryGrid.Rows.Add(row);
                row.Cells[0].AllowEdit = false;
                row.Cells[1].AllowEdit = false;
                row.Cells[2].AllowEdit = false;
                row.Cells[3].AllowEdit = false;
                row.Cells[4].AllowEdit = false;
                row.Cells[5].AllowEdit = false;
                row.Cells[6].AllowEdit = false;
                row.Cells[7].AllowEdit = false;
                row.Cells[8].AllowEdit = false;
                row.Cells[9].AllowEdit = false;
                row.Cells[10].AllowEdit = false;
                row.Cells[11].AllowEdit = false;
                row.Cells[12].AllowEdit = false;
            }
            sgL2.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            level = 2;
        }

        private void Get3List() //L3
        {
            sgL3.PrimaryGrid.Rows.Clear();
            tabL3.Visible = true;
            superTabControl1.SelectedTabIndex = 2;
            var col = DbContext.GetInstance().GetCollection<ProjectList>();
            var colweek = DbContext.GetInstance().GetCollection<WeekSetting>();
            var selected = col.FindById(_id);
            var groupL3 = col.Find(z => z.Stage == selected.Stage)
                .Where(x => x.ReqFormNo == selected.ReqFormNo)
                .Where(x => x.ReqFormDesc == selected.ReqFormDesc)
                .OrderByDescending(y => y.CreatedAt).ToList();
            var weeks = colweek.FindAll().ToList();
            var items = (from c in groupL3
                         join d in weeks on c.IdWeek equals d.id
                         select new
                         {
                             c.Applicant,
                             c.PIC,
                             c.ReqFormNo,
                             c.ReqFormDesc,
                             c.Stage,
                             c.UserExpectedDate,
                             c.StageEstimateFinish,
                             c.StageActualFinish,
                             c.TestDateEstimate,
                             c.ApplyDate,
                             c.Memo,
                             c.CreatedAt,
                             c.id,
                             d.Week
                         }).ToArray();
            foreach (var l3 in items)
            {
                GridRow row = new GridRow();
                DateTime dt;
                row.Cells.Add(new GridCell(l3.Applicant));
                row.Cells.Add(new GridCell(l3.PIC));
                row.Cells.Add(new GridCell(l3.ReqFormNo));
                row.Cells.Add(new GridCell(l3.ReqFormDesc));
                row.Cells.Add(new GridCell(l3.Stage));
                row.Cells.Add(new GridCell(DateTime.TryParse(l3.UserExpectedDate, out dt) ? Convert.ToDateTime(l3.UserExpectedDate).ToString("MM/dd/yyyy") : l3.UserExpectedDate));
                row.Cells.Add(new GridCell(DateTime.TryParse(l3.StageEstimateFinish, out dt) ? Convert.ToDateTime(l3.StageEstimateFinish).ToString("MM/dd/yyyy") : l3.StageEstimateFinish));
                row.Cells.Add(new GridCell(DateTime.TryParse(l3.StageActualFinish, out dt) ? Convert.ToDateTime(l3.StageActualFinish).ToString("MM/dd/yyyy") : l3.StageActualFinish));
                row.Cells.Add(new GridCell(DateTime.TryParse(l3.TestDateEstimate, out dt) ? Convert.ToDateTime(l3.TestDateEstimate).ToString("MM/dd/yyyy") : l3.TestDateEstimate));
                row.Cells.Add(new GridCell(DateTime.TryParse(l3.ApplyDate, out dt) ? Convert.ToDateTime(l3.ApplyDate).ToString("MM/dd/yyyy") : l3.ApplyDate));
                row.Cells.Add(new GridCell(l3.Memo));
                row.Cells.Add(new GridCell(l3.Week));
                row.Cells.Add(new GridCell(l3.CreatedAt));
                row.Cells.Add(new GridCell(l3.id));
                row.RowHeight = 0;
                sgL3.PrimaryGrid.Rows.Add(row);
                row.Cells[0].AllowEdit = false;
                row.Cells[1].AllowEdit = false;
                row.Cells[2].AllowEdit = false;
                row.Cells[3].AllowEdit = false;
                row.Cells[4].AllowEdit = false;
                row.Cells[5].AllowEdit = false;
                row.Cells[6].AllowEdit = false;
                row.Cells[7].AllowEdit = false;
                row.Cells[8].AllowEdit = false;
                row.Cells[9].AllowEdit = false;
                row.Cells[10].AllowEdit = false;
                row.Cells[11].AllowEdit = false;
                row.Cells[12].AllowEdit = false;
            }
            sgL3.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            tabL3.Text = selected.Stage;
            level = 3;
        }

        
    }
    public class L1list
    {
        public Guid _id { get; set; }
        public string Applicant { get; set; }
        public string ITPIC { get; set; }
        public string RequestFrom { get; set; }
        public string Description { get; set; }
    }
}
