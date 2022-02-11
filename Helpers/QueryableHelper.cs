using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Helpers
{
    public static class QueryableHelper
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderField, bool isDescending)
        {
            Type type = typeof(T);

            PropertyInfo property = !string.IsNullOrEmpty(orderField) ? type.GetProperty(orderField) : null;
            if (property == null)
            {
                return source;
            }

            ParameterExpression param = Expression.Parameter(typeof(T), "p");
            MemberExpression prop = Expression.Property(param, orderField);
            LambdaExpression exp = Expression.Lambda(prop, param);
            string method = !isDescending ? "OrderBy" : "OrderByDescending";
            Type[] types = { source.ElementType, exp.Body.Type };
            MethodCallExpression mce = Expression.Call(typeof(Queryable), method, types, source.Expression, exp);
            return source.Provider.CreateQuery<T>(mce);
        }
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, int pageSize, int pageIndex)
        {
            return queryable.Skip(pageSize * pageIndex - 1).Take(pageSize);
        }
    }
}
