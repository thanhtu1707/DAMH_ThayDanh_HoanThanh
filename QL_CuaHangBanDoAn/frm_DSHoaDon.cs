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
    public partial class frm_DSHoaDon : DevExpress.XtraEditors.XtraForm
    {
        QL_DSHoaDon hd = new QL_DSHoaDon();
        public frm_DSHoaDon()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (date1.Value == null || date2.Value == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày muốn hiện thị!!!");
                }
                else
                {
                    DateTime tungay = date1.Value;
                    DateTime denngay = date2.Value;
                    gridHD.DataSource = hd.load_DSHoaDon(tungay, denngay);
                    txtTTHD.Text = hd.tinhtongtien(tungay, denngay).ToString();
                }
            }
            catch (Exception ex)
            { }
        }

        private void gridHD_Click(object sender, EventArgs e)
        {
            try
            {
                string mahd= gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle, "MaHD").ToString();
                txtNgayHD.Text= gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle, "NgayLap").ToString();
                txtTenNV.Text = gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle, "TenNV").ToString();
                txtTongTien.Text = gridViewHD.GetRowCellValue(gridViewHD.FocusedRowHandle, "TongTien").ToString();
                txtMaHD.Text = mahd;

                gridCTHD.DataSource = hd.load_CTHD(int.Parse(mahd));

            }
            catch (Exception ex)
            {

            }
        }

        private void frm_DSHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}