using System;
using System.Linq;
using System.Linq.Expressions;

namespace Test.DataAccess.Extensions
{
    public static class OrderExtension
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, string Ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var childField = SortField.Split('.');
            var prop = Expression.Property(param, childField[0]);
            if (childField.Length > 1)
            {
                prop = Expression.Property(prop, childField[1]);
            }
            var exp = Expression.Lambda(prop, param);
            string method = (Ascending.Trim().ToLower() == "0") ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }
    }
}
