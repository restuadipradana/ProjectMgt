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
    //THIS FORM IS FOR ADD, EDIT, OR DELETE EVERY USERINPUT DATA. 1 for add, 2 for edit or delete
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private Guid _id;
        private int _kind;
        public Add(string idc, int kind) : this()
        {
            Guid id = Guid.Parse(idc);
            _id = id;
            _kind = kind;

            var projCol = DbContext.GetInstance().GetCollection<ProjectList>();
            var stgCol = DbContext.GetInstance().GetCollection<StageList>();
            
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
            btDelete.Visible = false;
            if (_kind == 2)
            {
                tbUserExpectDate.Text = proj.UserExpectedDate;
                tbStageEstFinish.Text = proj.StageEstimateFinish;
                tbStageActFinish.Text = proj.StageActualFinish;
                tbITGiveTestDate.Text = proj.TestDateEstimate;
                tbApplyDate.Text = proj.ApplyDate;
                btDelete.Visible = true;
            }
            
            
            
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
                if (stg != null)
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
                    if(_kind == 1)
                    {
                        projCol.Insert(pl);
                        this.Close();
                    }
                    else
                    {
                        projCol.Update(_id, pl);
                        this.Close();
                    }
                    //Overview ov = new Overview();
                    //ov.Get2List();

                }
                else
                {
                    MessageBox.Show("Select Stage first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid Week, please generate week first in Setting", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                var projCol = DbContext.GetInstance().GetCollection<ProjectList>();
                projCol.Delete(_id);
                
                this.Close();
            }
                
        }
    }
}
