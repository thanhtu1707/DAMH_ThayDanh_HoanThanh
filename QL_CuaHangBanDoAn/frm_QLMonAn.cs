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
using System.Security.RightsManagement;
using System.IO;
using System.Text.RegularExpressions;

namespace QL_CuaHangBanDoAn
{
    public partial class frm_QLMonAn : DevExpress.XtraEditors.XtraForm
    {
        QL_Loai qll = new QL_Loai();
        QL_MonAn ma =new  QL_MonAn();
        public frm_QLMonAn()
        {
            InitializeComponent();
        }

        private void frm_QLMonAn_Load(object sender, EventArgs e)
        {
            //Món ăn
            load_CBOL();
            load_Datagridview();
            txtMaMonAn.Enabled = false;

        }
        //Load combobox loại món ăn
        public void load_CBOL()
        {
            cbo_LoaiMA.DataSource = ma.loadCboLoaiMA();
            cbo_LoaiMA.DisplayMember = "TenLoai";
            cbo_LoaiMA.ValueMember = "MaLoai";
        }
        //Món Ăn
        public void load_Datagridview()
        {
            dsMonAn.DataSource = ma.DSMonAn();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maMa = int.Parse(txtMaMonAn.Text);
            if (ma.ktraKhoaNgoai(maMa))
            {
                ma.xoa(maMa);
                MessageBox.Show("Xóa thành công");

                load_Datagridview();
                xoaTextBox();
            }   
            else
            {
                MessageBox.Show("Món ăn đang được sử dụng không thể xóa!!!");
            }    
        }
        public bool ktraDuLieu()
        {
            if (txtTenMonAn.Text == string.Empty && txtGiaBan.Text == string.Empty && cbo_LoaiMA.Text == string.Empty)
                return false;
            else
                return true;
               
        }
        public bool nhapChu(string hoten)
        {
            string str = "^[a-zA-Z0-9]*$";
            if (Regex.IsMatch(hoten, str) && hoten.Length > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ktraDuLieu())
            {
                if (picture_Product.Tag.ToString() != "")
                {
                    //int maMa = int.Parse(txtMaMonAn.Text);
                    string ten = txtTenMonAn.Text;
                    int gia = int.Parse(txtGiaBan.Text);
                    int maloai = int.Parse(cbo_LoaiMA.SelectedValue.ToString());
                    string hinh = picture_Product.Tag.ToString();
                    ma.luu(maloai, ten, gia, hinh);
                    save_Image_InProject();
                    MessageBox.Show("Thêm mới thành công");

                    load_Datagridview();
                    xoaTextBox();
                    btnLuu.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("Dữ liệu còn thiếu vui lòng nhập đầy đủ!!!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtGiaBan.Text==string.Empty)
            {
                MessageBox.Show("Vui lòng nhập giá muốn thay đổi");
            }
            else
            {
                int maMa =int.Parse(txtMaMonAn.Text);
                int gia = int.Parse(txtGiaBan.Text);
                string ten = txtTenMonAn.Text;
                ma.sua(maMa, gia, ten);
                MessageBox.Show("Sửa thành công");

                load_Datagridview();
                xoaTextBox();
                
            }
        }
        public void xoaTextBox()
        {
            txtGiaBan.Text = "";
            txtTenMonAn.Text = "";
            txtMaMonAn.Text = "";
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            xoaTextBox();
            btnLuu.Enabled = true;
        }

        private void dsMonAn_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaMonAn.Text = grid_MonAn.GetRowCellValue(grid_MonAn.FocusedRowHandle, "MaMonAn").ToString();
                txtTenMonAn.Text = grid_MonAn.GetRowCellValue(grid_MonAn.FocusedRowHandle, "TenMonAn").ToString();
                txtGiaBan.Text = grid_MonAn.GetRowCellValue(grid_MonAn.FocusedRowHandle, "GiaBan").ToString();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void picture_Product_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picture_Product.Image = new Bitmap(open.FileName);

                picture_Product.Tag = Path.GetFileName(open.FileName);
            }
            open.Dispose();
        }
        private void save_Image_InProject()
        {
            try
            {
                picture_Product.Image.Save(Application.StartupPath + "\\Image\\" + picture_Product.Tag.ToString());
            }
            catch { }
        }

        private void grid_MonAn_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaMonAn.Text = grid_MonAn.GetRowCellValue(grid_MonAn.FocusedRowHandle, "MaMonAn").ToString();
                txtTenMonAn.Text = grid_MonAn.GetRowCellValue(grid_MonAn.FocusedRowHandle, "TenMonAn").ToString();
                txtGiaBan.Text = grid_MonAn.GetRowCellValue(grid_MonAn.FocusedRowHandle, "GiaBan").ToString();
                cbo_LoaiMA.Text = grid_MonAn.GetRowCellValue(grid_MonAn.FocusedRowHandle, "TenLoai").ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}