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
    public partial class formBrands : Form
    {
        public formBrands()
        {
            InitializeComponent();
        }
        private void CleamData()
        {
            Manager.Brands.cleatData(txtName);
            Manager.Brands.cleatData(txtDetail);
            Manager.Brands.cleatData(txtDetail);
            Manager.Brands.cleatData(txtSearchName);

        }
        private void formBrands_Load(object sender, EventArgs e)
        {
            Manager.Brands.setComboBox(cbSupplier);
            Manager.Brands.setloadData(dgvBrands);
            Manager.Brands.AutoID(txtCode);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CleamData();
            Manager.Brands.AutoID(txtCode);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Manager.Brands.ID = txtCode.Text;
            Manager.Brands.SubID = cbSupplier.SelectedValue.ToString();
            Manager.Brands.Brand = txtName.Text;
            Manager.Brands.BrandDetail = txtDetail.Text;
            Manager.Brands.States = 1;
            Manager.Brands.checkEmpty(dgvBrands);
            CleamData();
            Manager.Brands.AutoID(txtCode);

        }

        private void dgvBrands_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Manager.DGVSelection select = new Manager.DGVSelection();
            select.setSelction(dgvBrands, txtCode, 0);
            select.setSelction(dgvBrands, txtName, 2);
            select.setSelction(dgvBrands, txtDetail, 3);
            cbSupplier.SelectedValue = dgvBrands.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Manager.Brands.ID = txtCode.Text;
            Manager.Brands.SubID = cbSupplier.SelectedValue.ToString();
            Manager.Brands.Brand = txtName.Text;
            Manager.Brands.BrandDetail = txtDetail.Text;
            Manager.Brands.States = 2;
            Manager.Brands.checkEmpty(dgvBrands);
            CleamData();
            Manager.Brands.AutoID(txtCode);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "")
            {
                MessageBox.Show("please click value to DataGridView ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Manager.Brands.ID = txtCode.Text;
                Manager.Brands.deleteData(dgvBrands);
                CleamData();
                Manager.Brands.AutoID(txtCode);
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchName.Text == "")
            {
                Manager.Brands.SearchName = txtSearchName.Text;
                Manager.Brands.searchData(dgvBrands);
            }
            else
            {
                Manager.Brands.SearchName = txtSearchName.Text;
                Manager.Brands.searchData(dgvBrands);
            }
        }
    }
}
