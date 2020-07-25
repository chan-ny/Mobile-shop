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
    public partial class formProduct : Form
    {
        public formProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataProduct.formDataProduct open = new DataProduct.formDataProduct();
            open.ShowDialog();
        }


        private void formProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
