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
    public partial class formDisplay : Form
    {
        public formDisplay()
        {
            InitializeComponent();
        }

        private void CleamData()
        {
            Manager.SrceenDisplay.cleatData(txtSizescreen);
            Manager.SrceenDisplay.cleatData(txtResulation);
            Manager.SrceenDisplay.cleatData(txtSearchSizeScreen);
        }
        private void formDisplay_Load(object sender, EventArgs e)
        {
            Manager.SrceenDisplay.setloadData(dgvScreen);
            Manager.SrceenDisplay.AutoID(txtCode);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Manager.SrceenDisplay.AutoID(txtCode);
            Manager.SrceenDisplay.cleatData(txtSizescreen);
            Manager.SrceenDisplay.cleatData(txtResulation);
            Manager.SrceenDisplay.cleatData(txtSearchSizeScreen);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            CleamData();
            this.Controls.Clear();
            this.InitializeComponent();
            Manager.SrceenDisplay.setloadData(dgvScreen);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Manager.SrceenDisplay.ID = txtCode.Text;
            Manager.SrceenDisplay.ScreenSize = txtSizescreen.Text;
            Manager.SrceenDisplay.Resolution = txtResulation.Text;
            Manager.SrceenDisplay.States = 1;
            Manager.SrceenDisplay.checkEmpty(dgvScreen);
            Manager.SrceenDisplay.AutoID(txtCode);
            CleamData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Manager.SrceenDisplay.ID = txtCode.Text;
            Manager.SrceenDisplay.ScreenSize = txtSizescreen.Text;
            Manager.SrceenDisplay.Resolution = txtResulation.Text;
            Manager.SrceenDisplay.States = 2;
            Manager.SrceenDisplay.checkEmpty(dgvScreen);
            Manager.SrceenDisplay.AutoID(txtCode);
            CleamData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSizescreen.Text == "")
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Manager.SrceenDisplay.ID = txtCode.Text;
                Manager.SrceenDisplay.deleteData(dgvScreen);
                Manager.SrceenDisplay.AutoID(txtCode);
                CleamData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearchSizeScreen.Text == "")
            {
                Manager.SrceenDisplay.SearchName = txtSearchSizeScreen.Text;
                Manager.SrceenDisplay.searchData(dgvScreen);
            }
            else
            {
                Manager.SrceenDisplay.SearchName = txtSearchSizeScreen.Text;
                Manager.SrceenDisplay.searchData(dgvScreen);
            }
        }

        private void dgvScreen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Manager.DGVSelection select = new Manager.DGVSelection();
            select.setSelction(dgvScreen, txtCode, 0);
            select.setSelction(dgvScreen, txtSizescreen, 1);
            select.setSelction(dgvScreen, txtResulation, 2);

        }
    }
}
