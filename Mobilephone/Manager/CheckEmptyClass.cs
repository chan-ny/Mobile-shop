using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobilephone.Manager
{
    class CheckEmptyClass
    {
        public void checkEmptytText(TextBox txt)
        {
            if(txt.Text == "")
            {
                MessageBox.Show("please input Value to TextBox");
                return;
            }
        }
        public void checkEmptyPicture( PictureBox photo)
        {
            if (photo.Image == null)
            {
                MessageBox.Show("please input Select Image to PictureBox");
                return;
            }
        }
    }
}
