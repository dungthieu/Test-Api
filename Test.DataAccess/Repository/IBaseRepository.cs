using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Test.DataAccess.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);

        T GetById(long id);

        IQueryable<T> GetAll();


        IQueryable<T> Query(Expression<Func<T, bool>> filter);

        T Update(T entity);

        bool UpdateRange(List<T> entities);

        T Insert(T entity);

        List<T> InsertRange(List<T> entities);

        List<T> InsertMulti(List<T> entity);

        bool Delete(T entity);

        bool Delete(dynamic id);

        bool DeleteMulti(List<T> entity);

        T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        List<T> FindAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
    }
}
