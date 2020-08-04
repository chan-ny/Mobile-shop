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
            Manager.DataProduct.setLoadData(dgvProduct, "select * from tb_products");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Manager.DataProduct.setLoadData(dgvProduct, "select * from tb_products");

        }

        private void txtRearch_TextChanged(object sender, EventArgs e)
        {
            if(txtRearch.Text == "")
            {
                Manager.DataProduct.SearchName = txtRearch.Text;
                Manager.DataProduct.searchData(dgvProduct);
            }
            else
            {
                Manager.DataProduct.SearchName = txtRearch.Text;
                Manager.DataProduct.searchData(dgvProduct);
            }
        }

          
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         if(e.ColumnIndex == 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                if(MessageBox.Show(string.Format("Do you want to Change {0} ?",row.Cells["productId"].Value),"Confirm",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    byte[] array = (byte[])dgvProduct.CurrentRow.Cells[3].Value;
                    Manager.DGVSelection select = new Manager.DGVSelection();
                    Manager.DataProduct.ID = select.sentDataGridView(dgvProduct, 2);
                    Manager.DataProduct.Photo = array;
                    Manager.DataProduct.Name = select.sentDataGridView(dgvProduct, 4);
                    Manager.DataProduct.Colors = select.sentDataGridView(dgvProduct, 5);
                    Manager.DataProduct.Brands = select.sentDataGridView(dgvProduct, 7);
                    Manager.DataProduct.Size = select.sentDataGridView(dgvProduct, 9);
                    Manager.DataProduct.ScrennSize = select.sentDataGridView(dgvProduct, 11);
                    Manager.DataProduct.Units  = select.sentDataGridView(dgvProduct, 13);
                    Manager.DataProduct.Networks = select.sentDataGridView(dgvProduct, 15);
                    Manager.DataProduct.Annouced = select.sentDataGridView(dgvProduct, 16);
                    Manager.DataProduct.Sim = select.sentDataGridView(dgvProduct, 17);
                    Manager.DataProduct.Blutooth = select.sentDataGridView(dgvProduct, 18);
                    Manager.DataProduct.GPS = select.sentDataGridView(dgvProduct, 19);
                    Manager.DataProduct.Battery = select.sentDataGridView(dgvProduct, 20);
                    Manager.DataProduct.OS = select.sentDataGridView(dgvProduct, 21);
                    Manager.DataProduct.Chipset = select.sentDataGridView(dgvProduct, 22);
                    Manager.DataProduct.CPU = select.sentDataGridView(dgvProduct, 23);
                    Manager.DataProduct.GPU = select.sentDataGridView(dgvProduct, 24);
                    Manager.DataProduct.RAM = select.sentDataGridView(dgvProduct, 25);
                    Manager.DataProduct.Memory = select.sentDataGridView(dgvProduct, 26); 
                    Manager.DataProduct.FrontCamera = select.sentDataGridView(dgvProduct, 27);
                    Manager.DataProduct.FrontVideo = select.sentDataGridView(dgvProduct, 28);
                    Manager.DataProduct.RearCamera= select.sentDataGridView(dgvProduct, 29);
                    Manager.DataProduct.RearVideo = select.sentDataGridView(dgvProduct, 30);
                    Manager.DataProduct.Price = select.sentDataGridView(dgvProduct, 31);
                    Manager.DataProduct.StockON = select.sentDataGridView(dgvProduct, 32);
                    Manager.DataProduct.StockOFF = select.sentDataGridView(dgvProduct, 33);
                    Manager.DataProduct.AmountQty = select.sentDataGridView(dgvProduct, 34);
                    Manager.DataProduct.SalePrice = select.sentDataGridView(dgvProduct, 35);
                    Manager.DataProduct.Profit = select.sentDataGridView(dgvProduct, 36);
                    DataProduct.formDataProduct open = new DataProduct.formDataProduct();
                    open.States = 2;
                    open.ShowDialog();
                }
            }

            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Do you want to Delete {0} ?", row.Cells["productId"].Value), "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string id = row.Cells["productId"].Value.ToString();
                    Manager.DataProduct.ID = id;
                    Manager.DataProduct.deleteData(dgvProduct);
                }
            }
        }
    }
}
