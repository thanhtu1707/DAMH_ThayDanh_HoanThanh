using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace QL_CuaHangBanDoAn
{
    public partial class frm_DSDonDatHang : Form
    {
        public frm_DSDonDatHang()
        {
            InitializeComponent();
        }
        QL_DSDonDatHang dh = new QL_DSDonDatHang();
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
                    grid_DSDH.DataSource = dh.load_DSDDG(tungay, denngay);

                }
            }
            catch (Exception ex)
            { }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load_dsDH();
        }
        public void load_dsDH()
        {

            grid_DSDH.DataSource = dh.load_DSDH();
                
        }

        private void gridView_DDH_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string mahd = gridView_DDH.GetRowCellValue(gridView_DDH.FocusedRowHandle, "MaDDH").ToString();
                txtNgayHD.Text = gridView_DDH.GetRowCellValue(gridView_DDH.FocusedRowHandle, "NgayNhap").ToString();
                //txtTenNV.Text = gridView_DDH.GetRowCellValue(gridView_DDH.FocusedRowHandle, "TenNV").ToString();
                txtTongTien.Text = gridView_DDH.GetRowCellValue(gridView_DDH.FocusedRowHandle, "TongTien").ToString();
                txtMaHD.Text = mahd;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
