using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobilephone.Manager
{
    class GenderClass_cs
    {
        public  string setGender(RadioButton Female, RadioButton Male)
        {
            string gender = "";
            if(Female.Checked == true)
            {
                gender = "Female";
            }
            if(Male.Checked == true)
            {
                gender = "Male";
            }

            return gender.Trim();
        }

    }
}
