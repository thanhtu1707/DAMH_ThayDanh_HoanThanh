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
    public partial class frm_Order : DevExpress.XtraEditors.XtraForm
    {
        QL_GoiMon order = new QL_GoiMon();
        public int MaNV { get; set; }
        public int MaHD { get; set; }
        public frm_Order(int manv)
        {
            InitializeComponent();
            MaNV = manv;
        }

        private void frm_Order_Load(object sender, EventArgs e)
        {
            load_DSMonAn();
            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            
        }
        
        public void load_DSMonAn()
        {
            foreach (var item in order.load_DSMonAn())
            {
                Button btnMonAn = new Button();
                btnMonAn.Width = 100;
                btnMonAn.Height = 100;
                btnMonAn.Dock = DockStyle.Top;
                btnMonAn.Text = item.TenMonAn.ToString() + " - " + item.GiaBan.ToString();
                btnMonAn.Tag = item.MaMonAn.ToString();
                btnMonAn.Font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnMonAn.BackgroundImageLayout = ImageLayout.Stretch; 
                btnMonAn.ForeColor = Color.White;
                btnMonAn.Cursor = Cursors.Hand;
                try
                {

                    string path = @"C:\Users\Admin\Desktop\DAMH_Danh_DoAn\Image\";
                    btnMonAn.BackgroundImage = Image.FromFile(path + item.HinhAnh.ToString());
                }
                catch (Exception)
                {
                    btnMonAn.Image = null;

                }
                btnMonAn.Click += BtnMonAn_Click;
                flowLayoutPanel2.Controls.Add(btnMonAn);
                
                
            }
        }

        private void BtnMonAn_Click(object sender, EventArgs e)
        {
            Button btnMonAn = sender as Button;
            txtMaMA.Text = btnMonAn.Tag.ToString();     
            

            string tenMonAn= btnMonAn.Text;
            string[] arr = tenMonAn.Split('-');
            txtTen.Text = arr[0];

            string giaban = btnMonAn.Text;
            string[] arr1 = giaban.Split('-');
            txtDonGia.Text = arr1[1];
            
         

        }
        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            order.taoHoaDonMoi(MaNV);
            MaHD = order.layMa();
            lblMaHD.Text = MaHD.ToString();
            btnThem.Enabled = true;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
            btnInHD.Enabled = true;

        }
        public bool ktraTextBox()
        {
            if (txtMaMA.Text == " " || txtTen.Text == " " || txtSL.Value == 0)
                return false;
            return true;
        }
        public void load_DSCT()
        {
            gridCTHD.DataSource = order.load_DSCT(MaHD);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(ktraTextBox())
            {
                
                int maMonAn = int.Parse(txtMaMA.Text.ToString());
                int soluong = int.Parse(txtSL.Value.ToString());
                int dongia = int.Parse(txtDonGia.Text.ToString());
                if (order.ktraMon(maMonAn, MaHD) && maMonAn.ToString()!=null)
                {
                    int thanhtien1 = soluong * dongia;
                    txtThanhTien.Text = thanhtien1.ToString();
                   
                    order.themCTHD(maMonAn, MaHD, soluong,thanhtien1);
                    
                   
                    int tong = int.Parse(order.tinhtongtien(MaHD).ToString());
                    txtTongTien.Text = tong.ToString();
                    load_DSCT();
                    btnInHD.Enabled = true;
                }   
                else
                {
                    int tong = int.Parse(order.tinhtongtien(MaHD).ToString());
                    txtTongTien.Text = tong.ToString();
                    load_DSCT();
                }    
            }   
            else
            {
                MessageBox.Show("Vui lòng tạo hóa đơn!");
            }    
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (ktraTextBox())
            {
                int maMonAn = int.Parse(txtMaMA.Text);
                int soluong = int.Parse(txtSL.Value.ToString());
                int mahd = int.Parse(lblMaHD.Text);
               
                int dongia = int.Parse(txtDonGia.Text.ToString());
                int thanhtien1 = soluong * dongia;
                txtThanhTien.Text = thanhtien1.ToString();
                order.sua(mahd, maMonAn, soluong,thanhtien1);
                int tong = int.Parse(order.tinhtongtien(MaHD).ToString());
                txtTongTien.Text = tong.ToString();
                load_DSCT();
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = false;
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin muốn cập nhật");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (ktraTextBox())
            {
                int mamonan = int.Parse(txtMaMA.Text);
                int mahd = int.Parse(lblMaHD.Text);
                order.xoaCTHD(mamonan, mahd);

                //cập nhật tông tiền

                load_DSCT();
                txtTongTien.Text = order.tinhtongtien(MaHD).ToString();
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = false;
                
            }
            else
            {
                MessageBox.Show("vui lòng chọn món ăn muốn xóa!!!");
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (txtTienKhach.Text != "")
            {

                int tienkhach = int.Parse(txtTienKhach.Text.ToString());
                int tongtien = int.Parse(txtTongTien.Text);
                order.capNhatTinhTrangHD(MaHD, tongtien);
                if (tienkhach > tongtien)
                {
                    txtTienThoi.Text = (tienkhach - tongtien).ToString();
                    MessageBox.Show("Thanh toán thành công.");
                }
                else
                {
                    MessageBox.Show("Số tiền bạn nhập không đủ!Vui lòng kiểm tra lai.");
                }
                btnInHD.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập tiền khách!Vui lòng kiểm tra lại");
            }
            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            txtMaMA.Text = "";
            txtSL.Value = 1;
            txtTen.Text = "";
            txtThanhTien.Text = "";
            txtTongTien.Text = "";
            txtTienThoi.Text = "";
            gridV_CTHD.Columns.Clear();
        }

        private void gridV_CTHD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtMaMA.Text = gridV_CTHD.GetRowCellValue(gridV_CTHD.FocusedRowHandle, "MaMonAn").ToString();
            txtTen.Text = gridV_CTHD.GetRowCellValue(gridV_CTHD.FocusedRowHandle, "TenMonAn").ToString();
            txtSL.Text = gridV_CTHD.GetRowCellValue(gridV_CTHD.FocusedRowHandle, "SoLuong").ToString();
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void txtTienKhach_TextChanged(object sender, EventArgs e)
        {
            if (txtTongTien.Text == "")
            {
            }
            else
            {
                double tongtien = double.Parse(txtTongTien.Text);
                if(txtTienKhach.Text=="")
                {

                }   
                else
                {
                    double tienk = double.Parse(txtTienKhach.Text);
                    if (tienk < tongtien)
                    { }
                    else
                    {
                        double tienthoi = tienk - tongtien;
                        txtTienThoi.Text = tienthoi.ToString();
                    }
                }             
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }    
        }

        private void txtThanhTien_EditValueChanged(object sender, EventArgs e)
        {
            int soluong = int.Parse(txtSL.Text);
            int dongia = int.Parse(txtDonGia.Text);
            int thanhtien = soluong * dongia;
            txtTienThoi.Text = thanhtien.ToString();
        }
    }
}