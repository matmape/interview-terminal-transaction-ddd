using InterviewQuestion.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Infrastructure.Data.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly ApplicationDbContext _context;
        public RepositoryAsync(ApplicationDbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public IQueryable<T> TableAsync =>  Queryable();
        public virtual IQueryable<T> Queryable()
        {
            return _dbSet;
        }
        public IQueryable<T> Fetch(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? page = null, int? pageSize = null)
        {
            IQueryable<T> query = _dbSet;
            if (orderBy != null)
                query = orderBy(query);
            if (predicate != null)
                query = query.Where(predicate);
            if (page == null || pageSize == null) return query;
            if (page <= 0) page = 1;

            if (pageSize <= 0) pageSize = 10;
            query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);


            return query;
        }

        public async Task<T> FindAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> FindAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }
  
        public async Task InsertAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
