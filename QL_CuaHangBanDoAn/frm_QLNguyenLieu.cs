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

namespace QL_CuaHangBanDoAn
{
    public partial class frm_QLNguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        QL_NguyenLieu qlnl = new QL_NguyenLieu();
        QL_TextBox test = new QL_TextBox();
        public frm_QLNguyenLieu()
        {
            InitializeComponent();
        }

        private void frm_QLNguyenLieu_Load(object sender, EventArgs e)
        {
            load_DSNguyenLieu();

            txtSL.Text ="0";
            txtMaNL.Enabled = false;
            txtSL.Enabled = false;

            rdoConHang.Enabled = false;
            rdoHetHang.Enabled = false;
            
        }
        public void load_DSNguyenLieu()
        {
            dsNguyenLieu.DataSource = qlnl.DSNguyenLieu();
        }
        public void xoaTextBox()
        {
            txtMaNL.Text = "";
            txtTenNL.Text = "";
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            xoaTextBox();
        }
        public bool ktraDuLieu()
        {
            if (txtTenNL.Text == string.Empty)
                return false;
            else
                return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ktraDuLieu())
            {              
                string ten = txtTenNL.Text;
                int sl = int.Parse(txtSL.Text);
                string tinhtrang = rdoConHang.Text;
                qlnl.luu(ten, sl, tinhtrang);
                MessageBox.Show("Thêm mới thành công");
                load_DSNguyenLieu();            
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int ma =int.Parse(txtMaNL.Text);
            if(qlnl.khoaNgoai(ma))
            {
                qlnl.xoa(ma);
                                MessageBox.Show("Xóa thành công");

                load_DSNguyenLieu();
                xoaTextBox();
            }    
            else
            {
                MessageBox.Show("Nguyên liệu của bạn đang được sử dụng!!!");
            }    

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(ktraDuLieu())
            {
                string ten = txtTenNL.Text;
                int ma = int.Parse(txtMaNL.Text);
                qlnl.sua(ten, ma);
                MessageBox.Show("Sửa thành công");

                load_DSNguyenLieu();
                xoaTextBox();
            }   
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
            }                
        }

        private void dsNguyenLieu_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaNL.Text = NL.GetRowCellValue(NL.FocusedRowHandle, "MaNL").ToString();
                txtTenNL.Text = NL.GetRowCellValue(NL.FocusedRowHandle, "TenNL").ToString();
                txtSL.Text = NL.GetRowCellValue(NL.FocusedRowHandle, "SoLuong").ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NL_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //TÚ ƠI TRƯA MAI LÀM TIẾP NGHE. BÙN NGỦ QUÉ 
        }
    }
}