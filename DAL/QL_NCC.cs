using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_NCC
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_NCC()
        {

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

        //Load ds nhà cung cấp
        public IQueryable<NhaCungCap> load_NCC()
        {
            return ql.NhaCungCaps.Select(t => t);
        }

        //Thêm mới nhà cung cấp
        public void luuNCC(string ten, string diachi, string sdt, string email)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc.TenNCC = ten;
            ncc.DiaChi = diachi;
            ncc.SDT = sdt;
            ncc.Email = email;

            ql.NhaCungCaps.InsertOnSubmit(ncc);
            ql.SubmitChanges();
        }

        //Sửa nhà cung cấp
        public void suaNCC(int ma, string ten, string diachi, string sdt, string email)
        {
            NhaCungCap ncc = ql.NhaCungCaps.Where(t => t.MaNCC == ma).FirstOrDefault();
            if (ncc != null)
            {
                ncc.TenNCC = ten;
                ncc.DiaChi = diachi;
                ncc.SDT = sdt;
                ncc.Email = email;

                ql.SubmitChanges();
            }
        }
        //Kiểm tra khóa ngoại 
        public bool ktraKhoaNgoaiNCC(int ma)
        {
            DonDatHang ncc = ql.DonDatHangs.Where(t => t.MaNCC == ma).FirstOrDefault();
            if (ncc == null)
                return true;
            else
                return false;
        }

        //Xóa nhà cung cấp
        public void xoaNCC(int ma)
        {
            NhaCungCap ncc = ql.NhaCungCaps.Where(t => t.MaNCC == ma).FirstOrDefault();
            if (ncc != null)
            {
                ql.NhaCungCaps.DeleteOnSubmit(ncc);
                ql.SubmitChanges();
            }
        }
    }
}
