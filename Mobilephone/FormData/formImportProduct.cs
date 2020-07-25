using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobilephone.FormData
{
    public partial class formImportProduct : Form
    {
        public formImportProduct()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formAddProduct open = new formAddProduct();
            open.ShowDialog();
        }
    }
}
