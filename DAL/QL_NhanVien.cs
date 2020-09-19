using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class QL_NhanVien
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_NhanVien() { }
        public IQueryable load_datagridviewNV()
        {
            var nhanviens = from nv in ql.NhanViens join cv in ql.ChucVus on nv.MaCV equals cv.MaCV select new { nv.MaNV, nv.TenNV, nv.NgaySinh, nv.SDT, nv.DiaChi, nv.CMND, cv.TenCV,nv.GioiTinh,nv.TinhTrang };
            return nhanviens;
        }
        public IQueryable<ChucVu> load_cboChucvu()
        {
            return ql.ChucVus.Select(cv => cv);
        }
        public bool ktraKhoaNgoai(int ma)
        {
            NhanVien hd = ql.NhanViens.Where(t => t.MaNV == ma).FirstOrDefault();
            if (hd == null)
                return true;
            else
                return false;
        }
        public void xoa(int manv)
        {

            NhanVien nhanvien = ql.NhanViens.Where(nv => nv.MaNV == manv).FirstOrDefault();
            if (nhanvien != null)
            {
                ql.NhanViens.DeleteOnSubmit(nhanvien);
                ql.SubmitChanges();
            }
        }

        public void luu(String tensv, DateTime ngaysinh, String DiaChi, String SDT, String CMND, int tencv,bool giotinh,bool tinhtrang)
        {
            NhanVien nv = new NhanVien();
            nv.GioiTinh = giotinh;
            nv.TinhTrang = tinhtrang;
            nv.TenNV = tensv;
            nv.NgaySinh = ngaysinh;
            nv.DiaChi = DiaChi;
            nv.SDT = SDT;
            nv.CMND = CMND;
            nv.MaCV = tencv;
            ql.NhanViens.InsertOnSubmit(nv);
            ql.SubmitChanges();
        }
        public void sua(int manv, String tensv, DateTime ngaysinh, String DiaChi, String SDT, String CMND, int tencv)
        {
            NhanVien nv = ql.NhanViens.Where(nvs => nvs.MaNV == manv).FirstOrDefault();
            if (nv != null)
            {
                nv.TenNV = tensv;
                nv.NgaySinh = ngaysinh;
                nv.DiaChi = DiaChi;
                nv.SDT = SDT;
                nv.CMND = CMND;
                nv.MaCV = tencv;
                ql.SubmitChanges();
            }
        }
        //Load combobox các tỉnh và thành phố
        public IQueryable<Province> load_TinhTP()
        {
            return ql.Provinces.Where(t => t.CountryId == 237).Select(t => t);
        }

        //Load combobox các quận huyện theo tỉnh và thành phố
        public IQueryable<District> load_QuanHuyen(int ma)
        {
            return ql.Districts.Where(t => t.ProvinceId == ma).Select(t => t);
        }

        //Load combobox các phường xã theo quận huyện
        public IQueryable<Ward> load_XaPhuong(int ma)
        {
            return ql.Wards.Where(t => t.DistrictID == ma).Select(t => t);
        }
    }
}
