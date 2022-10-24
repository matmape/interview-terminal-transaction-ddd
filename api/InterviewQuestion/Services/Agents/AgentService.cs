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
        Task<Response<AgentDeleteDto>> Delete(int id);
        Task<Response<AgentDto>> GetById(int id);
        Task<Response<AgentUpdateResponse>> Update(AgentUpdateDto model);
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
                await _repository.SaveChangesAsync();
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

        public async Task<Response<AgentDeleteDto>> Delete(int id)
        {
            var response = Response<AgentDeleteDto>.Failed(string.Empty);
            try
            {

                var entity = await _repository.FindAsync(id);
                if (entity == null) return Response<AgentDeleteDto>.Failed("Agent not found");

                await _repository.DeleteAsync(entity);
                await _repository.SaveChangesAsync();
                response = Response<AgentDeleteDto>.Success(new AgentDeleteDto { Message="Deleted" });
            }
            catch (Exception)
            {
                response = Response<AgentDeleteDto>.Failed(ErrorMessages.Error_Creating_Agent);
            }
            return response;
        }

        public async Task<Response<AgentDto>> GetById(int id)
        {
            var response = Response<AgentDto>.Failed(string.Empty);
            try
            {

                var entity = await _repository.FindAsync(id);
                if (entity == null) return Response<AgentDto>.Failed("Agent not found");

                response = Response<AgentDto>.Success(new AgentDto { AgentId = id, Name=entity.Name, PhoneNumber= entity.PhoneNumber });
            }
            catch (Exception)
            {
                response = Response<AgentDto>.Failed(ErrorMessages.Error_Creating_Agent);
            }
            return response;
        }

        public async Task<Response<AgentUpdateResponse>> Update(AgentUpdateDto model)
        {
            var response = Response<AgentUpdateResponse>.Failed(string.Empty);
            try
            {

                var entity = await _repository.FindAsync(model.Id);
                if (entity == null) return Response<AgentUpdateResponse>.Failed("Agent not found");

                entity.Update(model.Name, model.PhoneNumber);

                await _repository.UpdateAsync(entity);
                await _repository.SaveChangesAsync();
                response = Response<AgentUpdateResponse>.Success(new AgentUpdateResponse { Id = entity.Id });
            }
            catch (Exception)
            {
                response = Response<AgentUpdateResponse>.Failed(ErrorMessages.Error_Creating_Agent);
            }
            return response;
        }
    }
}
