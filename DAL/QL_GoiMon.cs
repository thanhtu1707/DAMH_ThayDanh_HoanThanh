using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_GoiMon
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_GoiMon()
        {

        }
        public IQueryable<LoaiMonAn> load_Loai()
        {
            return ql.LoaiMonAns.Select(t => t);
        }
        public IQueryable<MonAn> load_DSMonAn()
        {
            return ql.MonAns.Select(t => t);
        }
        public IQueryable<MonAn> load_DSMonTheoLoai(int maloai)
        {
            return ql.MonAns.Where(t=>t.MaLoai==maloai).Select(t=>t);
        }
        public void taoHoaDonMoi(int manv)
        {
            HoaDon hd = new HoaDon();
            hd.NgayLap = DateTime.Now;
            hd.MaNV = manv;
            hd.TongTien = 0;
            hd.TinhTrang = false;

            ql.HoaDons.InsertOnSubmit(hd);
            ql.SubmitChanges();
        }
        public void themCTHD(int mama, int mahd,int sl,int thanhtien)
        {
            CT_HoaDon cthd = new CT_HoaDon();
            cthd.MaHD = mahd;
            cthd.MaMonAn = mama;
            cthd.SoLuong = sl;
            cthd.ThanhTien = thanhtien;

            ql.CT_HoaDons.InsertOnSubmit(cthd);
            ql.SubmitChanges();
        }
        public void sua(int mahd, int mama, int sl,int thanhtien)
        {
            CT_HoaDon cthd = ql.CT_HoaDons.Where(t => t.MaHD == mahd && t.MaMonAn == mama).FirstOrDefault();
            if (cthd != null)
            {
                cthd.SoLuong = sl;
                cthd.ThanhTien = thanhtien;
                ql.SubmitChanges();
            }    
        }
        public int layMa()
        {
            var nl = from n in ql.HoaDons orderby n.MaHD descending select n.MaHD;
            int ma = int.Parse(nl.First().ToString());
            return ma;
        }
        public void suaCTHD(int mama, int mahd, int sl)
        {
            CT_HoaDon cthd = ql.CT_HoaDons.FirstOrDefault(t => t.MaHD == mahd && t.MaMonAn == mama);
            if(cthd!=null)
            {
                cthd.SoLuong = sl;

                ql.SubmitChanges();
            }    
        }
        public void xoaCTHD(int mama, int mahd)
        {
            CT_HoaDon cthd = ql.CT_HoaDons.Where(t => t.MaHD == mahd && t.MaMonAn == mama).FirstOrDefault();
            if(cthd!=null)
            {
                ql.CT_HoaDons.DeleteOnSubmit(cthd);
                ql.SubmitChanges();
            }    
        }
        public bool ktraMon(int mama, int mahd)
        {
            CT_HoaDon cthd = ql.CT_HoaDons.FirstOrDefault(t => t.MaHD == mahd && t.MaMonAn == mama);
            if (cthd == null)
                return true;
            return false;
        }
        public void capNhatTinhTrangHD(int mahd, int tongtien)
        {
            HoaDon hd = ql.HoaDons.FirstOrDefault(t => t.MaHD == mahd);
            if(hd!=null)
            {
                hd.TinhTrang = true;
                hd.TongTien = tongtien;
                ql.SubmitChanges();
            }    
        }
        public IQueryable load_DSCT(int mahd)
        {
            var ct = from n in ql.CT_HoaDons where n.MaHD==mahd join t in ql.MonAns on n.MaMonAn equals t.MaMonAn select new { n.MaMonAn, t.TenMonAn, n.SoLuong,t.GiaBan, n.ThanhTien };
            return ct;
        }
        public int layTongTien(int mahd)
        {
            HoaDon hd = ql.HoaDons.FirstOrDefault(t => t.MaHD == mahd);
            return hd.TongTien.Value;
        }

        //tính tôngr tiền
        public int tinhtongtien(int ma)
        {
            var tong = from o in ql.CT_HoaDons
                       where o.MaHD == ma
                       select new { o.ThanhTien };
            var sum = tong.ToList().Select(c => c.ThanhTien).Sum();
            int tien = int.Parse(sum.ToString());
            return tien;
        }
        

    }
}
