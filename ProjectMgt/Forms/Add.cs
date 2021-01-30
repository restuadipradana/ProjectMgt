using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private Guid _id;
        public Add(string idc) : this()
        {
               
            var projCol = DbContext.GetInstance().GetCollection<ProjectList>();
            var stgCol = DbContext.GetInstance().GetCollection<StageList>();
            Guid id = Guid.Parse(idc);
            _id = id;
            var proj = projCol.FindById(id);
            var stgs = stgCol.FindAll().Where(x => x.Stage.Contains(proj.Stage.Substring(0, 2))).Where(x => x.ParentCode != "0").OrderBy(n => n.Code).ToList();
            if (stgs.Count == 0)
            {
                stgs = stgCol.FindAll().Where(x => x.Stage.Contains(proj.Stage)).Where(x => x.ParentCode != "0").OrderBy(n => n.Code).ToList();
            }


            foreach (var stg in stgs)
            {
                ComboItem item = new ComboItem(stg.Stage) { Value = stg.Stage };

                comboBoxEx1.Items.Add(item);
            }

            lbReqFormNo.Text = proj.ReqFormNo;
            lbReqFormDesc.Text = proj.ReqFormDesc;
            richTextBoxEx1.Text = proj.Memo;
            
            
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var stg = ((ComboItem)comboBoxEx1.SelectedItem);
            var dt = DateTime.Now;
            var projCol = DbContext.GetInstance().GetCollection<ProjectList>();
            var colweek = DbContext.GetInstance().GetCollection<WeekSetting>();
            var proj = projCol.FindById(_id);
            var week = colweek.Find(x => x.StartDate <= dt && x.EndDate >= dt.Date).SingleOrDefault();
            if (week != null)
            {
                ProjectList pl = new ProjectList()
                {
                    System = proj.System,
                    ErrKind = proj.ErrKind,
                    Desc = proj.Desc,
                    Applicant = proj.Applicant,
                    PIC = proj.PIC,
                    ReqFormNo = proj.ReqFormNo,
                    ReqFormDesc = proj.ReqFormDesc,
                    Stage = stg.Value.ToString(),
                    UserExpectedDate = tbUserExpectDate.Text,
                    StageEstimateFinish = tbStageEstFinish.Text,
                    StageActualFinish = tbStageActFinish.Text,
                    TestDateEstimate = tbITGiveTestDate.Text,
                    ApplyDate = tbApplyDate.Text,
                    Memo = richTextBoxEx1.Text,
                    FileName = "userinput",
                    IsNormal = true,
                    IdWeek = week.id,
                    CreatedAt = DateTime.Now
                };
                projCol.Insert(pl);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Week, please generate week first in Setting", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
