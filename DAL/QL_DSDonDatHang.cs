using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_DSDonDatHang
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_DSDonDatHang()
        {

        }

        public IQueryable load_DSDDG(DateTime tungay, DateTime denNgay)
        {
            var ddh = from dh in ql.DonDatHangs where dh.NgayNhap >= tungay && dh.NgayNhap <= denNgay
                      join nv in ql.NhanViens on dh.MaNV equals nv.MaNV 
                      join ncc in ql.NhaCungCaps on dh.MaNCC equals ncc.MaNCC
                      select new { dh.MaDDH,nv.TenNV, dh.MaNCC, ncc.TenNCC, dh.NgayNhap, ncc.SDT, ncc.Email, ncc.DiaChi, dh.TongTien };
            return ddh;
        }
        public IQueryable load_CTDDH(int maddh)
        {
            var nglieu = from ctdh in ql.CT_DDHs
                         where ctdh.MaDDH == maddh
                         join nl in ql.NguyenLieus on ctdh.MaNL equals nl.MaNL
                         join nlncc in ql.NguyenLieuNCCs on nl.MaNL equals nlncc.MaNL
                         select new { ctdh.MaNL, nl.TenNL, nlncc.DVT, nlncc.XuatXu, ctdh.SoLuong, nlncc.DonGia, ctdh.ThanhTien };
            return nglieu;
        }
        public IQueryable load_DSDH()
        {
            var dsDH = from dh in ql.DonDatHangs
                       join ncc in ql.NhaCungCaps on dh.MaNCC equals ncc.MaNCC
                       select new { dh.MaDDH, dh.MaNCC, ncc.TenNCC, dh.NgayNhap, ncc.SDT, ncc.Email, ncc.DiaChi,dh.TongTien };
            return dsDH;
                       
        }
    }
}
