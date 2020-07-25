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
    public partial class formUnit : Form
    {
  
        public formUnit()
        {
            InitializeComponent();
            Manager.Units.AutoID(txtId);
        }

        private void setData()
        {
            try
            {
                Manager.Units.setloadData(dataGridView1);
            }
            catch
            {
                MessageBox.Show("Can not Load Values");
            }
        }

        private void formUnit_Load(object sender, EventArgs e)
        {
            setData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Manager.Units.AutoID(txtId);
            Manager.Units.cleatData(txtDescription);
            Manager.Units.cleatData(txtName);
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Manager.Units.cleatData(txtDescription);
            Manager.Units.cleatData(txtName);
            Manager.Units.cleatData(txtSearch);
            Manager.Units.AutoID(txtId);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manager.Units.NameUnit = txtName.Text;
            Manager.Units.Description = txtDescription.Text;
            Manager.Units.saveDate(dataGridView1);
            Manager.Units.cleatData(txtDescription);
            Manager.Units.cleatData(txtName);
            Manager.Units.AutoID(txtId);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manager.Units.NameUnit = txtName.Text;
            Manager.Units.Description = txtDescription.Text;
            Manager.Units.ID = txtId.Text;
            Manager.Units.updateData(dataGridView1);
            Manager.Units.cleatData(txtDescription);
            Manager.Units.cleatData(txtName);
            Manager.Units.AutoID(txtId);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDescription.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Manager.Units.ID = txtId.Text;
            Manager.Units.deleteData(dataGridView1);
            Manager.Units.cleatData(txtDescription);
            Manager.Units.cleatData(txtName);
            Manager.Units.AutoID(txtId);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Manager.Units.Search = txtSearch.Text;
            Manager.Units.searchData(dataGridView1);
        }   
    }
}
