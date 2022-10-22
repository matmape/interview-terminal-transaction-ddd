using InterviewQuestion.Domain.DTOs;
using InterviewQuestion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Domain.TerminalTransactions
{
    public interface ITerminalTransactionRepository : IRepositoryAsync<TerminalTransaction>
    {
        List<TerminalTransaction> GetData();

        IEnumerable<TerminalTransaction> GetTerminalTransactionPaged(int page, int count, out int totalCount, TerminalTransactionFilter filter = null);
        IEnumerable<TerminalTransaction> GetTerminalTransactionPaged(int page, int count, TerminalTransactionFilter filter = null);
        IEnumerable<TerminalTransaction> GetTerminalTransactionFilteredQueryable(TerminalTransactionFilter filter = null);


    }
}
