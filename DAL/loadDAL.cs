using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class loadDAL
    {
        QL_DoAnDataContext ql= new QL_DoAnDataContext();
        public loadDAL() 
        { 
        }
        public IQueryable<NhaCungCap> load_TenNCC()
        {
            return ql.NhaCungCaps.Select(ncc => ncc);
        }
    }
}
