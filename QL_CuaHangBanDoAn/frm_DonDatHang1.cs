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
    public partial class frm_DonDatHang1 : DevExpress.XtraEditors.XtraForm
    {
        QL_DonDatHang DDH = new QL_DonDatHang();
        public int maDDH { get; set; }
        public int maNVien { get; set; }
        public frm_DonDatHang1(int maNV)
        {
            InitializeComponent();
            maNVien = maNV;
        }

        private void frm_DonDatHang1_Load(object sender, EventArgs e)
        {
            load_cboNCC();
            load_DSNguyenLieu();
            maDDH = DDH.layMaCuoiCung();
            txtMaDDH.Text = maDDH.ToString();
            btnThemDH.Enabled = false;
          
        }
        public void load_DSNguyenLieu()
        {
            grid_DSDH.DataSource = DDH.load_DSNL();
        }
        public void load_cboNCC()
        {
            cbo_TenNCC.DataSource = DDH.load_cboMaNCC();
            cbo_TenNCC.DisplayMember = "TenNCC";
            cbo_TenNCC.ValueMember = "MaNCC";
        }
        public void loadgrid_CTDDH()
        {
            grid_CTDDH.DataSource = DDH.load_CTDDH(maDDH);
        }

        private void cbo_TenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhaCungCap ncc = cbo_TenNCC.SelectedItem as NhaCungCap;
            // txtMaNCC.Text = ncc.MaNCC;
            txtSDT.Text = ncc.SDT;
            txtEmail.Text = ncc.Email;
            txtDiaChi.Text = ncc.DiaChi;

            string ma = cbo_TenNCC.SelectedIndex.ToString();
            string ma2 = "DAL.NhaCungCap";
            if (string.Compare(ma, ma2, true) == 0)
            {

            }
            else
            {
                int ma1 = int.Parse(ma);
                cbo_tenNL.DataSource = DDH.load_tenNL(ma1);
                cbo_tenNL.DisplayMember = "TenNL";
                cbo_tenNL.ValueMember = "MaNL";
            }
        }

        private void cbo_tenNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = cbo_tenNL.SelectedValue.ToString();
            string ma2 = "DAL.NguyenLieu";

            if (string.Compare(ma, ma2, true) == 0)
            {

            }
            else
            {
                int ma1 = int.Parse(ma);
                txtDonGia.Text = DDH.laydongia(ma1).ToString();
                txtMaNL.Text = DDH.layma(ma1).ToString();
                txtDVT.Text = DDH.layDVT(ma1).ToString();
                txtXuatXu.Text = DDH.layXuatXu(ma1).ToString();

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSL.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng!.");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn muốn Lưu chứ??", "Thong Báo!", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {


                    //them chi tiết đơn đặt hàng
                    
                    int manl = int.Parse(txtMaNL.Text);
                    if (manl != null)
                    {
                        int soluong = int.Parse(txtSL.Text.ToString());
                        int dongia = int.Parse(txtDonGia.Text.ToString());
                        int thanhtien1 = soluong * dongia;
                        txtThanhtien.Text = thanhtien1.ToString();
                        //lấy phiếu xuất cuối cùng                   
                        
                       // maDDH = DDH.layMaCuoiCung();
                        DDH.themCTDDH(manl, soluong, thanhtien1, maDDH);
                        int tong1 = int.Parse(DDH.tinhtongtien(maDDH).ToString());
                        txtTongTien.Text = tong1.ToString();
                        DDH.capNhatTongTien(tong1, maDDH);
                        
                       
                        MessageBox.Show("Thêm thành công");
                        loadgrid_CTDDH();
                    }

                   
                    //cập nhật tổng tiền trong đơn đặt hàng
                    
                   

                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtDonGia.Text = "";
            txtSL.Text = "";
            txtThanhtien.Text = "";
            txtTongTien.Text = "";
            txtDVT.Text = "";
            txtXuatXu.Text = "";
            txtMaNL.Text = "";
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa chứ??", "Thong Báo!", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {

                if (txtMaDDH.Text == string.Empty && txtMaNL.Text == string.Empty)
                {
                    MessageBox.Show("Tên trong");
                }
                else
                {
                    int manl = int.Parse(txtMaNL.Text);
                    int maddh = int.Parse(txtMaDDH.Text);
                    DDH.xoaCTDDH(manl, maddh);
                    int tong = int.Parse(DDH.tinhtongtien(maDDH).ToString());
                    DDH.capNhatTongTien(tong, maDDH);
                    MessageBox.Show("Xóa thành công!");
                    loadgrid_CTDDH();
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn sửa chứ??", "Thong Báo!", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {

                if (txtMaDDH.Text == string.Empty && txtMaNL.Text == string.Empty)
                {
                    MessageBox.Show("Tên trong");
                }
                else
                {
                    int manl = int.Parse(txtMaNL.Text);
                    int maddh = int.Parse(txtMaDDH.Text);
                    int soluong = int.Parse(txtSL.Text);
                    DDH.suaCTDDH(maddh, manl, soluong);
                    int tong = int.Parse(DDH.tinhtongtien(maDDH).ToString());
                    txtTongTien.Text = tong.ToString();
                    DDH.capNhatTongTien(tong, maDDH);
                    MessageBox.Show("Sửa thành công!");
                    loadgrid_CTDDH();
                }

            }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btntao_Click(object sender, EventArgs e)
        {
            btnThemDH.Enabled = true;
            int mancc = int.Parse(cbo_TenNCC.SelectedValue.ToString());
            txtTongTien.Text = "0";
            int tong = int.Parse(txtTongTien.Text.ToString());
            DDH.taoDDHMoi(maNVien, mancc, tong);
            MessageBox.Show("Tao thanh cong");
            cbo_TenNCC.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;


            maDDH = DDH.layMaCuoiCung();
            txtMaDDH.Text = maDDH.ToString();
            

        }

       
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            cbo_TenNCC.Enabled = true;
        }

        private void grid_CTDH_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtMaNL.Text = grid_CTDH.GetRowCellValue(grid_CTDH.FocusedRowHandle, "MaNL").ToString();
            cbo_tenNL.Text = grid_CTDH.GetRowCellValue(grid_CTDH.FocusedRowHandle, "TenNL").ToString();
            txtDVT.Text = grid_CTDH.GetRowCellValue(grid_CTDH.FocusedRowHandle, "DVT").ToString();
            txtDonGia.Text = grid_CTDH.GetRowCellValue(grid_CTDH.FocusedRowHandle, "DonGia").ToString();
            txtSL.Text = grid_CTDH.GetRowCellValue(grid_CTDH.FocusedRowHandle, "SoLuong").ToString();
            txtXuatXu.Text = grid_CTDH.GetRowCellValue(grid_CTDH.FocusedRowHandle, "XuatXu").ToString();
            txtThanhtien.Text = grid_CTDH.GetRowCellValue(grid_CTDH.FocusedRowHandle, "ThanhTien").ToString();


        }
        //cập nhật lại tổng tiền

    }
}