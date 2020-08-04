using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Mobilephone.Manager
{
    class DGVSelection
    {
        public  void setSelction(DataGridView dgv,TextBox txt,int number)
        {
            txt.Text = dgv.CurrentRow.Cells[number].Value.ToString();
        }
        public string sentDataGridView(DataGridView dgv, int number)
        {
            string values = "";
            values= dgv.CurrentRow.Cells[number].Value.ToString();
            return values;
        }

        public  void setImage(DataGridView dgv,PictureBox photo, int number)
        {
            byte[] array = (byte[])dgv.CurrentRow.Cells[number].Value;
            MemoryStream img = new MemoryStream(array);
            photo.Image = Image.FromStream(img);
        }
    }
}

