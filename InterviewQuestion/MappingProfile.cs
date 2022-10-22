using AutoMapper;
using InterviewQuestion.API.DTOs;
using InterviewQuestion.Domain.TerminalTransactions;

namespace InterviewQuestion.API
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TerminalTransaction, TerminalTransactionItem>();
            CreateMap<TerminalTransaction, TerminalTransactionAddDto>().ReverseMap();
        }
    }
}
