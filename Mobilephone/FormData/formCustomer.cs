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
    public partial class formCustomer : Form
    {
        public formCustomer()
        {
            InitializeComponent();
        }

        private void setGender(string gender)
        {
            if (gender == "Female")
            {
                rFemale.Checked = true;
            }
            if (gender == "Male")
            {
                rMale.Checked = true;
            }
        }

        private void CleamData()
        {
            Manager.RegisterCustomer.cleatData(txtName);
            Manager.RegisterCustomer.cleatData(txtLastName);
            Manager.RegisterCustomer.cleatData(txtHome);
            Manager.RegisterCustomer.cleatData(txtDistrict);
            Manager.RegisterCustomer.cleatData(txtProvice);
            Manager.RegisterCustomer.cleatData(txtTell);
            Manager.RegisterCustomer.cleatData(txtEmail);
            Manager.RegisterCustomer.cleatData(txtIdentityCard);
            Manager.RegisterCustomer.cleatData(txtSearchName);
            this.Controls.Clear();
            this.InitializeComponent();
            Manager.RegisterCustomer.setloadData(dgvCustomer);



        }
        private void formCustomer_Load(object sender, EventArgs e)
        {
            Manager.RegisterCustomer.setloadData(dgvCustomer);
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Manager.DGVSelection select = new Manager.DGVSelection();
            select.setSelction(dgvCustomer, txtCode, 0);
            select.setSelction(dgvCustomer, txtName, 2);
            select.setSelction(dgvCustomer, txtLastName, 3);
            select.setSelction(dgvCustomer, txtHome, 4);
            select.setSelction(dgvCustomer, txtDistrict, 5);
            select.setSelction(dgvCustomer, txtProvice, 6);
            select.setSelction(dgvCustomer, txtTell, 7);
            select.setSelction(dgvCustomer, txtEmail, 8);
            select.setSelction(dgvCustomer, txtIdentityCard, 9);

            string gender = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            setGender(gender);


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Manager.GenderClass_cs gender = new Manager.GenderClass_cs();
            Manager.RegisterCustomer.Gender = gender.setGender(rFemale, rMale);
            Manager.RegisterCustomer.ID = txtCode.Text;
            Manager.RegisterCustomer.Name = txtName.Text;
            Manager.RegisterCustomer.LastName = txtLastName.Text;
            Manager.RegisterCustomer.Home = txtHome.Text;
            Manager.RegisterCustomer.District = txtDistrict.Text;
            Manager.RegisterCustomer.Provice = txtProvice.Text;
            Manager.RegisterCustomer.Tell = txtTell.Text;
            Manager.RegisterCustomer.Email = txtEmail.Text;
            Manager.RegisterCustomer.Identity = txtIdentityCard.Text;
            Manager.RegisterCustomer.States = 2;
            Manager.RegisterCustomer.checkEmpty(dgvCustomer);
            CleamData();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("please cilck DataGridView ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Manager.RegisterCustomer.ID = txtCode.Text;
                Manager.RegisterCustomer.deleteData(dgvCustomer);
                CleamData();
            }

        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "")
            {
                Manager.RegisterCustomer.SearchNamed = txtSearchName.Text;
                Manager.RegisterCustomer.searchCustomer(dgvCustomer);

            }
            else
            {
                Manager.RegisterCustomer.SearchNamed = txtSearchName.Text;
                Manager.RegisterCustomer.searchCustomer(dgvCustomer);

                }
            }

    }
}
