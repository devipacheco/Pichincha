using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Extensions
{
    public static class IncludeExtension
    {
        public static IQueryable<T> Include<T>(this DbSet<T> dbSet,
                                                params Expression<Func<T, object>>[] includes)
                                                where T : class
        {
            IQueryable<T> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query == null ? dbSet : query;
        }
    }
}
