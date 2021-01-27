using DevComponents.Editors;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMgt.Forms
{
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file 
            file.Filter = "Excel Files|*.xlsx;*.xls";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        txtbxPath.Text = filePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private void Upload_Load(object sender, EventArgs e)
        {
            var collection = DbContext.GetInstance().GetCollection<WeekSetting>();
            var weeks = collection.Find(x => x.isUpload == false).OrderByDescending(a => a.StartDate).ToList();
            foreach (var week in weeks)
            {
                ComboItem item = new ComboItem(week.Week + " " + week.StartDate.ToShortDateString() + " - " + week.EndDate.ToShortDateString() ) { Value = week.id };

                cbWeek.Items.Add(item);
            }
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            var filePath = txtbxPath.Text;
            var projColl = DbContext.GetInstance().GetCollection<ProjectList>();
            var weekColl = DbContext.GetInstance().GetCollection<WeekSetting>();
            var idwx = ((ComboItem)cbWeek.SelectedItem); //guid week
            var idw = Guid.Parse(idwx.Value.ToString());
            if ((filePath == null || filePath == "") || idwx == null)
            {
                MessageBox.Show("Please select file & week first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var fileName = Path.GetFileName(filePath);
                    var excelFile = new FileInfo(filePath);
                    using (var p = new ExcelPackage(excelFile))
                    {
                        var ws = p.Workbook.Worksheets.FirstOrDefault();
                        var endrow = ws.Dimension.End.Row;
                        var endcol = 14;

                        for (int row = 2; row <= endrow; row++)
                        {
                            List<string> kind = new List<string>();
                            for (int col = 1; col <= endcol; col++)
                            {
                                if (ws.Cells[row, col].Value != null)
                                {
                                    kind.Add(ws.Cells[row, col].Value.ToString());
                                }
                                else
                                {
                                    kind.Add("");
                                }
                            }
                            
                            
                            ProjectList pl = new ProjectList()
                            {
                                System = kind[0],
                                ErrKind = kind[1],
                                Desc = kind[2],
                                Applicant = kind[3],
                                PIC = kind[4],
                                ReqFormNo = kind[5],
                                ReqFormDesc = kind[6],
                                Stage = kind[7],
                                UserExpectedDate = kind[8],
                                StageEstimateFinish = kind[9],
                                StageActualFinish = kind[10],
                                TestDateEstimate = kind[11],
                                ApplyDate = kind[12],
                                Memo = kind[13],
                                FileName = fileName,
                                IsNormal = true,
                                IdWeek = idw,
                                CreatedAt = DateTime.Now
                            };
                            projColl.Insert(pl);
                            kind.Clear();
                            Thread.Sleep(1); //avoid same time insert 
                            if (ws.Cells[row + 1, 7].Value == null)
                            {
                                break;
                            }
                        }
                    }
                    var week = weekColl.FindById(idw);
                    week.isUpload = true;
                    weekColl.Update(idw, week);
                    MessageBox.Show("File " + fileName + " has been uploaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Detail: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        
    }
}
