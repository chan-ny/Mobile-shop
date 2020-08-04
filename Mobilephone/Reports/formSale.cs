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
    public partial class formSale : Form
    {
        public formSale()
        {
            InitializeComponent();
        }

        private void formSale_Load(object sender, EventArgs e)
        {
            Manager.ReportingTable.ReportSale(crystalReportViewer1);
        }
    }
}
