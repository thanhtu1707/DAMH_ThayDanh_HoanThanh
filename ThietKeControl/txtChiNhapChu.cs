using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ThietKeControl
{
    public class txtChiNhapChu:TextBox
    {
        public txtChiNhapChu()
        {
            this.KeyPress += TxtChiNhapChu_KeyPress;
        }

        private void TxtChiNhapChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
