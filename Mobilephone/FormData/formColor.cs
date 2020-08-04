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
    public partial class formColor : Form
    {
        public formColor()
        {
            InitializeComponent();
        }

        private void CleamData()
        {
            Manager.Color.cleatData(txtColor);
            Manager.Color.cleatData(txtColorDetail);
            Manager.Color.cleatData(txtSearchName);

        }
        private void formColor_Load(object sender, EventArgs e)
        {
            Manager.Color.setloadData(dgvColor);
            Manager.Color.AutoID(txtCode);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CleamData();
            Manager.Color.AutoID(txtCode);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleamData();
            this.Controls.Clear();
            this.InitializeComponent();
            Manager.Color.setloadData(dgvColor);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Manager.Color.ID = txtCode.Text;
            Manager.Color.Colors = txtColor.Text;
            Manager.Color.ColorDetailsize = txtColorDetail.Text;
            Manager.Color.States = 1;
            Manager.Color.checkEmpty(dgvColor);
            Manager.Color.AutoID(txtCode);
            CleamData();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Manager.Color.ID = txtCode.Text;
            Manager.Color.Colors = txtColor.Text;
            Manager.Color.ColorDetailsize = txtColorDetail.Text;
            Manager.Color.States = 2;
            Manager.Color.checkEmpty(dgvColor);
            Manager.Color.AutoID(txtCode);
            CleamData();
        }

        private void dgvColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Manager.DGVSelection select = new Manager.DGVSelection();
            select.setSelction(dgvColor, txtCode, 0);
            select.setSelction(dgvColor, txtColor, 1);
            select.setSelction(dgvColor, txtColorDetail, 2);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtColor.Text == "")
            {
                MessageBox.Show("please input value to TextBox Name ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Manager.Color.ID = txtCode.Text;
                Manager.Color.deleteData(dgvColor);
                Manager.Color.AutoID(txtCode);
                CleamData();
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchName.Text == "")
            {
                Manager.Color.SearchName = txtSearchName.Text;
                Manager.Color.searchData(dgvColor);
            }
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Manager.Color.SearchName = txtSearchName.Text;
            Manager.Color.searchData(dgvColor);
        }
    }
}
