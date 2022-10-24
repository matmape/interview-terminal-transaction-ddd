using InterviewQuestion.API.DTOs;
using InterviewQuestion.API.StaticConfigurations;
using InterviewQuestion.Domain.Shared;
using InterviewQuestion.Domain.Entities;
using InterviewQuestion.Infrastructure.Data.Repositories;

namespace InterviewQuestion.API.Services.Agents
{
    public interface IAgentService
    {
        Task<Response<AgentDto>> AddTerminalTransaction(TerminalTransactionAddToAgentDto model);
        Task<Response<AgentDto>> Create(AgentCreateDto model);
    }
    public class AgentService:IAgentService
    {
        private readonly IAgentRepository _repository;

        public AgentService(IAgentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<AgentDto>> Create(AgentCreateDto model)
        {
            var response = Response<AgentDto>.Failed(string.Empty);
            try
            {
                
                var entity = new Agent(model.Name, model.PhoneNumber);
                await _repository.InsertAsync(entity);
                response = Response<AgentDto>.Success(new AgentDto { AgentId = entity.Id });
            }
            catch (Exception)
            {
                response = Response<AgentDto>.Failed(ErrorMessages.Error_Creating_Agent);
            }
            return response;
        }
        public async Task<Response<AgentDto>> AddTerminalTransaction(TerminalTransactionAddToAgentDto model)
        {
            var response = Response<AgentDto>.Failed(string.Empty);
            try
            {
                var agent = await _repository.FindAsync(model.AgentId);
                if (agent == null) return Response<AgentDto>.Failed("Agent not found");

                agent.AddTerminalTransaction(
                    model.TerminalId,
                    model.Processor,
                    model.TransactionReference,
                    model.ResponseCode,
                    model.ResponseMessage,
                    "NGN",
                    model.Amount * 100,
                    10.75m
                    );
                await _repository.UpdateAsync(agent);
                response = Response<AgentDto>.Success(new AgentDto { AgentId = agent.Id });
            }
            catch (Exception)
            {
                response = Response<AgentDto>.Failed(ErrorMessages.Error_Creating_Agent);
            }
            return response;
        }
    }
}
