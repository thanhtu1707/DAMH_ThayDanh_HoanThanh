using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_DangNhap
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_DangNhap()
        {

        }
        public string layTenNV(string tendn)
        {
            var tenNV = from n in ql.NhanViens where n.TenTK == tendn select n.TenNV;
            string ten = tenNV.First();
            return ten;
        }
        public int layMaNV(string tendn)
        {
            var tenNV = from n in ql.NhanViens where n.TenTK == tendn select n.MaNV;
            int ma = tenNV.First();
            return ma;
        }
        public int layChucVu(string tendn)
        {
            NhanVien nv = ql.NhanViens.FirstOrDefault(t => t.TenTK == tendn);
            if (nv == null)
                return 0;
            return nv.MaCV.Value;
        }
        public bool ktraDangNhap(string tendn, string pass)
        {
            TaiKhoan tk = ql.TaiKhoans.FirstOrDefault(t => t.TenTK == tendn && t.MatKhau == pass);
            if (tk == null)
                return false;
            else
                return true;
        }
        public string layTinhTrang(string tendn,string pass)
        {
            TaiKhoan tk = ql.TaiKhoans.FirstOrDefault(t => t.TenTK == tendn && t.MatKhau == pass);
            if (tk == null)
            {
                return "0";
            }
            else
                return tk.TinhTrang.ToString();
        }


       

    }

}
