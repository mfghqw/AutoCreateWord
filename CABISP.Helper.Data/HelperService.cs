using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace CABISP.Helper.Data
{
 public   class HelperService
    {
        public static List<zf_HelperType> GetAllHelper()
        {
            HelperDB db = new HelperDB();
            var list = db.zf_HelperType.Where(t => t.IsDel == false && t.ApplicationScope ==1).Include(t => t.zf_HelperContent);
           return list.ToList();
        }
    }
}
