using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Domain.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
       
         Task<T> FindAsync(long id);
         Task<T> FindAsync(int id);
         Task<T> FindAsync(string id);
         IQueryable<T> TableAsync { get; }

         Task InsertAsync(T entity);
         IQueryable<T> Fetch(Expression<Func<T, bool>> predicate,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             int? page = null, int? pageSize = null);

         Task UpdateAsync(T entity);
         Task DeleteAsync(T entity);
         
    }
}
