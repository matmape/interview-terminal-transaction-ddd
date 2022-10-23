using InterviewQuestion.Domain.DTOs;
using InterviewQuestion.Domain.TerminalTransactions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Infrastructure.Data.Repositories
{
    public class TerminalTransactionRepository : RepositoryAsync<TerminalTransaction>, ITerminalTransactionRepository
    {
        public TerminalTransactionRepository(ApplicationDbContext context) : base(context)
        {
        }
        public List<TerminalTransaction> GetData()
        {
            try
            {
                return TerminalTransactionData.GetData();
            }
            catch (Exception)
            {
                return new List<TerminalTransaction>();
            }
        }


        public IEnumerable<TerminalTransaction> GetTerminalTransactionPaged(int page, int count, out int totalCount,
         TerminalTransactionFilter filter = null)
        {
            var expression = new TerminalTransactionQueryObject(filter).Expression;
            totalCount = Count(expression);
            return TerminalTransactionPaged(page, count, expression);
        }
        public IEnumerable<TerminalTransaction> GetTerminalTransactionPaged(int page, int count, TerminalTransactionFilter filter = null)
        {
            var expression = new TerminalTransactionQueryObject(filter).Expression;
            return TerminalTransactionPaged(page, count, expression);
        }

        private IEnumerable<TerminalTransaction> TerminalTransactionPaged(int page, int count, Expression<Func<TerminalTransaction, bool>> expression)
        {
            var order = ProcessOrderFunc();
            return Fetch(expression, order, page, count);
        }

        public IEnumerable<TerminalTransaction> GetTerminalTransactionFilteredQueryable(TerminalTransactionFilter filter = null)
        {
            var expression = new TerminalTransactionQueryObject(filter).Expression;
            return Fetch(expression);
        }


        public static Func<IQueryable<TerminalTransaction>, IOrderedQueryable<TerminalTransaction>> ProcessOrderFunc()
        {
            Func<IQueryable<TerminalTransaction>, IOrderedQueryable<TerminalTransaction>> orderFuction = (queryable) =>
            {
                var orderQueryable = queryable.OrderByDescending(x => x.DateCreated).ThenBy(c => c.Id); 
                return orderQueryable;
            };
            return orderFuction;
        }

        

        public class TerminalTransactionQueryObject : QueryObject<TerminalTransaction>
        {
            public TerminalTransactionQueryObject(TerminalTransactionFilter filter)
            {
                if (filter != null)
                {
                    if (filter.DateCreatedFrom.HasValue)
                        And(c => c.DateCreated >= filter.DateCreatedFrom);
                    if (filter.DateCreatedTo.HasValue)
                        And(c => c.DateCreated < filter.DateCreatedTo.Value.AddDays(1));
                }
            }
        }
    }
}
