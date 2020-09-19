using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ThietKeControl
{
    public class txtEmail:TextBox
    {
        public txtEmail()
        {
            this.Leave += TxtEmail_Leave;
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            string chuoi = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!Regex.IsMatch(this.Text, chuoi))
            {
                MessageBox.Show("Không đúng định dạng mail");
            }
        }
    }
}
