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
    }
}
