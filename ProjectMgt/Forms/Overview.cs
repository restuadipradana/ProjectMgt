using DevComponents.DotNetBar.SuperGrid;
using OfficeOpenXml;
using ProjectMgt.Helpers;
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
            
            try
            {
                var a = e.GridCell.RowIndex;
                _id = Guid.Parse(e.GridPanel.GetCell(a, 13).Value?.ToString());
                Get3List();
            }
            catch { }
            
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

        private void btSummary_Click(object sender, EventArgs e)
        {
            ProjectSummary projSum = new ProjectSummary();
            projSum.ShowDialog();
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            List<Reports> report = new List<Reports>();
            var projCol = DbContext.GetInstance().GetCollection<ProjectList>();
            var weekCol = DbContext.GetInstance().GetCollection<WeekSetting>();
            var getAll = projCol.FindAll();
            //var getProjBySystem = getAll.GroupBy(x => x.System).Select(a => a.ToList()).ToList(); //-->get project per system
            var getProj = getAll.GroupBy(x => x.System).Select(a => a.Key).ToList();

            var activeWeek = weekCol.Find(x => x.isUpload == true).OrderByDescending(a => a.StartDate).ToList();

            foreach (var week in activeWeek)
            {
                foreach (var proj in getProj)
                {
                    int cnt = getAll.Where(x => x.IdWeek == week.id).Where(x => x.System == proj).Count();
                    report.Add(new Reports() { Week = week.Week, Date = week.StartDate.ToShortDateString() + " ~ " + week.EndDate.ToShortDateString(), System = proj, TotalProject = cnt });
                }
            }
            var reports = report.ToList();

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "Report";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    using (var package = new ExcelPackage())
                    {
                        var workSheet = package.Workbook.Worksheets.Add("Summary");
                        workSheet.Cells["A2"].Value = "Weekly";
                        workSheet.Cells["B2"].Value = "Date";
                        workSheet.Cells["C2"].Value = "System";
                        workSheet.Cells["D2"].Value = "Tot. Proj. per Week"; //當週筆數

                        int row = 3;
                        foreach (var reportx in reports)
                        {
                            workSheet.Cells["A" + row].Value = reportx.Week;
                            workSheet.Cells["B" + row].Value = reportx.Date;
                            workSheet.Cells["C" + row].Value = reportx.System;
                            workSheet.Cells["D" + row].Value = reportx.TotalProject;
                            row++;
                        }
                        workSheet.Cells.AutoFitColumns(0);
                        workSheet.Cells[2, 1, 2, 4].AutoFilter = true;
                        package.SaveAs(myStream);

                    }
                    myStream.Close();
                }
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            var aa = Convert.ToInt32(DateTime.Now.Year);
            Get1List();
            //foreach (WeekRange wr in WkRange.GetWeekRange(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)))
            //{
            //    Console.WriteLine("{0} {1} {2} {3}", wr.WeekNo, wr.MM, wr.Start.Date.ToShortDateString(), wr.End.ToShortDateString());
            //}
            //Console.ReadLine();

            //var stlist = DbContext.GetInstance().GetCollection<StageList>();
            //stlist.Update(Guid.Parse(stlist.Find(x => x.ParentCode == "910").Select(a => a.id).SingleOrDefault().ToString()), new StageList() { Stage = "待討論", StageEN = "To be discussed", Code = "900", ParentCode = "910" });
            // *jgn dipake, hasilnya ngaco, harus di list in semua new stagelist() stlist.Update(Guid.Parse(stlist.Find(x => x.Code == "900").Select(a => a.id).SingleOrDefault().ToString()), new StageList() { ParentCode = "910" });
            //stlist.Delete(x => x.ParentCode == "0");
            //stlist.Insert(new StageList() { Stage = "立案", StageEN = "Register", Code = "000", ParentCode = "0" });
            //stlist.Insert(new StageList() { Stage = "立案 一", StageEN = "Register 1", Code = "001", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "立案 二", StageEN = "Register 2", Code = "002", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "立案 三", StageEN = "Register 3", Code = "003", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "立案 四", StageEN = "Register 4", Code = "004", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "立案 五", StageEN = "Register 5", Code = "005", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "待討論", StageEN = "To be discussed", Code = "900", ParentCode = "0" });
            //stlist.Insert(new StageList() { Stage = "分析", StageEN = "Evaluate", Code = "010", ParentCode = "0" });
            //stlist.Insert(new StageList() { Stage = "分析 一", StageEN = "Evaluate 1", Code = "011", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "分析 二", StageEN = "Evaluate 2", Code = "012", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "分析 三", StageEN = "Evaluate 3", Code = "013", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "分析 四", StageEN = "Evaluate 4", Code = "014", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "分析 五", StageEN = "Evaluate 5", Code = "015", ParentCode = "010" });
            //stlist.Insert(new StageList() { Stage = "規格", StageEN = "Specification", Code = "020", ParentCode = "0" });
            //stlist.Insert(new StageList() { Stage = "規格 一", StageEN = "Specification 1", Code = "021", ParentCode = "020" });
            //stlist.Insert(new StageList() { Stage = "規格 二", StageEN = "Specification 2", Code = "022", ParentCode = "020" });
            //stlist.Insert(new StageList() { Stage = "規格 三", StageEN = "Specification 3", Code = "023", ParentCode = "020" });
            //stlist.Insert(new StageList() { Stage = "規格 四", StageEN = "Specification 4", Code = "024", ParentCode = "020" });
            //stlist.Insert(new StageList() { Stage = "規格 五", StageEN = "Specification 5", Code = "025", ParentCode = "020" });
            //stlist.Insert(new StageList() { Stage = "開發", StageEN = "Development", Code = "030", ParentCode = "0" });
            //stlist.Insert(new StageList() { Stage = "開發 一", StageEN = "Development 1", Code = "031", ParentCode = "030" });
            //stlist.Insert(new StageList() { Stage = "開發 二", StageEN = "Development 2", Code = "032", ParentCode = "030" });
            //stlist.Insert(new StageList() { Stage = "開發 三", StageEN = "Development 3", Code = "033", ParentCode = "030" });
            //stlist.Insert(new StageList() { Stage = "開發 四", StageEN = "Development 4", Code = "034", ParentCode = "030" });
            //stlist.Insert(new StageList() { Stage = "開發 五", StageEN = "Development 5", Code = "035", ParentCode = "030" });
            //stlist.Insert(new StageList() { Stage = "測試", StageEN = "Testing", Code = "040", ParentCode = "0" });
            //stlist.Insert(new StageList() { Stage = "測試 一", StageEN = "Testing 1", Code = "041", ParentCode = "040" });
            //stlist.Insert(new StageList() { Stage = "測試 二", StageEN = "Testing 2", Code = "042", ParentCode = "040" });
            //stlist.Insert(new StageList() { Stage = "測試 三", StageEN = "Testing 3", Code = "043", ParentCode = "040" });
            //stlist.Insert(new StageList() { Stage = "測試 四", StageEN = "Testing 4", Code = "044", ParentCode = "040" });
            //stlist.Insert(new StageList() { Stage = "測試 五", StageEN = "Testing 5", Code = "045", ParentCode = "040" });
            //stlist.Insert(new StageList() { Stage = "上線", StageEN = "GoLive", Code = "050", ParentCode = "0" });
            //stlist.Insert(new StageList() { Stage = "上線 一", StageEN = "GoLiveg 1", Code = "051", ParentCode = "050" });
            //stlist.Insert(new StageList() { Stage = "上線 二", StageEN = "GoLiveg 2", Code = "052", ParentCode = "050" });
            //stlist.Insert(new StageList() { Stage = "上線 三", StageEN = "GoLiveg 3", Code = "053", ParentCode = "050" });
            //stlist.Insert(new StageList() { Stage = "上線 四", StageEN = "GoLiveg 4", Code = "054", ParentCode = "050" });
            //stlist.Insert(new StageList() { Stage = "上線 五", StageEN = "GoLiveg 5", Code = "055", ParentCode = "050" });

        }

        private void sgL2_MouseClick(object sender, MouseEventArgs e)
        {
            var sss = sgL2.GetElementAt(new Point(e.X, e.Y));
            var ass = sss.Parent;
            
            
            if (e.Button == MouseButtons.Right && ass != null)
            {
                var ridx = sss.GridPanel.ActiveRow.RowIndex;
                var idcell = sss.GridPanel.GetCell(ridx, 13).Value?.ToString();
                _id = Guid.Parse(idcell);
                var m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Add new field", (o, args) => new Add(idcell).ShowDialog(this)));
                m.MenuItems.Add(new MenuItem("Add", add_rowL2));
                m.Show(sgL2, new Point(e.X, e.Y));
            }




            ////var sad = sss.SuperGrid.GetCell;
            //GridCell gc = new GridCell();
            //gc = sss.SuperGrid.ActiveCell;
            //int a = Convert.ToInt32(gc.RowIndex);
            //GridCellClickEventArgs gce = new GridCellClickEventArgs(sss.GridPanel, gc, e);
            //var st = gce.GridPanel.RowIndex;
            //var ss = gce.GridPanel.GetCell(a, 13).Value?.ToString();

            //GridCellEventArgs gc = new GridCellEventArgs(sss.GridPanel, ass.GridPanel.GetCell);



        }



        //--------

        public void add_rowL2(object sender, EventArgs e)
        {
            Console.WriteLine("Clickdetdks Completed!");
            var dt = DateTime.Now;
            var projCol = DbContext.GetInstance().GetCollection<ProjectList>();
            var colweek = DbContext.GetInstance().GetCollection<WeekSetting>();
            var l2 = projCol.FindById(_id);
            var week = colweek.Find(x => x.StartDate <= dt && x.EndDate >= dt).SingleOrDefault();

            GridRow row = new GridRow();
            row.Cells.Add(new GridCell(l2.Applicant));
            row.Cells.Add(new GridCell(l2.PIC));
            row.Cells.Add(new GridCell(l2.ReqFormNo));
            row.Cells.Add(new GridCell(l2.ReqFormDesc));
            row.Cells.Add(new GridCell(l2.Stage));
            row.Cells.Add(new GridCell(""));
            row.Cells.Add(new GridCell(""));
            row.Cells.Add(new GridCell(""));
            row.Cells.Add(new GridCell(""));
            row.Cells.Add(new GridCell(""));
            row.Cells.Add(new GridCell(""));
            row.Cells.Add(new GridCell(week.Week));
            row.Cells.Add(new GridCell(dt.ToString()));
            row.Cells.Add(new GridCell(""));
            row.RowHeight = 0;
            row.Cells[0].AllowEdit = true;
            row.Cells[1].AllowEdit = true;
            row.Cells[2].AllowEdit = false;
            row.Cells[3].AllowEdit = false;
            row.Cells[4].AllowEdit = true;
            row.Cells[5].AllowEdit = true;
            row.Cells[6].AllowEdit = true;
            row.Cells[7].AllowEdit = true;
            row.Cells[8].AllowEdit = true;
            row.Cells[9].AllowEdit = true;
            row.Cells[10].AllowEdit = true;
            row.Cells[11].AllowEdit = true;
            row.Cells[12].AllowEdit = true;
            sgL2.PrimaryGrid.Rows.Add(row);
        }
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

        public void Get1List()
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

    public class Reports
    {
        public string Week { get; set; }
        public string Date { get; set; }
        public string System { get; set; }
        public int TotalProject { get; set; }
    }
}
