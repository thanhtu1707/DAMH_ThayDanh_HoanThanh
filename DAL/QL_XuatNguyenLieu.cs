using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_XuatNguyenLieu
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_XuatNguyenLieu()
        {

        }
        public IQueryable<NguyenLieu> load_DSNL()
        {
            return ql.NguyenLieus.Select(t => t);
        }
        //Lấy mã cuối cùng
        public int layMaCuoiCung()
        {
            var ma = from n in ql.PhieuXuats orderby n.MaPX descending select n.MaPX;
            int mapx = ma.First();
            return mapx;
        }
        public void themCTPX(int maNL, int soluong, int mapx)
        {
            CT_PhieuXuat ctpx = new CT_PhieuXuat();

            ctpx.MaNL = maNL;
            ctpx.SoLuong = soluong; 
            ctpx.MaPX = mapx;
            
            ql.CT_PhieuXuats.InsertOnSubmit(ctpx);
            ql.SubmitChanges();

        }
        //public void thêm phiếu xuất mới
        public void taoPhieuXuatMoi(int manv)
        {
            PhieuXuat px = new PhieuXuat();
            px.NgayXuat = DateTime.Now;
            px.MaNV = manv;
            px.TinhTrang =false;

            ql.PhieuXuats.InsertOnSubmit(px);
            ql.SubmitChanges();
        }
        public IQueryable ds_CTPhieuXuat(int mapx)
        {
            var chitiet = from n in ql.CT_PhieuXuats where n.MaPX==mapx join nl in ql.NguyenLieus on n.MaNL equals nl.MaNL select new { n.MaNL, nl.TenNL, n.SoLuong };
            return chitiet;
        }
        public void xoaCTPX(int mapx, int manl)
        {
            CT_PhieuXuat ctpx = ql.CT_PhieuXuats.Where(t => t.MaNL == manl && t.MaPX == mapx).FirstOrDefault();
            if(ctpx!=null)
            {
                ql.CT_PhieuXuats.DeleteOnSubmit(ctpx);
                ql.SubmitChanges();
            }    
        }
        public void suaCTPX(int manl, int soluong,int mapx)
        {
            CT_PhieuXuat ctpx = ql.CT_PhieuXuats.Where(t => t.MaNL == manl && t.MaPX == mapx).FirstOrDefault();
            if(ctpx !=null)
            {
                ctpx.SoLuong = soluong;

                ql.SubmitChanges();
            }       
        }
        public bool ktraTinhTrang(int mapx)
        {
            PhieuXuat px = ql.PhieuXuats.FirstOrDefault(t => t.MaPX == mapx);
            if (px.TinhTrang == true)
                return false;
            return true;
        }
        public bool ktraSLNL(int manl, int soluong)
        {
            NguyenLieu nl = ql.NguyenLieus.FirstOrDefault(t => t.MaNL == manl); 
            if (nl.SoLuong < soluong)
                return false;
            return true;
        }
        public void capNhatTinhTrangPX(int mapx)
        {
            PhieuXuat px = ql.PhieuXuats.FirstOrDefault(t => t.MaPX == mapx);
            if(px!=null)
            {
                px.TinhTrang = true;
                ql.SubmitChanges();
            }    
        }
        public void capNhatTinhTrangNL(int manl)
        {
            NguyenLieu px = ql.NguyenLieus.FirstOrDefault(t => t.MaNL == manl);
            if (px != null)
            {
                if (px.SoLuong.Value == 0)
                {
                    px.TinhTrang = "Hết Hàng";
                    ql.SubmitChanges();
                }
            }
        }
    }
}
