using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_MonAn
    {

        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_MonAn()
        {

        }
        public IQueryable<LoaiMonAn> loadCboLoaiMA()
        {
            return ql.LoaiMonAns.Select(l => l);
        }
        public IQueryable DSMonAn()
        {
            var monan = from n in ql.MonAns join l in ql.LoaiMonAns on n.MaLoai equals l.MaLoai select new { n.MaMonAn, n.MaLoai, l.TenLoai, n.TenMonAn, n.GiaBan };
            return monan;
        }
        public int layMa()
        {
            var monan = from n in ql.MonAns orderby n.MaMonAn descending select n.MaMonAn;
            int ma = int.Parse(monan.First().ToString());
            return ma;
        }
        public void luu(int maloai, string ten, int gia,string hinh)
        {
            MonAn monan = new MonAn();
            monan.MaLoai = maloai;
            monan.TenMonAn = ten;
            monan.GiaBan = gia;
            monan.HinhAnh = hinh;
            ql.MonAns.InsertOnSubmit(monan);

            ql.SubmitChanges();
        }
        public bool ktraKhoaNgoai(int ma)
        {
            CT_HoaDon hd = ql.CT_HoaDons.Where(t => t.MaMonAn == ma).FirstOrDefault();
            if (hd == null)
                return true;
            else
                return false;
        }
        public void xoa(int ma)
        {
            MonAn monan = ql.MonAns.Where(t => t.MaMonAn == ma).FirstOrDefault();
            if (monan != null)
            {
                ql.MonAns.DeleteOnSubmit(monan);
                ql.SubmitChanges();
            }
        }
        public void sua(int ma, int giaban,string ten)
        {
            MonAn monan = ql.MonAns.Where(t => t.MaMonAn == ma).FirstOrDefault();
            if (monan != null)
            {
                monan.GiaBan = giaban;
                monan.TenMonAn = ten;
                ql.SubmitChanges();
            }
        }
        
    }
}
