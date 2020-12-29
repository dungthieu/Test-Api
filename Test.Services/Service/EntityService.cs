
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Test.DataAccess.Repository;

namespace Test.Services.Service
{
    public interface IEntityService<T>
    {

        T GetById(int id);
        IEnumerable<T> GetAll();
        T Update(T entity);
        T Insert(T entity);
        List<T> InsertMulti(List<T> entity);
        bool Delete(T entity);
        bool Delete(dynamic dynamic);
        bool DeleteMulti(List<T> entity);
        T Find(Expression<Func<T, bool>> exception, params Expression<Func<T, object>>[] includes);
        List<T> FindAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
    }

    public class EntityService<T> : IEntityService<T> where T : class
    {
        protected readonly IUnitOfWork UnitOfwork;
        readonly IBaseRepository<T> _repository;
        protected EntityService(IUnitOfWork unitOfWork, IBaseRepository<T> repository)
        {
            UnitOfwork = unitOfWork;
            _repository = repository;
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            _repository.Insert(entity);
            UnitOfwork.SaveChanges();
            return entity;
        }

        public List<T> InsertMulti(List<T> entity)
        {
            try
            {
                _repository.InsertMulti(entity);
                UnitOfwork.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _repository.Delete(entity);
                UnitOfwork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(dynamic id)
        {
            return _repository.Delete(id);
        }

        public bool DeleteMulti(List<T> entity)
        {
            try
            {
                _repository.DeleteMulti(entity);
                UnitOfwork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return _repository.Find(expression, includes);
        }
        public List<T> FindAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return _repository.FindAll(expression, includes);
        }
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _repository.Update(entity);
            UnitOfwork.SaveChanges();

            return entity;
        }

    }
}
