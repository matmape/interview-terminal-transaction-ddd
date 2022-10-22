using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Infrastructure.Data.Repositories
{
    public interface IQueryObject<TEntity>
    {
        Expression<Func<TEntity, bool>> Expression { get; }
        IQueryObject<TEntity> And(Expression<Func<TEntity, bool>> query);
        IQueryObject<TEntity> Or(Expression<Func<TEntity, bool>> query);
        IQueryObject<TEntity> And(IQueryObject<TEntity> queryObject);
        IQueryObject<TEntity> Or(IQueryObject<TEntity> queryObject);

    }
    public abstract class QueryObject<TEntity> : IQueryObject<TEntity>
    {
        private Expression<Func<TEntity, bool>> _query;

        public virtual Expression<Func<TEntity, bool>> Expression => _query;

        public IQueryObject<TEntity> And(Expression<Func<TEntity, bool>> query)
        {
            _query = _query == null ? query : _query.And(query.Expand());
            return this;

        }

        public IQueryObject<TEntity> And(IQueryObject<TEntity> queryObject)
        {
            return And(queryObject.Expression);
        }

        public IQueryObject<TEntity> Or(Expression<Func<TEntity, bool>> query)
        {
            _query = _query == null ? query : _query.Or(query.Expand());
            return this;
        }

        public IQueryObject<TEntity> Or(IQueryObject<TEntity> queryObject)
        {
            return Or(queryObject.Expression);
        }
    }
}
