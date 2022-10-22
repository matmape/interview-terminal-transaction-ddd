using InterviewQuestion.API.DTOs;
using InterviewQuestion.Domain.Shared;

namespace InterviewQuestion.API.Services.TerminalTransactions
{
    public interface ITerminalTransactionService
    {
        Task<Response<PagedList<TerminalTransactionItem>>> GetTransactions(int page, int pagesize, TerminalTransactionFilter filter);
        Task<Response<IEnumerable<TerminalTransactionItem>>> QueryTransactions(int page, int pagesize, TerminalTransactionFilter filter);
        Task<Response<TerminalTransactionAddResponse>> Create(TerminalTransactionAddDto model);
        Task<Response<TerminalTransactionUpdateResponse>> Update(TerminalTransactionUpdateDto model);
        Task<Response<TerminalTransactionItem>> GetById(int id);
        Task<Response<TerminalTransactionDeleteResponse>> Delete(int id);
    }
}
