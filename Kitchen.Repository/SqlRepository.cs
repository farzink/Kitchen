using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kitchen.CommonModel.Base;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Repository
{
    public class SqlRepository<Q, T> : IRepository<T> where T : BaseIntEntity where Q : DbContext
    {
        private readonly Q context;
        private readonly DbSet<T> set;

        public SqlRepository(Q context)
        {
            this.context = context;
            set = this.context.Set<T>();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return set.Where(predicate).AsQueryable();
        }

        //should be added
        public IQueryable<T> QueryIncluding(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.Where(predicate).AsQueryable();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return set.Where(predicate).AsNoTracking().AsEnumerable();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await set.Where(predicate).AsNoTracking().ToListAsync();
            //return await set.Where(predicate).AsNoTracking().ToAsyncEnumerable();
        }

        public IEnumerable<T> FindWT(Expression<Func<T, bool>> predicate)
        {
            return set.Where(predicate).AsTracking().AsEnumerable();
        }

        public async Task<IEnumerable<T>> FindWTAsync(Expression<Func<T, bool>> predicate)
        {
            return await set.Where(predicate).AsTracking().ToListAsync();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            var results = query.Where(predicate).AsNoTracking().AsEnumerable();
            return results;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return await query.Where(predicate).AsNoTracking().ToListAsync();
        }

        public IEnumerable<T> FindWT(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            var results = query.Where(predicate).AsTracking().AsEnumerable();
            return results;
        }

        public async Task<IEnumerable<T>> FindWTAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return await query.Where(predicate).AsTracking().ToListAsync();
        }

        public int Count()
        {
            return set.Count();
        }

        public async Task<int> CountAsync()
        {
            return await set.CountAsync();
        }

        public T FindOne(int id)
        {
            return set.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public T FindOneWT(int id)
        {
            return set.FirstOrDefault(e => e.Id == id);
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return set.AsNoTracking().FirstOrDefault(predicate);
        }

        public T FindOneWT(Expression<Func<T, bool>> predicate)
        {
            return set.AsTracking().FirstOrDefault(predicate);
        }

        public T FindOne(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.AsNoTracking().FirstOrDefault(predicate);
        }

        public T FindOneWT(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.AsNoTracking().FirstOrDefault(predicate);
        }

        public async Task<T> FindOneAsync(int id)
        {
            return await set.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> FindOneWTAsync(int id)
        {
            return await set.AsTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await set.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FindOneWTAsync(Expression<Func<T, bool>> predicate)
        {
            return await set.AsTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return await query.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FindOneWTAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return await query.AsTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FindOneIncludingWTForAllAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncludingWT(includeProperties);
            return await query.AsTracking().FirstOrDefaultAsync(predicate);
        }

        public void Insert(T entity)
        {
            entity.UpdatedDateTime = DateTime.UtcNow;
            entity.CreationDateTime = DateTime.UtcNow;
            try
            {
                set.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task InsertAsync(T entity)
        {
            entity.UpdatedDateTime = DateTime.UtcNow;
            entity.CreationDateTime = DateTime.UtcNow;
            entity.IsActive = true;
            //this could be an asyn add but it does not make sense as there is no outband request so it would be so fast and async call might not be the right choice for this scenario as the
            //actual work which is savechanges is being in an async manner! --> wikichaghal.com/articles/4534533
            set.Add(entity);
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            entity.UpdatedDateTime = DateTime.UtcNow;
            set.Update(entity);
            //context.SaveChanges();
        }

        public void Delete(T entity)
        {
            set.Remove(entity);
            //context.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            set.RemoveRange(set.Where(predicate).AsEnumerable());
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void ClearContext()
        {
            foreach (var entityEntry in context.ChangeTracker.Entries().ToList())
                if (entityEntry.State == EntityState.Added)
                    entityEntry.State = EntityState.Detached;
        }

        public void Reset()
        {
            foreach (var entityEntry in context.ChangeTracker.Entries().ToList())
                if (entityEntry.State == EntityState.Added)
                    entityEntry.State = EntityState.Detached;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return set.Count(predicate);
        }

        private IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var queryable = set.AsNoTracking();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        private IQueryable<T> GetAllIncludingWT(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = set;
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
