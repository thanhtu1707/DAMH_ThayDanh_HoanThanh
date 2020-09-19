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
using ThietKeControl;
using DevExpress.CodeParser;

namespace QL_CuaHangBanDoAn
{
    public partial class frm_QLNCC : DevExpress.XtraEditors.XtraForm
    {
        QL_NCC ncc = new QL_NCC();
        QL_TextBox test = new QL_TextBox();
        public frm_QLNCC()
        { 

            InitializeComponent();
        }

        private void frm_QLNCC_Load(object sender, EventArgs e)
        {
            load_CboTP();
            load_DSNCC();
            txtMaNCC.Enabled = false;
        }
        //Load tỉnh thành phố
        public void load_CboTP()
        {
            cboTP.DataSource = ncc.load_TinhTP();
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
                cboQH.DataSource = ncc.load_QuanHuyen(ma1);
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
                cboXP.DataSource = ncc.load_XaPhuong(ma2);
                cboXP.DisplayMember = "Name";
                cboXP.ValueMember = "Id";
            }
        }
        //Load danh sách ncc
        public void load_DSNCC()
        {
            ds_NCC.DataSource = ncc.load_NCC();
        }
        
        //Kiểm tra textbox
        public bool ktraTextBox()
        {
            if (txtTenNCC.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == " " || txtEmail.Text == "" || cboQH.Text == "" || cboTP.Text == "" )
            {
                return false;
            }
            else
                return true;
        }
        public void xoaTextBox()
        {
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            cboTP.SelectedIndex = 0;
            cboQH.Text = "";
            cboXP.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xoaTextBox();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(ktraTextBox())
            {
                if (test.ktraSDT(txtSDT.Text))
                {
                    string ten = txtTenNCC.Text;
                    string sdt = txtSDT.Text;
                    string email = txtEmail.Text;
                    string diachi = txtDiaChi.Text + ", " + cboXP.Text + ", " + cboQH.Text + ", " + cboTP.Text;

                    ncc.luuNCC(ten, diachi, sdt, email);

                    MessageBox.Show("Thêm mới thành công");
                    load_DSNCC();
                    btnLuu.Enabled = false;
                }
                else
                    MessageBox.Show("Số điện thoại không đúng định dạng");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ktraTextBox())
            {
                if (test.ktraSDT(txtSDT.Text))
                {
                    string ten = txtTenNCC.Text;
                    string sdt = txtSDT.Text;
                    string email = txtEmail.Text;
                    string diachi = txtDiaChi.Text + ", " + cboXP.Text + ", " + cboQH.Text + ", " + cboTP.Text;
                    int ma = int.Parse(txtMaNCC.Text);
                    ncc.suaNCC(ma, ten, diachi, sdt, email);

                    MessageBox.Show("Sửa thành công");
                    load_DSNCC();
                    btnLuu.Enabled = false;
                }
                else
                    MessageBox.Show("Số điện thoại không đúng định dạng");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maMa = int.Parse(txtMaNCC.Text);
            if (ncc.ktraKhoaNgoaiNCC(maMa))
            {
                ncc.xoaNCC(maMa);
                MessageBox.Show("Xóa thành công");

                load_DSNCC();
                xoaTextBox();
            }
            else
            {
                MessageBox.Show("Nhà cung cấp đang được sử dụng không thể xóa!!!");
            }
        }

        private void ds_NCC_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtMaNCC.Text = gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "MaNCC").ToString();
                txtTenNCC.Text = gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "TenNCC").ToString();
                txtSDT.Text = gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "SDT").ToString();
                txtEmail.Text = gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "Email").ToString();

                string dc= gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "DiaChi").ToString();
                string[] ds = dc.Split(',');
                int length = ds.Length;
 
                if(length==3)
                {
                    txtDiaChi.Text = ds[0];
                    cboQH.Text = ds[1];
                    cboTP.Text = ds[2];
                }   
                else if(length==4)
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
            catch (Exception ex)
            {

            }
        }

        private void gridNCC_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaNCC.Text = gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "MaNCC").ToString();
                txtTenNCC.Text = gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "TenNCC").ToString();
                txtSDT.Text = gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "SDT").ToString();
                txtEmail.Text = gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "Email").ToString();

                string dc = gridNCC.GetRowCellValue(gridNCC.FocusedRowHandle, "DiaChi").ToString();
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
            catch (Exception ex)
            {

            }
        }
    }
}