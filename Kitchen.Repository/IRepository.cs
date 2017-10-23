using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kitchen.CommonModel.Base;

namespace Kitchen.Repository
{
    public interface IRepository<T> where T : BaseIntEntity
    {
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        IQueryable<T> QueryIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindWT(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindWTAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindWT(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> FindWTAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> FindOneIncludingWTForAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        int Count();
        Task<int> CountAsync();
        T FindOne(int id);
        T FindOneWT(int id);
        T FindOne(Expression<Func<T, bool>> predicate);
        T FindOneWT(Expression<Func<T, bool>> predicate);
        T FindOne(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T FindOneWT(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> FindOneAsync(int id);
        Task<T> FindOneWTAsync(int id);
        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindOneWTAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> FindOneWTAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        void ClearContext();
        void Commit();
        Task CommitAsync();
        void Reset();
    }
}
