using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_DSHoaDon
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_DSHoaDon()
        {

        }
        public IQueryable load_DSHoaDon(DateTime tungay, DateTime denNgay)
        {
            var hoadons = from hd in ql.HoaDons where hd.NgayLap >= tungay && hd.NgayLap <= denNgay join nv in ql.NhanViens on hd.MaNV equals nv.MaNV select new { hd.MaHD, nv.TenNV, hd.NgayLap, hd.TongTien };
            return hoadons;
        }
        public IQueryable load_CTHD(int maHD)
        {
            var ct_hoadons = from cthd in ql.CT_HoaDons where cthd.MaHD == maHD join ma in ql.MonAns on cthd.MaMonAn equals ma.MaMonAn select new { ma.TenMonAn, cthd.SoLuong, ma.GiaBan, cthd.ThanhTien };
            return ct_hoadons;
        }
        public int tinhtongtien(DateTime tungay, DateTime denNgay)
        {
            var tong = from hd in ql.HoaDons
                       where hd.NgayLap >= tungay && hd.NgayLap <= denNgay
                       select new { hd.TongTien };
            var sum = tong.ToList().Select(c => c.TongTien).Sum();
            int tien = int.Parse(sum.ToString());
            return tien;
        }
    }
}
