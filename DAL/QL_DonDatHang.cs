using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_DonDatHang
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_DonDatHang() { }

        //load cbo_ncc
        public IQueryable<NhaCungCap> load_cboMaNCC()
        {
            return ql.NhaCungCaps.Select(ncc => ncc);
        }
        public IQueryable<NguyenLieu> load_DSNL()
        {
            return ql.NguyenLieus.Select(t => t);
        }
        public IQueryable<NguyenLieuNCC> load_NLNCC()
        {
            return ql.NguyenLieuNCCs.Select(nlncc => nlncc);
        }
        public IQueryable<NguyenLieu> load_CBOTenNL()
        {
            return ql.NguyenLieus.Select(nl => nl);
        }
        //    load dl len gridds_DDH
        public IQueryable load_gridDSDDH()
        {
            var ddhang = from ddh in ql.DonDatHangs join ncc in ql.NhaCungCaps on ddh.MaNCC equals ncc.MaNCC select new { ddh.MaDDH, ddh.NgayNhap, ncc.MaNCC, ncc.SDT, ncc.DiaChi, ncc.Email, ddh.MaNV };
            return ddhang;

        }
        //load cbo tên sản phẩm theo nhà cung cấp
        public IQueryable load_tenSPTheoNCC(int mancc)
        {
            var nglieu = from nl in ql.NguyenLieus
                         where (nl.MaNL == mancc)
                         join nlncc in ql.NguyenLieuNCCs on nl.MaNL equals nlncc.MaNL
                         join ncc in ql.NhaCungCaps on nlncc.MaNCC equals ncc.MaNCC
                         select new { nlncc.MaNL, nl.SoLuong, nlncc.DVT, nlncc.DonGia };
            return nglieu;
        }
        public IQueryable load_tenNL(int ma)
        {
            var nglieu = from nlncc in ql.NguyenLieuNCCs
                         where (nlncc.MaNCC == ma)
                         join nl in ql.NguyenLieus on nlncc.MaNL equals nl.MaNL
                         select new { nl.TenNL, nl.MaNL };
            return nglieu;
        }


       
        public int laydongia(int ma)
        {
            var nlieu = from nl in ql.NguyenLieuNCCs where nl.MaNL == ma select nl.DonGia;
            int dongia = int.Parse(nlieu.First().ToString());
            return dongia;
        }
        //thêm đơn đặt hàng

        public int laysoluong(int ma)
        {
            var nlieu = from nl in ql.NguyenLieus where nl.MaNL == ma select nl.SoLuong;
            int soluong = int.Parse(nlieu.First().ToString());
            return soluong;
        }
        public string layDVT(int ma)
        {
            var nlieu = from nl in ql.NguyenLieuNCCs where nl.MaNL == ma select nl.DVT;
            string dvt = nlieu.First().ToString();
            return dvt;
        }
        public int layma(int ma)
        {
            var nlieu = from nl in ql.NguyenLieuNCCs where nl.MaNL == ma select nl.MaNL;
            int manl = int.Parse(nlieu.First().ToString());
            return manl;
        }
        public String layXuatXu(int ma)
        {
            var nlieu = from nl in ql.NguyenLieuNCCs where nl.MaNL == ma select nl.XuatXu;
            string xx = nlieu.First().ToString();
            return xx;
        }

        //Lấy mã cuối cùng
        public int layMaCuoiCung()
        {
            var ma = from dh in ql.DonDatHangs orderby dh.MaDDH descending select dh.MaDDH;
            int maDDH = ma.First();
            return maDDH;
        }
        //public void thêm phiếu xuất mới
        public void taoDDHMoi(int manv, int mancc, int tongtien)
        {
            DonDatHang ddh = new DonDatHang();
            ddh.NgayNhap = DateTime.Now;
            ddh.MaNV = manv;
            ddh.MaNCC = mancc;
            ddh.TongTien = tongtien;


            ql.DonDatHangs.InsertOnSubmit(ddh);
            ql.SubmitChanges();
        }

        public void luu(int mancc, int manv, DateTime ngaydat)
        {
            DonDatHang dhs = new DonDatHang();
            dhs.MaNCC = mancc;
            dhs.MaNV = manv;
            dhs.NgayNhap = ngaydat;
           
            ql.DonDatHangs.InsertOnSubmit(dhs);
            ql.SubmitChanges();

        }
        public void capNhatTongTien(int tongtien, int maddh)
        {
            DonDatHang dhs = ql.DonDatHangs.Where(t => t.MaDDH == maddh).FirstOrDefault();
            if(dhs !=null)
            {
                dhs.TongTien = tongtien;
                ql.SubmitChanges();
            }          
        }
        //khiem tra khoa
        public bool ma(int maddh)
        {
            var ddh = from ct in ql.CT_DDHs
                      where ct.MaDDH == maddh
                      select ct.MaDDH;
            return true;
        }
        //thêm chi tiết đơn hàng
        public void luu_chitiet(int manl, int soluong, int thanhtien)

        {

            CT_DDH ct = new CT_DDH();
            ct.MaNL = manl;

            ct.SoLuong = soluong;
            ct.ThanhTien = thanhtien;
            ql.CT_DDHs.InsertOnSubmit(ct);
            ql.SubmitChanges();
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
        public void themCTDDH(int maNL, int soluong, int thanhtien, int maddh)
        {
            CT_DDH ctddh = new CT_DDH();

            ctddh.MaNL = maNL;
            ctddh.SoLuong = soluong;
            ctddh.MaDDH = maddh;
            ctddh.ThanhTien = thanhtien;

            ql.CT_DDHs.InsertOnSubmit(ctddh);
            ql.SubmitChanges();

        }
        public void suaCTDDH(int maddh, int manl, int soluong)
        {
            CT_DDH dh = ql.CT_DDHs.Where(ct => ct.MaNL == manl && ct.MaDDH == maddh).FirstOrDefault();
            if (dh != null)
            {
                dh.SoLuong = soluong;
                ql.SubmitChanges();
            }
        }

        public void xoaCTDDH(int manl, int maddh)
        {
            CT_DDH dh = ql.CT_DDHs.Where(ct => ct.MaNL == manl && ct.MaDDH == maddh).FirstOrDefault();
            if (dh != null)
            {
                ql.CT_DDHs.DeleteOnSubmit(dh);
                ql.SubmitChanges();
            }
        }
   
        //tính tổng tiền cho mỗi đơn đặt hàng
        public int tinhtongtien(int ma)
        {
            var tong = from o in ql.CT_DDHs
                       where o.MaDDH == ma
                       select new { o.ThanhTien };
            var sum = tong.ToList().Select(c => c.ThanhTien).Sum();
            int tien = int.Parse(sum.ToString());
            return tien;
        }


    }
}
