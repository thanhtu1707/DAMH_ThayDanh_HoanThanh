using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLy
    {
        QL_DoAnDataContext ql = new QL_DoAnDataContext();
        public QuanLy() { }
        //public IQueryable<DonDatHang> loadDonDatHang()
        //{

        //}
        public IQueryable<NhaCungCap> load_cboTenNCC()
        {
            return ql.NhaCungCaps.Select(ncc => ncc);


        }
    }
}
