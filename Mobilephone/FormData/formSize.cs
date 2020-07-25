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
    public partial class formSize : Form
    {
        public formSize()
        {
            InitializeComponent();
        }


        private void CleamData()
        {
            Manager.Size.cleatData(txtName);
            Manager.Size.cleatData(txtDetail);
            Manager.Size.cleatData(txtSearch);
            Manager.Size.AutoID(txtCode);


        }
        private void formSize_Load(object sender, EventArgs e)
        {
            Manager.Size.setloadData(dgvSize);
            Manager.Size.AutoID(txtCode);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Manager.Size.AutoID(txtCode);
            CleamData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleamData();
            this.Controls.Clear();
            this.InitializeComponent();
            Manager.Size.setloadData(dgvSize);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Manager.Size.ID = txtCode.Text;
            Manager.Size.Sizes = txtName.Text;
            Manager.Size.Detailsize = txtDetail.Text;
            Manager.Size.States = 1;
            Manager.Size.checkEmpty(dgvSize);
            CleamData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Manager.Size.ID = txtCode.Text;
            Manager.Size.Sizes = txtName.Text;
            Manager.Size.Detailsize = txtDetail.Text;
            Manager.Size.States = 2;
            Manager.Size.checkEmpty(dgvSize);
            CleamData();
        }

        private void dgvSize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Manager.DGVSelection select = new Manager.DGVSelection();
            select.setSelction(dgvSize, txtCode, 0);
            select.setSelction(dgvSize, txtName, 1);
            select.setSelction(dgvSize, txtDetail, 2);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtCode.Text == "")
            {
                MessageBox.Show("please input value to TextBox ID ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Manager.Size.ID = txtCode.Text;
                Manager.Size.deleteData(dgvSize);
                CleamData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Manager.Size.SearchName = txtSearch.Text;
            Manager.Size.searchData(dgvSize);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                Manager.Size.SearchName = txtSearch.Text;
                Manager.Size.searchData(dgvSize);
            }
        }
    }
}
