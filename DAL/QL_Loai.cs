using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_Loai
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QL_Loai()
        {

        }
        //Hiển thị danh sách lên gridview
        public IQueryable<LoaiMonAn> ds_LoaiMonAn()
        {
            return ql.LoaiMonAns.Select(t => t);
        }    

        //Thêm mới một loại
        public void luuLoai(string tenLoai)
        {
            LoaiMonAn lma = new LoaiMonAn();
            lma.TenLoai =tenLoai;
            
            ql.LoaiMonAns.InsertOnSubmit(lma);

            ql.SubmitChanges();
        }

        //Sửa một loại
        public void suaLoai(int ma,string tenLoai)
        {
            LoaiMonAn loai = ql.LoaiMonAns.Where(t => t.MaLoai == ma).FirstOrDefault();
            if (loai != null)
            {
                loai.TenLoai = tenLoai;
                ql.SubmitChanges();
            }
        }

        //Xóa 1 loại
        //Kiểm tra khóa ngoại
        public bool ktraKhoaNgoaiLoai(int ma)
        {
            MonAn hd = ql.MonAns.Where(t => t.MaLoai == ma).FirstOrDefault();
            if (hd == null)
                return true;
            else
                return false;
        }
        //Xóa
        public void xoaLoai(int ma)
        {
            LoaiMonAn loaima = ql.LoaiMonAns.Where(t => t.MaLoai == ma).FirstOrDefault();
            if (loaima != null)
            {
                ql.LoaiMonAns.DeleteOnSubmit(loaima);
                ql.SubmitChanges();
            }
        }
    }
}
