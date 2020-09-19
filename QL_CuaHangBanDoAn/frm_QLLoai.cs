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
    public partial class frm_QLLoai : DevExpress.XtraEditors.XtraForm
    {
        QL_Loai qll = new QL_Loai();
        QL_TextBox test = new QL_TextBox();
        public frm_QLLoai()
        {
            InitializeComponent();
        }

        private void frm_QLLoai_Load(object sender, EventArgs e)
        {
            load_DataGridView();
        }
        public void load_DataGridView()
        {
            ds_Loai.DataSource= qll.ds_LoaiMonAn();
        }

        private void gridView1_Loai_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtMaLoai.Text = gridView1_Loai.GetRowCellValue(gridView1_Loai.FocusedRowHandle, "MaLoai").ToString();
            txtTenLoai.Text = gridView1_Loai.GetRowCellValue(gridView1_Loai.FocusedRowHandle, "TenLoai").ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int ma = int.Parse(txtMaLoai.Text);
            if (qll.ktraKhoaNgoaiLoai(ma))
            {
                qll.xoaLoai(ma);
                MessageBox.Show("Xóa thành công.");

                txtMaLoai.Text = "";
                txtTenLoai.Text = "";
                load_DataGridView();
            }
            else
            {
                MessageBox.Show("Dữ liệu đang được sử dụng. Không thể xóa!!!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
            }
            else
            {
                int ma = int.Parse(txtMaLoai.Text);
                qll.suaLoai(ma, txtTenLoai.Text);
                MessageBox.Show("Sửa thành công.");

                txtMaLoai.Text = "";
                txtTenLoai.Text = "";
                load_DataGridView();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
            }
            else
            {  
                qll.luuLoai(txtTenLoai.Text);
                MessageBox.Show("Thêm mới thành công.");

                txtMaLoai.Text = "";
                txtTenLoai.Text = "";
                load_DataGridView();
            }
        }
    }
}