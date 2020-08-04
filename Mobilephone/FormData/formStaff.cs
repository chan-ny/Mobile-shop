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
    public partial class formStaff : Form
    {
        public formStaff()
        {
            InitializeComponent();
            panelPosition.Visible = false;
        }

        private void switchPosition()
        {
            if(panelPosition.Visible == true)
            {
                panelPosition.Visible = false;
            }
            else
            {
                panelPosition.Visible = true;
            }
        }
        
        private void switchIndentity()
        {
            if (rGiveCard.Checked == true)
            {
                txtIdentityCard.Enabled = true;
            }
            else
            {
                txtIdentityCard.Enabled = false;
                chVender.Checked = false;
            }
        }

        private void CleamData()
        {
            Manager.staff.cleatData(txtName);
            Manager.staff.cleatData(txtLasName);
            Manager.staff.cleatData(txtTell);
            Manager.staff.cleatData(txtEmail);
            Manager.staff.cleatData(txtHome);
            Manager.staff.cleatData(txtDistrict);
            Manager.staff.cleatData(txtProvice);
            Manager.staff.cleatData(txtUser);
            Manager.staff.cleatData(txtPassword);

            txtIdentityCard.Text = "null";
            rGiveCard.Checked = false;
            rFemale.Checked = false;
            rMale.Checked = false;
            chVender.Checked = false;

            Manager.staff.AutoID(txtCode);


        }

        private void selectGender(RadioButton female, RadioButton male, string gender)
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
        private void formStaff_Load(object sender, EventArgs e)
        {
            Manager.staff.setloadData(dgvSatt);
            switchIndentity();
            dateBirthday.Format = DateTimePickerFormat.Custom;
             dateBirthday.CustomFormat = "yyyy-MM-dd";
            Manager.staff.AutoID(txtCode);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Manager.GenderClass_cs gender = new Manager.GenderClass_cs();
            Manager.staff.Gender = gender.setGender(rFemale, rMale);
            Manager.staff.Name = txtName.Text;
            Manager.staff.ID = txtCode.Text;
            Manager.staff.LastName = txtLasName.Text;
            Manager.staff.Tell = txtTell.Text;
            Manager.staff.Email = txtEmail.Text;
            Manager.staff.Home = txtHome.Text;
            Manager.staff.District = txtDistrict.Text;
            Manager.staff.Provice = txtProvice.Text;
            Manager.staff.IdentityCard = txtIdentityCard.Text;
            Manager.staff.BirthDay = dateBirthday.Text;
            switchPosition();
            Manager.staff.Vender = chVender.Text;
            Manager.staff.User = txtUser.Text;
            Manager.staff.Password = txtPassword.Text;

            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                label14.Text = "please input New Password and click Vender?";
                return;
            }
            else
            {
                label14.Visible = false;
                Manager.staff.option = 2;
                Manager.staff.checkEmpty(dgvSatt);

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please select List of Value into DataGrideView ...");
                return;
            }
            else
            {
                Manager.staff.ID = txtCode.Text;
                Manager.staff.deleteData(dgvSatt);
                CleamData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Manager.GenderClass_cs gender = new Manager.GenderClass_cs();
            Manager.staff.Gender = gender.setGender(rFemale, rMale);
            Manager.staff.Name = txtName.Text;
            Manager.staff.ID = txtCode.Text;
            Manager.staff.LastName = txtLasName.Text;
            Manager.staff.Tell = txtTell.Text;
            Manager.staff.Email = txtEmail.Text;
            Manager.staff.Home = txtHome.Text;
            Manager.staff.District = txtDistrict.Text;
            Manager.staff.Provice = txtProvice.Text;
            Manager.staff.IdentityCard = txtIdentityCard.Text;
            Manager.staff.BirthDay = dateBirthday.Text;
            switchPosition();
            Manager.staff.Vender = chVender.Text;
            Manager.staff.User = txtUser.Text;
            Manager.staff.Password = txtPassword.Text;

            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                label14.Text = "please input User and Password ?";
                return;
            }
            else
            {
                label14.Visible = false;
                Manager.staff.option = 1;
                Manager.staff.checkEmpty(dgvSatt);

            }

            CleamData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CleamData();
        }


        private void rGiveCard_Click_1(object sender, EventArgs e)
        {
            if (rGiveCard.Checked == true)
            {
                switchIndentity();
                txtIdentityCard.Text = "";
            }
            else
            {
                txtIdentityCard.Text = "null";
                txtIdentityCard.Enabled = false;
            }
        }

        private void chVender_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                label14.Text = "please input User and Password ?";
                return;
            }
            else
            {
                label14.Visible = false;

            }
        }

        private void dgvSatt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Manager.DGVSelection select = new Manager.DGVSelection();
            select.setSelction(dgvSatt, txtCode,0);
            select.setSelction(dgvSatt, txtName, 2);
            select.setSelction(dgvSatt, txtLasName,3);
            select.setSelction(dgvSatt, txtTell, 4);
            select.setSelction(dgvSatt, txtEmail, 5);
            select.setSelction(dgvSatt, txtHome, 6);
            select.setSelction(dgvSatt, txtDistrict, 7);
            select.setSelction(dgvSatt, txtProvice, 8);
            select.setSelction(dgvSatt, txtIdentityCard, 9);
            dateBirthday.Text = dgvSatt.CurrentRow.Cells[10].Value.ToString();
            select.setSelction(dgvSatt, txtUser, 12);

            string gender = dgvSatt.CurrentRow.Cells[1].Value.ToString();
            selectGender(rFemale, rMale, gender);
           


        }

        private void txtIdentityCard_TextChanged(object sender, EventArgs e)
        {
            if(txtIdentityCard.Text == "null")
            {
                rGiveCard.Checked = false;
                txtIdentityCard.Enabled = false;
            }
            else
            {
                rGiveCard.Checked = true;
                txtIdentityCard.Enabled = true;

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           if(txtSearch.Text == "")
            {
                Manager.staff.SearchName = txtSearch.Text;
                Manager.staff.searchData(dgvSatt);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Manager.staff.SearchName = txtSearch.Text;
            Manager.staff.searchData(dgvSatt);
        }
    }
  }

