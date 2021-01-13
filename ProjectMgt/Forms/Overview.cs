using OfficeOpenXml;
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
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
        }

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
    }
}
