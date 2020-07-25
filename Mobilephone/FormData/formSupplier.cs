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
    public partial class formSupplier : Form
    {
        public formSupplier()
        {
            InitializeComponent();
        }

        private void formSupplier_Load(object sender, EventArgs e)
        {
            Manager.Supplier.setloadData(dataGridView1);
            Manager.Supplier.AutoID(txtId);
        }

        private void clearData()
        {
            Manager.Supplier.cleatData(txtName);
            Manager.Supplier.cleatData(txtLastname);
            Manager.Supplier.cleatData(txtTell);
            Manager.Supplier.cleatData(txtEmail);
            Manager.Supplier.cleatData(txthome);
            Manager.Supplier.cleatData(txtDistrict);
            Manager.Supplier.cleatData(txtProvice);
            Manager.Supplier.cleatData(txtCompany);
            Manager.Supplier.cleatData(txtCounty);
            Manager.Supplier.cleatData(txtSearch);
            Manager.Supplier.AutoID(txtId);
        }

        private  void selectGender(RadioButton female, RadioButton male, string gender)
        {
            if (gender == "Female")
            {
                female.Checked = true;
            }
            if (gender == "Male")
            {
                male.Checked = true;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Manager.Supplier.cleatData(txtName);
            Manager.Supplier.cleatData(txtLastname);
            Manager.Supplier.cleatData(txtTell);
            Manager.Supplier.cleatData(txtEmail);
            Manager.Supplier.cleatData(txthome);
            Manager.Supplier.cleatData(txtDistrict);
            Manager.Supplier.cleatData(txtProvice);
            Manager.Supplier.cleatData(txtCompany);
            Manager.Supplier.cleatData(txtCounty);
            Manager.Supplier.cleatData(txtSearch);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Manager.GenderClass_cs gender = new Manager.GenderClass_cs();
            Manager.Supplier.ID = txtId.Text;
            Manager.Supplier.Name = txtName.Text;
            Manager.Supplier.Gender= gender.setGender(rFemale, rMale);
            Manager.Supplier.LastName = txtLastname.Text;
            Manager.Supplier.Tell = txtTell.Text;
            Manager.Supplier.Email = txtEmail.Text;
            Manager.Supplier.Home = txthome.Text;
            Manager.Supplier.District = txtDistrict.Text;
            Manager.Supplier.Provice = txtProvice.Text;
            Manager.Supplier.Company = txtCompany.Text;
            Manager.Supplier.County = txtCounty.Text;
            Manager.Supplier.option = 1;
            Manager.Supplier.checkEmpty(dataGridView1);
            clearData();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            Manager.GenderClass_cs gender = new Manager.GenderClass_cs();
            Manager.Supplier.Name = txtName.Text;
            Manager.Supplier.Gender = gender.setGender(rFemale, rMale);
            Manager.Supplier.LastName = txtLastname.Text;
            Manager.Supplier.Tell = txtTell.Text;
            Manager.Supplier.Email = txtEmail.Text;
            Manager.Supplier.Home = txthome.Text;
            Manager.Supplier.District = txtDistrict.Text;
            Manager.Supplier.Provice = txtProvice.Text;
            Manager.Supplier.Company = txtCompany.Text;
            Manager.Supplier.County = txtCounty.Text;
            Manager.Supplier.ID = txtId.Text;
            Manager.Supplier.option = 2;
            Manager.Supplier.checkEmpty(dataGridView1);
            clearData();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Manager.DGVSelection select = new Manager.DGVSelection();
            select.setSelction(dataGridView1, txtId, 0);
            select.setSelction(dataGridView1, txtName, 2);
            select.setSelction(dataGridView1, txtLastname, 3);
            select.setSelction(dataGridView1, txtTell, 4);
            select.setSelction(dataGridView1, txtEmail, 5);
            select.setSelction(dataGridView1, txthome, 6);
            select.setSelction(dataGridView1, txtDistrict, 7);
            select.setSelction(dataGridView1, txtProvice, 8);
            select.setSelction(dataGridView1, txtCompany, 9);
            select.setSelction(dataGridView1, txtCounty, 10);
            string gender = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            selectGender(rFemale, rMale,gender);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Manager.Supplier.ID = txtId.Text;
            Manager.Supplier.deleteData(dataGridView1);
            clearData();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Manager.Supplier.SearchName = txtSearch.Text;
            Manager.Supplier.searchData(dataGridView1);
        }
    }
}
