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

        private void formImportProduct_Load(object sender, EventArgs e)
        {
            Manager.ImportProduct.setloadDataP(dgvBilldata);

            Manager.ImportProduct.setloadDataViewP(dgvList);

        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = dgvList.Rows[e.RowIndex];
                txtCodeBill.Text = row.Cells[1].Value.ToString();
                txtNumber.Text = row.Cells[3].Value.ToString();
                txtAmountCost.Text = row.Cells[4].Value.ToString();
                txtTotal.Text = row.Cells[5].Value.ToString();


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Manager.ImportProduct.ID = txtCodeBill.Text;
            Manager.ImportProduct.saveData(dgvList);
            Manager.ImportProduct.setloadDataP(dgvBilldata);
            Reports.formimportOrder open = new Reports.formimportOrder();
            open.ShowDialog();
            CleamData();



        }


        private void CleamData()
        {
            Manager.ImportProduct.ClearData(txtCodeBill);
            Manager.ImportProduct.ClearData(txtNumber);
            Manager.ImportProduct.ClearData(txtAmountCost);
            Manager.ImportProduct.ClearData(txtTotal);
            Manager.ImportProduct.ClearData(txtCodeBill);

        }
    


    private void btnClear_Click(object sender, EventArgs e)
        {
            Manager.ImportProduct.ID = txtCodeBill.Text;
            Manager.ImportProduct.DeleteData(dgvList);
            Manager.ImportProduct.setloadDataP(dgvBilldata);
            CleamData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.ImportProduct.setloadDataP(dgvBilldata);

            Manager.ImportProduct.setloadDataViewP(dgvList);
        }
    }
}
