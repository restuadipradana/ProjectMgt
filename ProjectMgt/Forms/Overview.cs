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
            CheckListStage();
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
            GetReport();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            TestArea();
            switch (level)
            {
                case 1:
                    Get1List();
                    break;
                case 2:
                    Get2List();
                    break;
                case 3:
                    Get3List();
                    break;
                default:
                    break;
            }
        }

        //Klik kanan di L2
        private void sgL2_MouseClick(object sender, MouseEventArgs e) 
        {
            var sss = sgL2.GetElementAt(new Point(e.X, e.Y));
            var ass = sss.Parent;
            
            if (e.Button == MouseButtons.Right && ass != null)
            {
                sss.GridPanel.CopySelectedCellsToClipboard();
                var ridx = sss.GridPanel.ActiveRow.RowIndex;
                var idcell = sss.GridPanel.GetCell(ridx, 13).Value?.ToString();
                _id = Guid.Parse(idcell);
                var m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("&Copy", add_rowL2));
                m.MenuItems.Add(new MenuItem("&Add new", (o, args) => new Add(idcell, 1).ShowDialog(this)));
                if (sss.GridPanel.GetCell(ridx, 14).Value?.ToString() == "userinput")
                {
                    m.MenuItems.Add(new MenuItem("Edit / Delete", (o, args) => new Add(idcell, 2).ShowDialog(this))); //2 buat edit yang user input manual
                }
                m.Show(sgL2, new Point(e.X, e.Y));
            }

        }



        //----------------fun------------------

        //unused
        public void add_rowL2(object sender, EventArgs e)
        {
            Console.WriteLine("Copied!");
            //var dt = DateTime.Now;
            //var projCol = DbContext.GetInstance().GetCollection<ProjectList>();
            //var colweek = DbContext.GetInstance().GetCollection<WeekSetting>();
            //var l2 = projCol.FindById(_id);
            //var week = colweek.Find(x => x.StartDate <= dt && x.EndDate >= dt).SingleOrDefault();
            //
            //GridRow row = new GridRow();
            //row.Cells.Add(new GridCell(l2.Applicant));
            //row.Cells.Add(new GridCell(l2.PIC));
            //row.Cells.Add(new GridCell(l2.ReqFormNo));
            //row.Cells.Add(new GridCell(l2.ReqFormDesc));
            //row.Cells.Add(new GridCell(l2.Stage));
            //row.Cells.Add(new GridCell(""));
            //row.Cells.Add(new GridCell(""));
            //row.Cells.Add(new GridCell(""));
            //row.Cells.Add(new GridCell(""));
            //row.Cells.Add(new GridCell(""));
            //row.Cells.Add(new GridCell(""));
            //row.Cells.Add(new GridCell(week.Week));
            //row.Cells.Add(new GridCell(dt.ToString()));
            //row.Cells.Add(new GridCell(""));
            //row.RowHeight = 0;
            //row.Cells[0].AllowEdit = true;
            //row.Cells[1].AllowEdit = true;
            //row.Cells[2].AllowEdit = false;
            //row.Cells[3].AllowEdit = false;
            //row.Cells[4].AllowEdit = true;
            //row.Cells[5].AllowEdit = true;
            //row.Cells[6].AllowEdit = true;
            //row.Cells[7].AllowEdit = true;
            //row.Cells[8].AllowEdit = true;
            //row.Cells[9].AllowEdit = true;
            //row.Cells[10].AllowEdit = true;
            //row.Cells[11].AllowEdit = true;
            //row.Cells[12].AllowEdit = true;
            //sgL2.PrimaryGrid.Rows.Add(row);
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

        public void Get2List() //L2
        {
            sgL2.PrimaryGrid.Rows.Clear();
            tabL2.Visible = true;
            tabL3.Visible = false;
            superTabControl1.SelectedTabIndex = 1;
            var col = DbContext.GetInstance().GetCollection<ProjectList>();
            var colweek = DbContext.GetInstance().GetCollection<WeekSetting>();
            try //pake try menghindari L2 yang sudah dihapus muncul sebagai _id di L1 sehingga selected tdk muncul, catch refresh L1 
            {
                var selected = col.FindById(_id);
                var groupL2 = (from b in GetAll(2)
                               where b.ReqFormDesc == selected.ReqFormDesc && b.ReqFormNo == selected.ReqFormNo
                               select b).ToList();
                var weeks = colweek.FindAll().ToList();

                var items = (from c in groupL2
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
                                 d.Week,
                                 c.FileName
                             }).OrderByDescending(x => x.CreatedAt).ToArray();
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
                    row.Cells.Add(new GridCell(l2.FileName));
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
            catch
            {
                Get1List();
            }
            
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

        private void GetReport()
        {
            List<Reports> report = new List<Reports>();
            var projCol = DbContext.GetInstance().GetCollection<ProjectList>();
            var weekCol = DbContext.GetInstance().GetCollection<WeekSetting>();
            var getAll = projCol.FindAll();
            //var getProjBySystem = getAll.GroupBy(x => x.System).Select(a => a.ToList()).ToList(); //-->get project per system
            var getProj = getAll.GroupBy(x => x.System).Select(a => a.Key).ToList();
            var currentDt = DateTime.Now.Date;
            //var activeWeek = weekCol.Find(x => x.isUpload == true).OrderBy(a => a.StartDate).ToList();
            var activeWeek = weekCol.FindAll().OrderBy(a => a.StartDate).ToList();

            foreach (var week in activeWeek) //per week
            {
                foreach (var proj in getProj) //per project
                {
                    var xPorj = getAll.Where(x => x.IdWeek == week.id).Where(x => x.System == proj); //list project per week n sistem
                    int? cntProj = xPorj.Count();
                    int cp = xPorj.Count();
                    DateTime dt;
                    DateTime getUED;
                    DateTime getApplyDate;
                    int? cntErrA = 0;
                    int? cntErrB = 0;
                    int? cntErrC = 0;
                    int? errTot = 0;
                    

                    foreach (var eproj in xPorj) //hitung error
                    {
                        //get error A
                        if (DateTime.TryParse(eproj.ApplyDate, out dt))
                        {
                            getApplyDate = Convert.ToDateTime(eproj.ApplyDate);
                            if (DateTime.TryParse(eproj.TestDateEstimate, out dt)) //kolom test date & apply date ada, cek test date lebih dari 2 minggu sejak apply date
                            {
                                getUED = Convert.ToDateTime(eproj.TestDateEstimate);
                                if ((getUED - getApplyDate).TotalDays > 14)
                                {
                                    cntErrA++;
                                }
                            }
                            else if ((currentDt - getApplyDate).TotalDays > 14) // kolom test date kosong tapi ada apply date, cek apply date lebih dr 2 minggu
                            {
                                cntErrA++;
                            }
                        }
                        else //kolom apply date kosong
                        {
                            cntErrA++;
                        }


                        //get error b
                        if (DateTime.TryParse(eproj.StageActualFinish, out dt))
                        {
                            cntErrB++;
                        }


                        //get error c
                        var projSelected = projCol.Find(x => x.ReqFormNo == eproj.ReqFormNo && x.ReqFormDesc == eproj.ReqFormDesc).ToList(); // find from xProj, where xProj.week < week foreach
                        var listTestDate = (from a in projSelected join b in activeWeek on a.IdWeek equals b.id where b.StartDate <= week.StartDate orderby b.StartDate ascending select new { TestDate = a.TestDateEstimate, b.Week }).ToList();
                        DateTime dt1 = new DateTime(2020, 1, 1);
                        DateTime dt2 = new DateTime(2020, 1, 1);
                        DateTime dtc;
                        int flag = 0;
                        int cntChg = 0; // hitung perubahan date 

                        foreach (var kk in listTestDate) // value pertama dt1 dt2 dari testdate pertama
                        {
                            if (DateTime.TryParse(kk.TestDate, out dtc))
                            {
                                dt1 = dtc;
                                dt2 = dtc;
                                break;
                            }
                        }

                        foreach (var jj in listTestDate)
                        {
                            flag++;
                            if (DateTime.TryParse(jj.TestDate, out dtc)) //kolom test date & apply date ada, cek test date lebih dari 2 minggu sejak apply date
                            {
                                if (flag % 2 == 0) //loop genap
                                {
                                    dt2 = dtc;
                                }
                                else
                                {
                                    dt1 = dtc;
                                }
                            }
                            int isChg = DateTime.Compare(dt1, dt2); // 0 : gaada perubahan
                            if (isChg != 0)
                            {
                                cntChg++;
                            }
                        }
                        if (cntChg >= 3)
                        {
                            cntErrC++;
                        }



                    }
                    cntProj = cntProj == 0 ? null : cntProj;
                    errTot = cntErrA + cntErrB + cntErrC;
                    cntErrA = cntErrA == 0 ? null : cntErrA;
                    cntErrB = cntErrB == 0 ? null : cntErrB;
                    cntErrC = cntErrC == 0 ? null : cntErrC;
                    errTot = errTot == 0 ? null : errTot;

                    if (cp != 0)
                    {
                        report.Add(new Reports() { Week = week.Week, Date = week.StartDate.ToShortDateString() + " ~ " + week.EndDate.ToShortDateString(), System = proj, TotalProject = cntProj, TotalError = errTot, TotalErrorA = cntErrA, TotalErrorB = cntErrB, TotalErrorC = cntErrC });
                    }

                    
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
                        workSheet.Cells["D2"].Value = "當週筆數"; //當週筆數 Tot. Proj. per Week
                        workSheet.Cells["E2"].Value = "錯誤筆數"; //錯誤筆數 Total Error
                        workSheet.Cells["F2"].Value = "A.(進度)"; // A.(進度) Error A
                        workSheet.Cells["G2"].Value = "B.(資料)"; // B.(資料) Error B
                        workSheet.Cells["H2"].Value = "C.(格式)"; // C.(格式) Error C
                        workSheet.Cells["I2"].Value = "D.(更改)"; // D.(更改) Error D

                        int row = 3;
                        foreach (var reportx in reports)
                        {
                            workSheet.Cells["A" + row].Value = reportx.Week;
                            workSheet.Cells["B" + row].Value = reportx.Date;
                            workSheet.Cells["C" + row].Value = reportx.System;
                            workSheet.Cells["D" + row].Value = reportx.TotalProject;
                            workSheet.Cells["E" + row].Value = reportx.TotalError;
                            workSheet.Cells["F" + row].Value = reportx.TotalErrorA;
                            workSheet.Cells["G" + row].Value = reportx.TotalErrorB;
                            workSheet.Cells["H" + row].Value = reportx.TotalErrorC;
                            row++;
                        }
                        workSheet.Cells["C" + row].Value = "Total";
                        workSheet.Cells["D" + row].Formula = "SUM(D3:D" + (row - 1) + ")";
                        workSheet.Cells["F" + row].Formula = "SUM(F3:F" + (row - 1) + ")";
                        workSheet.Cells["G" + row].Formula = "SUM(G3:G" + (row - 1) + ")";
                        workSheet.Cells["H" + row].Formula = "SUM(H3:H" + (row - 1) + ")";
                        workSheet.Cells["I" + row].Formula = "SUM(I3:I" + (row - 1) + ")";
                        workSheet.Cells["E" + row].Formula = "SUM(F" + row + ":I" + row + ")";
                        workSheet.Cells[row, 3, row, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        workSheet.Cells[row, 3, row, 9].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

                        workSheet.Cells["F" + (row + 1)].Formula = "F" + row + "/E" + row;
                        workSheet.Cells["G" + (row + 1)].Formula = "G" + row + "/E" + row;
                        workSheet.Cells["H" + (row + 1)].Formula = "H" + row + "/E" + row;
                        workSheet.Cells["I" + (row + 1)].Formula = "I" + row + "/E" + row;
                        workSheet.Cells["E" + (row + 1)].Formula = "SUM(F" + (row + 1) + ":I" + (row + 1) + ")";
                        workSheet.Cells[(row + 1), 5, (row + 1), 9].Style.Numberformat.Format = "0%";
                        
                        workSheet.Cells.AutoFitColumns(0);
                        workSheet.Cells[2, 1, 2, 3].AutoFilter = true;
                        workSheet.View.FreezePanes(3, 4);
                        package.SaveAs(myStream);

                    }
                    myStream.Close();
                }
            }
        }

        private void CheckListStage()
        {
            var stageColl = DbContext.GetInstance().GetCollection<StageList>();
            var d = stageColl.FindAll().ToList();
            var stgLst = new List<StageList>() {
                new StageList() { Stage = "立案", StageEN = "Register", Code = "000", ParentCode = "0" },
                new StageList() { Stage = "立案 一", StageEN = "Register 1", Code = "001", ParentCode = "010" },
                new StageList() { Stage = "立案 二", StageEN = "Register 2", Code = "002", ParentCode = "010" },
                new StageList() { Stage = "立案 三", StageEN = "Register 3", Code = "003", ParentCode = "010" },
                new StageList() { Stage = "立案 四", StageEN = "Register 4", Code = "004", ParentCode = "010" },
                new StageList() { Stage = "立案 五", StageEN = "Register 5", Code = "005", ParentCode = "010" },
                new StageList() { Stage = "分析", StageEN = "Evaluate", Code = "010", ParentCode = "0" },
                new StageList() { Stage = "分析 一", StageEN = "Evaluate 1", Code = "011", ParentCode = "010" },
                new StageList() { Stage = "分析 二", StageEN = "Evaluate 2", Code = "012", ParentCode = "010" },
                new StageList() { Stage = "分析 三", StageEN = "Evaluate 3", Code = "013", ParentCode = "010" },
                new StageList() { Stage = "分析 四", StageEN = "Evaluate 4", Code = "014", ParentCode = "010" },
                new StageList() { Stage = "分析 五", StageEN = "Evaluate 5", Code = "015", ParentCode = "010" },
                new StageList() { Stage = "規格", StageEN = "Specification", Code = "020", ParentCode = "0" },
                new StageList() { Stage = "規格 一", StageEN = "Specification 1", Code = "021", ParentCode = "020" },
                new StageList() { Stage = "規格 二", StageEN = "Specification 2", Code = "022", ParentCode = "020" },
                new StageList() { Stage = "規格 三", StageEN = "Specification 3", Code = "023", ParentCode = "020" },
                new StageList() { Stage = "規格 四", StageEN = "Specification 4", Code = "024", ParentCode = "020" },
                new StageList() { Stage = "規格 五", StageEN = "Specification 5", Code = "025", ParentCode = "020" },
                new StageList() { Stage = "開發", StageEN = "Development", Code = "030", ParentCode = "0" },
                new StageList() { Stage = "開發 一", StageEN = "Development 1", Code = "031", ParentCode = "030" },
                new StageList() { Stage = "開發 二", StageEN = "Development 2", Code = "032", ParentCode = "030" },
                new StageList() { Stage = "開發 三", StageEN = "Development 3", Code = "033", ParentCode = "030" },
                new StageList() { Stage = "開發 四", StageEN = "Development 4", Code = "034", ParentCode = "030" },
                new StageList() { Stage = "開發 五", StageEN = "Development 5", Code = "035", ParentCode = "030" },
                new StageList() { Stage = "測試", StageEN = "Testing", Code = "040", ParentCode = "0" },
                new StageList() { Stage = "測試 一", StageEN = "Testing 1", Code = "041", ParentCode = "040" },
                new StageList() { Stage = "測試 二", StageEN = "Testing 2", Code = "042", ParentCode = "040" },
                new StageList() { Stage = "測試 三", StageEN = "Testing 3", Code = "043", ParentCode = "040" },
                new StageList() { Stage = "測試 四", StageEN = "Testing 4", Code = "044", ParentCode = "040" },
                new StageList() { Stage = "測試 五", StageEN = "Testing 5", Code = "045", ParentCode = "040" },
                new StageList() { Stage = "上線", StageEN = "GoLive", Code = "050", ParentCode = "0" },
                new StageList() { Stage = "上線 一", StageEN = "GoLive 1", Code = "051", ParentCode = "050" },
                new StageList() { Stage = "上線 二", StageEN = "GoLive 2", Code = "052", ParentCode = "050" },
                new StageList() { Stage = "上線 三", StageEN = "GoLive 3", Code = "053", ParentCode = "050" },
                new StageList() { Stage = "上線 四", StageEN = "GoLive 4", Code = "054", ParentCode = "050" },
                new StageList() { Stage = "上線 五", StageEN = "GoLive 5", Code = "055", ParentCode = "050" },
                new StageList() { Stage = "待討論", StageEN = "To be discussed", Code = "900", ParentCode = "999" }
            };
            foreach (var stg in stgLst)
            {
                if (stageColl.Find(x => x.Stage == stg.Stage).ToList().Count() == 0)
                {
                    stageColl.Insert(stg);
                }
            }


        }

        private void TestArea()
        {
            
            //DateTime dt;
            ////DateTime ndt = new DateTime(2020, 12, 6);
            //var projCol = DbContext.GetInstance().GetCollection<ProjectList>();
            //var weekCol = DbContext.GetInstance().GetCollection<WeekSetting>();
            //var wek = weekCol.FindAll().OrderBy(x => x.StartDate); //find by wek.starDtae > 
            //var get = projCol.Find(x => x.ReqFormNo == "SHC-R201000007" && x.ReqFormDesc == "HP IE32資料庫調整").ToList(); // find from xProj, where xProj.week < week foreach
            //var listTestDate = (from a in get join b in wek on a.IdWeek equals b.id  orderby b.StartDate ascending select new { TestDate = a.TestDateEstimate,  b.Week}).ToList();
            //DateTime dt1 = new DateTime(2020, 1, 1);
            //DateTime dt2 = new DateTime(2020, 1, 1);
            //int flag = 0;
            //int cntChg = 0; // hitung perubahan date 
            //
            //foreach ( var kk in listTestDate) // value pertama dt1 dt2 dari testdate pertama
            //{
            //    if(DateTime.TryParse(kk.TestDate, out dt))
            //    {
            //        dt1 = dt;
            //        dt2 = dt;
            //        break;
            //    }
            //}
            //
            //foreach (var jj in listTestDate)
            //{
            //    flag++;
            //    if (DateTime.TryParse(jj.TestDate, out dt)) //kolom test date & apply date ada, cek test date lebih dari 2 minggu sejak apply date
            //    {
            //        if (flag % 2 == 0) //loop genap
            //        {
            //            dt2 = dt;
            //        }
            //        else
            //        {
            //            dt1 = dt;
            //        }
            //    }
            //    int isChg = DateTime.Compare(dt1, dt2); // 0 : gaada perubahan
            //    if (isChg != 0)
            //    {
            //        cntChg++;
            //    }
            //}
            //
            //DateTime currentDt = DateTime.Now.Date;
            //DateTime getUED;
            //DateTime getApplyDate;
            //int cntErrA = 0;
            //int cntErrB = 0;
            //
            ////get error A
            //if (DateTime.TryParse(get.ApplyDate, out dt))
            //{
            //    getApplyDate = Convert.ToDateTime(get.ApplyDate);
            //    if (DateTime.TryParse(get.TestDateEstimate, out dt)) //kolom test date & apply date ada, cek test date lebih dari 2 minggu sejak apply date
            //    {
            //        getUED = Convert.ToDateTime(get.TestDateEstimate);
            //        if ((getUED - getApplyDate).TotalDays > 14)
            //        {
            //            cntErrA++;
            //        }
            //    }
            //    else if ((currentDt - getApplyDate).TotalDays > 14) // kolom test date kosong tapi ada apply date, cek apply date lebih dr 2 minggu
            //    {
            //        cntErrA++;
            //    }
            //}
            //else //kolom apply date kosong
            //{
            //    cntErrA++;
            //}
            //
            //
            ////get error b
            //if (DateTime.TryParse(get.StageActualFinish, out dt))
            //{
            //    cntErrB++;
            //}
            //
            ////get error c



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
            //stlist.Insert(new StageList() { Stage = "上線 一", StageEN = "GoLive 1", Code = "051", ParentCode = "050" });
            //stlist.Insert(new StageList() { Stage = "上線 二", StageEN = "GoLive 2", Code = "052", ParentCode = "050" });
            //stlist.Insert(new StageList() { Stage = "上線 三", StageEN = "GoLive 3", Code = "053", ParentCode = "050" });
            //stlist.Insert(new StageList() { Stage = "上線 四", StageEN = "GoLive 4", Code = "054", ParentCode = "050" });
            //stlist.Insert(new StageList() { Stage = "上線 五", StageEN = "GoLive 5", Code = "055", ParentCode = "050" });
            //stlist.Insert(new StageList() { Stage = "待討論", StageEN = "To be discussed", Code = "900", ParentCode = "999" });

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
        public int? TotalProject { get; set; }
        public int? TotalError { get; set; }
        public int? TotalErrorA { get; set; }
        public int? TotalErrorB { get; set; }
        public int? TotalErrorC { get; set; }
    }
}
