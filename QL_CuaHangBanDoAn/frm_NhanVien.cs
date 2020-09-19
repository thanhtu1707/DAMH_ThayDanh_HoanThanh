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
using DAL;
using System.Windows.Forms.VisualStyles;
using System.Text.RegularExpressions;
using DevExpress.XtraLayout.Converter;

namespace QL_CuaHangBanDoAn
{
    public partial class frm_NhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frm_NhanVien()
        {
            InitializeComponent();
        }
        QL_NhanVien nv = new QL_NhanVien();
        QL_TextBox test = new QL_TextBox();
        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            load_CboTP();
            load_gridNhanVien();
            load_cboTenChucVu();
            xoaTextbox();

        }
        public void load_gridNhanVien()
        {
            grid_Nhanvien.DataSource = nv.load_datagridviewNV();
        }
        public void load_cboTenChucVu()
        {

            cbo_CV.Properties.DataSource = nv.load_cboChucvu();
            cbo_CV.Properties.DisplayMember = "MaCV";
            cbo_CV.Properties.ValueMember = "MaCV";
        }
        public bool ktraDuLieu()
        {
            if (txtTen.Text == string.Empty && txtCMND.Text == string.Empty && date_NgaySinh.Text == string.Empty && txtSDT.Text == string.Empty && txtDiaChi.Text == string.Empty && cbo_CV.Text == string.Empty )
                return false;
            else
                return true;

        }
        public void xoaTextbox()
        {
            txtMa.Text = "";
            txtDiaChi.Text = "";
            txtCMND.Text = "";
            txtSDT.Text = "";
            date_NgaySinh.Text = "";
            txtTen.Text = "";

        }

        private void griditem_Nhanvien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtMa.Text = griditem_Nhanvien.GetRowCellValue(griditem_Nhanvien.FocusedRowHandle, "MaNV").ToString();
            txtTen.Text = griditem_Nhanvien.GetRowCellValue(griditem_Nhanvien.FocusedRowHandle, "TenNV").ToString();
            date_NgaySinh.Text = griditem_Nhanvien.GetRowCellValue(griditem_Nhanvien.FocusedRowHandle, "NgaySinh").ToString();
           // txtDiaChi.Text = griditem_Nhanvien.GetRowCellValue(griditem_Nhanvien.FocusedRowHandle, "DiaChi").ToString();
            txtSDT.Text = griditem_Nhanvien.GetRowCellValue(griditem_Nhanvien.FocusedRowHandle, "SDT").ToString();
            txtCMND.Text = griditem_Nhanvien.GetRowCellValue(griditem_Nhanvien.FocusedRowHandle, "CMND").ToString();
            cbo_CV.Text = griditem_Nhanvien.GetRowCellValue(griditem_Nhanvien.FocusedRowHandle, "TenCV").ToString();
            string dc = griditem_Nhanvien.GetRowCellValue(griditem_Nhanvien.FocusedRowHandle, "DiaChi").ToString();
            string[] ds = dc.Split(',');
            int length = ds.Length;

            if (length == 3)
            {
                txtDiaChi.Text = ds[0];
                cboQH.Text = ds[1];
                cboTP.Text = ds[2];
            }
            else if (length == 4)
            {
                txtDiaChi.Text = ds[0];
                cboXP.Text = ds[1];
                cboQH.Text = ds[2];
                cboTP.Text = ds[3];
            }
            else if (length == 5)
            {
                txtDiaChi.Text = ds[0];
                cboXP.Text = ds[2];
                cboQH.Text = ds[3];
                cboTP.Text = ds[4];
            }
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa chứ??", "Thong Báo!", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    int maNV = int.Parse(txtMa.Text.ToString());
                    if (txtMa.Text == string.Empty)
                    {
                        MessageBox.Show("Ma trong");
                    }
                    else
                    {
                        nv.xoa(maNV);
                        MessageBox.Show("Thanh cong");
                    }
                    load_gridNhanVien();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Nhan vien nay dang con lam khong the xoa");
                }
            }

        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            if (ktraDuLieu() && txtMa.Text!="")
            {
                if (test.ktraCMND(txtCMND.Text) && test.ktraSDT(txtSDT.Text) && test.ktraNgaySinh(date_NgaySinh.Text.ToString()))
                {

                    DialogResult dr = MessageBox.Show("Bạn muốn sửa chứ??", "Thong Báo!", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        int ma = int.Parse(txtMa.Text);
                        string ten = txtTen.Text;
                        DateTime ngaysih = DateTime.Parse(date_NgaySinh.Text.ToString());
                        string diachi = txtDiaChi.Text + ", " + cboXP.Text + ", " + cboQH.Text + ", " + cboTP.Text;
                        string sdt = txtSDT.Text;
                        string cmnd = txtCMND.Text;
                        int chucvu = int.Parse(cbo_CV.Text.ToString());
                        nv.sua(ma, ten, ngaysih, diachi, sdt, cmnd, chucvu);

                        MessageBox.Show("Sua Thanh cong");
                        load_gridNhanVien();
                        xoaTextbox();
                    }
                }
                else
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
            }
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            if (ktraDuLieu())
            {
                if (test.ktraCMND(txtCMND.Text) && test.ktraSDT(txtSDT.Text) && test.ktraNgaySinh(date_NgaySinh.Text.ToString()))
                {
                    DialogResult dr = MessageBox.Show("Bạn muốn Lưu chứ??", "Thong Báo!", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {

                        bool tinhtrang;
                        bool gioitinh;
                        if (rdo_Nam.Checked)
                        {
                            gioitinh = true;
                        }
                        else
                        { gioitinh = false; }
                        if (rdo_Conlam.Checked)
                        { tinhtrang = true; }
                        else { tinhtrang = false; }

                        //int ma = int.Parse(txtMaNV.Text.ToString());
                        string ten = txtTen.Text;
                        DateTime ngaysih = DateTime.Parse(date_NgaySinh.Text.ToString());
                        string diachi = txtDiaChi.Text + ", " + cboXP.Text + ", " + cboQH.Text + ", " + cboTP.Text;
                        string sdt = txtSDT.Text;
                        string cmnd = txtCMND.Text;
                        int chucvu = int.Parse(cbo_CV.Text.ToString());

                        nv.luu(ten, ngaysih, diachi, sdt, cmnd, chucvu, gioitinh, tinhtrang);

                        MessageBox.Show("Thanh cong");
                        load_gridNhanVien();
                        xoaTextbox();
                    }
                }
                else
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu");

            }
            else
            {
                MessageBox.Show("Dữ liệu còn thiếu vui lòng nhập đầy đủ!!!");
            }
        }

        private void btnThem1_Click(object sender, EventArgs e)
        {
            xoaTextbox();
        }

        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        //kiểm tra sdt
        
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }    
        }
        //Load tỉnh thành phố
        public void load_CboTP()
        {
            cboTP.DataSource = nv.load_TinhTP();
            cboTP.DisplayMember = "Name";
            cboTP.ValueMember = "Id";
        }

        private void cboTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = cboTP.SelectedValue.ToString();
            string str2 = "DAL.Province";
            if (String.Compare(ma, str2, true) == 0)
            {

            }
            else
            {
                int ma1 = int.Parse(cboTP.SelectedValue.ToString());
                cboQH.DataSource = nv.load_QuanHuyen(ma1);
                cboQH.DisplayMember = "Name";
                cboQH.ValueMember = "Id";
            }

        }

        private void cboQH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = cboQH.SelectedValue.ToString();
            string str2 = "DAL.District";
            if (String.Compare(ma, str2, true) == 0)
            {

            }
            else
            {
                int ma2 = Int32.Parse(cboQH.SelectedValue.ToString());
                cboXP.DataSource = nv.load_XaPhuong(ma2);
                cboXP.DisplayMember = "Name";
                cboXP.ValueMember = "Id";
            }
        }

        
   
       
        private void date_NgaySinh_Leave(object sender, EventArgs e)
        {
            //if (ktraNgaySinh(date_NgaySinh.Text) == true)
            //{
            //    errorProvider2.Clear();
            //}
            //else
            //{
            //    errorProvider2.SetError((System.Windows.Forms.TextBox)sender, "Ngày sinh Không hợp lệ");
            //}
        }

      
    }
}