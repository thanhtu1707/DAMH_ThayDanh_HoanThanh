using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_TaiKhoan
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_TaiKhoan() { }
        public IQueryable load_gridTaiKhoan()
        {
            var taikhoan = from tk in ql.TaiKhoans join nv in ql.NhanViens on tk.TenTK equals nv.TenTK  select new { nv.MaNV, nv.TenNV, tk.TenTK, tk.MatKhau, tk.TinhTrang };
            return taikhoan;
        }
        public bool ktraKhoaNgoai(string tentk)
        {
            TaiKhoan tkhoan = ql.TaiKhoans.Where(tk => tk.TenTK == tentk).FirstOrDefault();
            if (tkhoan == null)
                return true;
            else
                return false;
        }
        public IQueryable<NhanVien> load_Manv()
        {
            return ql.NhanViens.Select(nv => nv);
        }

        public void xoa(String tentk)
        {

            TaiKhoan taikhoan = ql.TaiKhoans.Where(tk => tk.TenTK == tentk).FirstOrDefault();
            if (taikhoan != null)
            {
                ql.TaiKhoans.DeleteOnSubmit(taikhoan);
                ql.SubmitChanges();
            }
        }




        public void luu( String tentk, String matkhau, String tinnhtrang)
        {
            TaiKhoan tk = new TaiKhoan();
          
            tk.TenTK = tentk;
            tk.MatKhau = matkhau;
            tk.TinhTrang = tinnhtrang;
            ql.TaiKhoans.InsertOnSubmit(tk);
            ql.SubmitChanges();

        }

        public void update_NhanVien(string tentk,int manv)
        {
            NhanVien nv = ql.NhanViens.Where(t => t.MaNV == manv).FirstOrDefault();
            if (nv != null)
            {
                nv.TenTK = tentk;
                ql.SubmitChanges();
            }
        }
        public void sua( String tentk, String matkhau, String tinhtrang)
        {
            TaiKhoan taikhoan = ql.TaiKhoans.Where(tk => tk.TenTK == tentk).FirstOrDefault();
            if (taikhoan != null)
            {  
                taikhoan.MatKhau = matkhau;
                taikhoan.TinhTrang = tinhtrang;
                ql.SubmitChanges();
            }
        }
        //lấy tên tai khoan
        public string layTenTK(string tentkhoan)
        {
            var tentk = from n in ql.TaiKhoans where n.TenTK == tentkhoan select n.TenTK;
            string ten = tentk.First();
            return ten;
        }
    }
}
