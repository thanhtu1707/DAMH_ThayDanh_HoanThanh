using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DAL;
using DevExpress.Utils.Animation;

namespace QL_CuaHangBanDoAn
{
    public partial class frm_DangNhap : Form
    {
        public int MaNV{ get; set; }
        public string TenNV { get; set; }
        public int QuyenNV { get; set; }
        public string TenTK { get; set; }
        public string KT { get; set; }
        
        QL_DangNhap dn = new QL_DangNhap();
        QL_TextBox test = new QL_TextBox();
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string tendn = txtTenDN.Text.Trim();
                string matkhau = txtMatKhau.Text.Trim();
                string tt = "Hoạt Động";
                if (tendn != " " || matkhau != " ")
                {
                    if (test.ktraDangNhap(txtTenDN.Text) && test.ktraDangNhap(txtMatKhau.Text) && txtTenDN.Text.Length <= 15 && txtMatKhau.Text.Length <= 25)
                    {
                        if (dn.ktraDangNhap(tendn, matkhau) && dn.layTinhTrang(tendn, matkhau) == "Hoạt Động")
                        {
                            TenNV = dn.layTenNV(tendn);
                            QuyenNV = dn.layChucVu(tendn);
                            TenTK = tendn;
                            MaNV = dn.layMaNV(tendn);
                            MessageBox.Show("Đăng Nhập Thành Công");
                            frm_Main main = new frm_Main();
                            main.tenNV = TenNV;
                            main.maNV = MaNV;
                            main.maCV = QuyenNV;
                            main.ShowDialog();
                            this.Hide();
                        }
                        else if (dn.ktraDangNhap(tendn, matkhau) && dn.layTinhTrang(tendn, matkhau) == "Khóa")
                        {
                            MessageBox.Show("Tài khoản đã bị vô hiệu hóa!!!");
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!!!");
                        }
                    }
                    else
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng định dạng");
                }
                else
                    MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!!!");
            }
            catch(Exception ex)
            {
                
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn thoát chương trình??", "Thoat", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                try
                {
                    string tendn = txtTenDN.Text.Trim();
                    string matkhau = txtMatKhau.Text.Trim();
                    string tt = "Hoạt Động";
                    if (tendn != " " || matkhau != " ")
                    {
                        if (dn.ktraDangNhap(tendn, matkhau) && dn.layTinhTrang(tendn, matkhau) == "Hoạt Động")
                        {
                            TenNV = dn.layTenNV(tendn);
                            QuyenNV = dn.layChucVu(tendn);
                            TenTK = tendn;
                            MaNV = dn.layMaNV(tendn);
                            MessageBox.Show("Đăng Nhập Thành Công");
                            frm_Main main = new frm_Main();
                            main.tenNV = TenNV;
                            main.maNV = MaNV;
                            main.maCV = QuyenNV;
                            main.ShowDialog();
                            this.Hide();
                        }
                        else if (dn.ktraDangNhap(tendn, matkhau) && dn.layTinhTrang(tendn, matkhau) == "Khóa")
                        {
                            MessageBox.Show("Tài khoản đã bị vô hiệu hóa!!!");
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!!!");
                        }
                    }
                    else
                        MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!!!");
                }
                catch (Exception ex)
                {

                }
            }    
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        int flag_1 = 1, flag_2 = 1;

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            string str = "^[a-zA-Z0-9]*$";
            if (Regex.IsMatch(txtMatKhau.Text, str) && txtMatKhau.Text.Length != 0)
            {
                errorProvider2.Clear();
                flag_2 = 0;
            }
            else
            {
                errorProvider2.SetError((System.Windows.Forms.TextBox)sender, "Mật khẩu không hợp lệ");
            }
        }

        private void layoutControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDN_Leave(object sender, EventArgs e)
        {
            string str = "^[a-zA-Z0-9]*$";

            if (Regex.IsMatch(txtTenDN.Text, str) && txtTenDN.Text.Length > 4 && txtTenDN.Text.Length < 31)
            {
                errorProvider1.Clear();
                flag_1 = 0;

            }
            else
            {
                errorProvider1.SetError((System.Windows.Forms.TextBox)sender, "Tài khoản không hợp lệ");
            }
        }
    }
}
