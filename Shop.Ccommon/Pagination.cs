using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ccommon
{
    public static class Pagination
    {
        public static IQueryable<TSource> ToPaged<TSource>(this IQueryable<TSource> sources,int page, int pagesize,out int rowCount)
        {
            rowCount = sources.Count();
            return sources.Skip((page - 1) * pagesize).Take(pagesize);
        }
    }
}
