using InterviewQuestion.Domain.TerminalTransactions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
