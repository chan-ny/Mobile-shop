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
    public partial class formBill : Form
    {
        public formBill()
        {
            InitializeComponent();
        }

        private void formBill_Load(object sender, EventArgs e)
        {
            Manager.ReportingTable.ReportBill(crystalReportViewer1);

        }
    }
}
