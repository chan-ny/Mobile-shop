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
    public partial class formAddProduct : Form
    {
        public formAddProduct()
        {
            InitializeComponent();
        }

        private void addColumns()
        {
            dgvAdd.ColumnCount = 5;
            dgvAdd.Columns[0].Name = "ລະຫັດສີນຄ້າ";
            dgvAdd.Columns[1].Name = "ລາຄາສີນຄ້າ";
            dgvAdd.Columns[2].Name = "ຈຳນວນ";
            dgvAdd.Columns[3].Name = "ຍອດລວມ";
            dgvAdd.Columns[4].Name = "Supplier";
            dgvAdd.Columns[4].Visible = false;

        }

        private void CleamData()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtSupplier.Text = "";
            txtNumber.Value = 0;
            txtPrice.Text = "";
            txtAmonut.Text = "";

        }

       
        private void formAddProduct_Load(object sender, EventArgs e)
        {
            Manager.ImportProduct.ChooseSupplier(comboBox1);

            Manager.ImportProduct.Supplier = comboBox1.Text;
            Manager.ImportProduct.setloadData(dgAddProduct);
            addColumns();
            Manager.ImportProduct.AutoID(txtCodeBill);

        }

        private void dgAddProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0){
                DataGridViewRow row = dgAddProduct.Rows[e.RowIndex];
                txtCode.Text = row.Cells[1].Value.ToString();
                txtName.Text = row.Cells[2].Value.ToString();
                txtSupplier.Text = row.Cells[7].Value.ToString();
                txtPrice.Text = row.Cells[17].Value.ToString();

            }
        }

        private void txtNumber_ValueChanged(object sender, EventArgs e)
        {

           if(txtPrice.Text == "")
            {

                return;
            }
            else
            {
                int number = Convert.ToInt32(txtNumber.Value.ToString());
                int price = Convert.ToInt32(txtPrice.Text);
                int sum = price * number;
                txtAmonut.Text = sum.ToString();
            }

        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAmonut.Text == "") {
                MessageBox.Show("Not Record...");
                return;
            }

            string code = txtCode.Text;
            int x, y, z,q, index = 0;

            x = Convert.ToInt32(txtNumber.Value);

            for (int i = 0; i < dgvAdd.Rows.Count - 1; i++)
            {
                string id = dgvAdd.Rows[i].Cells[0].Value.ToString();
                if (id == code)
                {
                    q = Convert.ToInt32(dgvAdd.Rows[i].Cells[2].Value);
                    y = Convert.ToInt32(dgvAdd.Rows[i].Cells[1].Value);
                    index = x+q;
                    z = y * index;

                    DataGridViewRow add = dgvAdd.Rows[i];
                    add.Cells[2].Value = index;
                    add.Cells[3].Value = z;
                    index = 0;
                    return;

                }
            }

            string sid = Manager.ImportProduct.setSupplier(txtSupplier.Text);
            string[] addrow = new string[] { txtCode.Text, txtPrice.Text, txtNumber.Value.ToString(), txtAmonut.Text,sid };
            dgvAdd.Rows.Add(addrow);
            CleamData();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            int sumQty = 0;
            int sumPrice = 0;
            int sumTotal = 0;
            int x=0, y=0;
            int p=0;
            int s=0;
            int price = 0;



            for (int i=0; i< dgvAdd.Rows.Count - 1; i++)
            {
                x = Convert.ToInt32(dgvAdd.Rows[i].Cells[2].Value);
                y = Convert.ToInt32(dgvAdd.Rows[i].Cells[3].Value);
                p = Convert.ToInt32(dgvAdd.Rows[i].Cells[0].Value);
                s = Convert.ToInt32(dgvAdd.Rows[i].Cells[4].Value);
                price = Convert.ToInt32(dgvAdd.Rows[i].Cells[1].Value);


                sumQty += x;
                sumPrice += y;
                sumTotal = sumQty * sumPrice;
            }

            Manager.ImportProduct.AmountQty = sumQty.ToString();
            Manager.ImportProduct.AmountPrice = sumPrice.ToString();
            Manager.ImportProduct.AmountTotal = sumTotal.ToString();
            string id = txtCodeBill.Text;
            Manager.ImportProduct.orderData(id,dgvAdd);

            MessageBox.Show("Black to Home");
            this.Close();

        }

        private void dgAddProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvAdd.Rows.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Manager.ImportProduct.ChooseSupplier(comboBox1);

            Manager.ImportProduct.Supplier = comboBox1.Text;
            Manager.ImportProduct.setloadData(dgAddProduct);
            addColumns();
            Manager.ImportProduct.AutoID(txtCodeBill);

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            //Manager.ImportProduct.ChooseSupplier(comboBox1);

            //Manager.ImportProduct.Supplier = comboBox1.Text;
            //Manager.ImportProduct.setloadData(dgAddProduct);
            //addColumns();
            //Manager.ImportProduct.AutoID(txtCodeBill);
        }
    }
}
