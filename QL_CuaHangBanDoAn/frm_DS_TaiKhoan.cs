using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using DAL;

namespace QL_CuaHangBanDoAn
{
    public partial class frm_DS_TaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public frm_DS_TaiKhoan()
        {
            InitializeComponent();
        }
        QL_TaiKhoan tk = new QL_TaiKhoan();

        private void frm_DS_TaiKhoan_Load(object sender, EventArgs e)
        {
            load_cboMaNV();
            load_gridview();
            rdo_Khoa.Enabled = false;
        }
        public void load_cboMaNV()
        {
            cboNhanVien.DataSource = tk.load_Manv();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
        }
        public void load_gridview()
        {
            grid_TK.DataSource = tk.load_gridTaiKhoan();
        }
        public bool ktraDuLieu()
        {
            if (txtMK.Text == string.Empty && txtTenTK.Text == string.Empty)
                return false;
            else
                return true;

        }
        private void griditem_TK_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtTenTK.Text = griditem_TK.GetRowCellValue(griditem_TK.FocusedRowHandle, "TenTK").ToString();
            txtMK.Text = griditem_TK.GetRowCellValue(griditem_TK.FocusedRowHandle, "MatKhau").ToString();
            rdo_Khoa.Text = griditem_TK.GetRowCellValue(griditem_TK.FocusedRowHandle, "TinhTrang").ToString();
            rdo_hoatdong.Text = griditem_TK.GetRowCellValue(griditem_TK.FocusedRowHandle, "TinhTrang").ToString();
        }
        public void xoaTextBox()
        {
            txtTenTK.Text = "";
            txtMK.Text = "";

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            string ten = txtTenTK.Text.ToString();
            DialogResult dr = MessageBox.Show("Bạn muốn xóa chứ??", "Thong Báo!", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
               
                if (txtTenTK.Text == string.Empty)
                {
                    MessageBox.Show("Tên trong");
                }
                else
                {
                    tk.xoa(ten);
                    MessageBox.Show("Xóa thành công!");
                }
                load_gridview();
            }
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {            
            string tentk1 = txtTenTK.Text;
            if (ktraDuLieu() == false)
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ");

            }
            else if (tk.ktraKhoaNgoai(tentk1) == false)
            {
                MessageBox.Show("Nhân viên đã có tài khoản!!!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn muốn lưu chứ??", "Thong Báo!", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    string tentk = txtTenTK.Text;
                    string matkhau = txtMK.Text;
                    int manv = int.Parse(cboNhanVien.SelectedValue.ToString());
                    string tinhtrang = rdo_hoatdong.Text;

                    tk.luu( tentk, matkhau, tinhtrang);
                    tk.update_NhanVien(tentk, manv);
                    MessageBox.Show("Thêm mới thành công");
                    load_gridview();
                }
            }
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            rdo_Khoa.Enabled = true;
            if (ktraDuLieu())
            {
                DialogResult dr = MessageBox.Show("Bạn muốn sửa chứ??", "Thong Báo!", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    
                    string ten = txtTenTK.Text;
                    string matkhau = txtMK.Text;
                    string tinhtrang1 = rdo_Khoa.Text;
                    tk.sua(ten,matkhau, tinhtrang1);

                    MessageBox.Show("Sua Thanh cong");
                    load_gridview();
                    xoaTextBox();
                }


            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
            }
        }

        private void btnThem1_Click(object sender, EventArgs e)
        {
            xoaTextBox();
        }
        int flag_1 = 1, flag_2 = 1;

        private void txtTenTK_Leave(object sender, EventArgs e)
        {
            //string str = "^[a-zA-Z0-9]*$";
            //if (Regex.IsMatch(txtTenTK.Text, str) && txtTenTK.Text.Length != 0)
            //{
            //    errorProvider1.Clear();
            //    flag_1 = 0;
            //}
            //else
            //{
            //    errorProvider1.SetError((TextBox)sender, "Tài khoản không hợp lệ");
            //}
        }
    }
}