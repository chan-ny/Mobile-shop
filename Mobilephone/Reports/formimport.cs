using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobilephone.Reports
{
    public partial class formimport : Form
    {
        public formimport()
        {
            InitializeComponent();
        }

        private void formimport_Load(object sender, EventArgs e)
        {
            Manager.ReportingTable.ReportImport(crystalReportViewer1);
        }
    }
}
