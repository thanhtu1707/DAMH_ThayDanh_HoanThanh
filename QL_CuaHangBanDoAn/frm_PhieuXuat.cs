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
    public partial class frm_PhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        QL_XuatNguyenLieu xuatnl = new QL_XuatNguyenLieu();
        public int maPX { get; set; }
        public int maNV;
        public frm_PhieuXuat(int manv)
        {
            InitializeComponent();
            maNV = manv;
        }
        
        private void frm_PhieuXuat_Load(object sender, EventArgs e)
        {
            load_DSNguyenLieu();
        }

        public void load_DSNguyenLieu()
        {
            gridDSNL.DataSource = xuatnl.load_DSNL();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtTenNL.Text = gridV_CTPX.GetRowCellValue(gridV_CTPX.FocusedRowHandle, "TenNL").ToString();
                txtSL.Text = gridV_CTPX.GetRowCellValue(gridV_CTPX.FocusedRowHandle, "SoLuong").ToString();
                txtMaNL.Text = gridV_CTPX.GetRowCellValue(gridV_CTPX.FocusedRowHandle, "MaNL").ToString();
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }
            catch(Exception ex)
            {

            }
        }

        private void gv_NL_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtTenNL.Text = gv_NL.GetRowCellValue(gv_NL.FocusedRowHandle, "TenNL").ToString();
                txtSL.Text = gv_NL.GetRowCellValue(gv_NL.FocusedRowHandle, "SoLuong").ToString();
                txtMaNL.Text = gv_NL.GetRowCellValue(gv_NL.FocusedRowHandle, "MaNL").ToString();
            }
            catch(Exception ex)
            {

            }
        }
        public bool ktraTextbox()
        {
            if (txtMaNL.Text == " " || txtSL.Value == 0)
            {
                return false;
            }
            else return true;
        }
        public void load_DSCTPX()
        {
            gridCTPX.DataSource=xuatnl.ds_CTPhieuXuat(maPX);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(ktraTextbox())
            {
                
                int manl = int.Parse(txtMaNL.Text);
                int soluong = int.Parse(txtSL.Value.ToString());
                maPX = int.Parse(txtMaPX.Text);
                if (xuatnl.ktraSLNL(manl, soluong) == true)
                {
                    //thêm chi tiết vào phiếu xuất cuối cùng
                    xuatnl.themCTPX(manl, soluong, maPX);
                    MessageBox.Show("Thêm thành công");
                    xuatnl.capNhatTinhTrangNL(manl);
                    load_DSCTPX();
                    xuatnl.load_DSNL();
                    btnIn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Số Lượng Tồn Không Đủ Để Xuất Nguyên Liệu");
                }    
            }    
            else
            {
                MessageBox.Show("Vui Lòng Nhập Nguyên Liệu Cần Xuất");
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if(xuatnl.ktraTinhTrang(maPX)==true)
            {
                if (txtMaNL.Text == " ")
                {
                    MessageBox.Show("Vui lòng chọn nguyên liệu cần xóa");
                }
                else
                {
                    int manl = int.Parse(txtMaNL.Text);
                    xuatnl.xoaCTPX(maPX, manl);
                    load_DSCTPX();
                  
                }
            } 
            else
            {
                MessageBox.Show("Chi Tiết Phiếu Xuất Đã Được In Không Thể Xóa!!!");
            }    
            
            
        }
        public void anButton()
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnIn.Enabled = false;
        }
        private void btnTaoPX_Click(object sender, EventArgs e)
        {
            xuatnl.taoPhieuXuatMoi(maNV);
            txtMaPX.Text = xuatnl.layMaCuoiCung().ToString();
            btnThem.Enabled = true;
            btnTaoPX.Enabled = false;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            btnTaoPX.Enabled = true;
            xuatnl.capNhatTinhTrangPX(maPX);
            anButton();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ktraTextbox())
            {
                int manl = int.Parse(txtMaNL.Text);
                int soluong = int.Parse(txtSL.Value.ToString());
                if (xuatnl.ktraSLNL(manl, soluong) == true)
                {
                    xuatnl.suaCTPX(manl, soluong, maPX);
                    load_DSCTPX();
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Số Lượng Xuất Lớn Hơn Không Nhé");
            }
        }
            
    }
}