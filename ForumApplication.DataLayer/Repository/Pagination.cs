using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Repository
{
    public static class Pagination
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumber = 0, int pageSize = 10)
        {
            if (pageNumber < 0 || pageSize < 0 || pageSize == 0)
                throw new Exception("Paginated Error");

            return query.Skip(pageNumber * pageSize).Take(pageSize);
        }
    }
}
