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
    public partial class formRegisterCustomer : Form
    {
        public formRegisterCustomer()
        {
            InitializeComponent();
        }


        private void CleamData()
        {
            Manager.RegisterCustomer.cleatData(txtName);
            Manager.RegisterCustomer.cleatData(txtLastName);
            Manager.RegisterCustomer.cleatData(txtHome);
            Manager.RegisterCustomer.cleatData(txtDitrict);
            Manager.RegisterCustomer.cleatData(txtProvice);
            Manager.RegisterCustomer.cleatData(txttell);
            Manager.RegisterCustomer.cleatData(txtEmail);
            Manager.RegisterCustomer.cleatData(txtIdentityCard);
            Manager.RegisterCustomer.cleatData(txtNamed);
            Manager.RegisterCustomer.cleatData(txtLatNamed);
            Manager.RegisterCustomer.cleatData(txtIdentityold);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            panelResearch.Visible = true;
        }

        private void formRegisterCustomer_Load(object sender, EventArgs e)
        {
            panelResearch.Visible = false;
            Manager.RegisterCustomer.setloadData(dgvResearching);
            Manager.RegisterCustomer.AutoID(txtCode);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelResearch.Visible = false;
            CleamData();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Manager.GenderClass_cs gender = new Manager.GenderClass_cs();
            Manager.RegisterCustomer.Gender = gender.setGender(rFemale, rMale);
            Manager.RegisterCustomer.ID = txtCode.Text;
            Manager.RegisterCustomer.Name = txtName.Text;
            Manager.RegisterCustomer.LastName = txtLastName.Text;
            Manager.RegisterCustomer.Home = txtHome.Text;
            Manager.RegisterCustomer.District = txtDitrict.Text;
            Manager.RegisterCustomer.Provice = txtProvice.Text;
            Manager.RegisterCustomer.Tell = txttell.Text;
            Manager.RegisterCustomer.Email = txtEmail.Text;
            Manager.RegisterCustomer.Identity = txtIdentityCard.Text;
            Manager.RegisterCustomer.States = 1;
            Manager.RegisterCustomer.checkEmpty(dgvResearching);
            Manager.RegisterCustomer.AutoID(txtCode);

            /// sent to Data sale
            
            CleamData();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            CleamData();
            panelResearch.Visible = false;
            Manager.RegisterCustomer.AutoID(txtCode);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtNamed.Text == "" || txtIdentityold.Text == "" || txtLatNamed.Text=="")
            {
                Manager.RegisterCustomer.SearchNamed = txtNamed.Text;
                Manager.RegisterCustomer.SearchLastName = txtLatNamed.Text;
                Manager.RegisterCustomer.SearchIdentityCard = txtIdentityCard.Text;
                Manager.RegisterCustomer.searchData(dgvResearching);
            }
            else
            {
                Manager.RegisterCustomer.SearchNamed = txtNamed.Text;
                Manager.RegisterCustomer.SearchLastName = txtLatNamed.Text; ;
                Manager.RegisterCustomer.SearchIdentityCard = txtIdentityold.Text;
                Manager.RegisterCustomer.searchData(dgvResearching);

            }
        }

    }
}
