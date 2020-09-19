using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_NguyenLieu
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_NguyenLieu()
        {

        }
        public IQueryable<NguyenLieu> DSNguyenLieu()
        {
            return ql.NguyenLieus.Select(ma => ma);
        }
        public int layMa()
        {
            var nl = from n in ql.NguyenLieus orderby n.MaNL descending select n.MaNL;
            int ma = int.Parse(nl.First().ToString());
            return ma;
        }
        public void luu(string ten,int soluong,string tinhtrang)
        {
            NguyenLieu nglieu = new NguyenLieu();
            nglieu.TenNL = ten;
            nglieu.SoLuong=soluong;
            nglieu.TinhTrang = tinhtrang;
            ql.NguyenLieus.InsertOnSubmit(nglieu);

            ql.SubmitChanges();
        }
        public bool ktraNLTonTai(string tenNL)
        {
            var nguyenlieu = from n in ql.NguyenLieus where (n.TenNL == tenNL) select new { n.MaNL};
            if (nguyenlieu == null)
                return true;
            else
                return false;
        }
        public bool khoaNgoai(int ma)
        {
            CT_DDH ddh = ql.CT_DDHs.Where(t => t.MaNL == ma).FirstOrDefault();
            CT_PhieuXuat px = ql.CT_PhieuXuats.Where(t => t.MaNL == ma).FirstOrDefault();
            if (ddh==null && px==null)
                return true;
            else
                return false;
        }
        public void xoa(int ma)
        {
            NguyenLieu nl = ql.NguyenLieus.Where(t => t.MaNL == ma).FirstOrDefault();
            if (nl != null)
            {
                ql.NguyenLieus.DeleteOnSubmit(nl);
                ql.SubmitChanges();
            }
        }
        public void sua(string tennl, int ma)
        {
            NguyenLieu nglieu = ql.NguyenLieus.Where(t => t.MaNL == ma).FirstOrDefault();
            if (nglieu != null)
            {
                nglieu.TenNL = tennl;
                ql.SubmitChanges();
            }

        }
    }
}
