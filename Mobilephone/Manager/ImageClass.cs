using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Mobilephone.Manager
{
    class ImageClass
    {
       public static  MemoryStream img = new MemoryStream();
        
        public static byte[] setImage(PictureBox photo)
        {
            photo.Image.Save(img, System.Drawing.Imaging.ImageFormat.Bmp);
            return img.ToArray();
        }

        public static void getImage(PictureBox photo)
        {
            using(OpenFileDialog dialog = new OpenFileDialog() {  Filter="Image (*.jpg*;*.png*;*.gif)|*.jpg*;*.png*;*.gif",ValidateNames = true, Multiselect= false })
            {
                string file;
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    file = dialog.FileName;
                    photo.Image = Image.FromFile(file);
                }
            }
        }
        public static void getImageMultiple(PictureBox photo)
        {
            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "Image (*.jpg*;*.png*;*.gif)|*.jpg*;*.png*;*.gif", ValidateNames = true, Multiselect = true })
            {
                string file;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    file = dialog.FileName;
                    photo.Image = Image.FromFile(file);
                }
            }
        }


    }
}
