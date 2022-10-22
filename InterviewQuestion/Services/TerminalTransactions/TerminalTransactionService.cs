using AutoMapper;
using InterviewQuestion.API.DTOs;
using InterviewQuestion.API.StaticConfigurations;
using InterviewQuestion.API.Validators;
using InterviewQuestion.Domain.Shared;
using InterviewQuestion.Domain.TerminalTransactions;

namespace InterviewQuestion.API.Services.TerminalTransactions
{
    public class TerminalTransactionService : ITerminalTransactionService
    {
		private readonly ITerminalTransactionRepository _repository;
		private readonly TerminalTransactionAddValidator _terminalTransactionAddValidator;
		private readonly TerminalTransactionUpdateValidator _terminalTransactionUpdateValidator;
        private readonly IMapper _mapper;
		public TerminalTransactionService(ITerminalTransactionRepository repository, IMapper mapper, TerminalTransactionAddValidator terminalTransactionAddValidator, TerminalTransactionUpdateValidator terminalTransactionUpdateValidator)
		{
			_repository = repository;
			_mapper = mapper;
			_terminalTransactionAddValidator = terminalTransactionAddValidator;
			_terminalTransactionUpdateValidator = terminalTransactionUpdateValidator;
		}

		public async Task<Response<TerminalTransactionAddResponse>> Create(TerminalTransactionAddDto model)
		{
			var response = Response<TerminalTransactionAddResponse>.ValidationError(new List<string>());

            try
			{
                var validationResult = _terminalTransactionAddValidator.Validate(model);

                if (!validationResult.IsValid)
                    response.ValidationMessages
                        .AddRange(validationResult.Errors
                            .Select(c => c.ErrorMessage).ToList());

                if ((response.ValidationMessages != null) && response.ValidationMessages.Any())
                    return response;

				var entity = _mapper.Map<TerminalTransaction>(model);
				entity.DateCreated = DateTime.UtcNow;
				await _repository.InsertAsync(entity);
				
                response = Response<TerminalTransactionAddResponse>.Success(new TerminalTransactionAddResponse()
				{
					Message = "Created successfully"
				});

            }
			catch (Exception ex)
			{
				response= Response<TerminalTransactionAddResponse>.Failed(ErrorMessages.Terminal_Creation_Failed);

            }
			return await Task.FromResult(response);
		}
		public async Task<Response<TerminalTransactionUpdateResponse>> Update(TerminalTransactionUpdateDto model)
		{
			var response = Response<TerminalTransactionUpdateResponse>.ValidationError(new List<string>());

            try
			{
                var validationResult = _terminalTransactionUpdateValidator.Validate(model);

                if (!validationResult.IsValid)
                    response.ValidationMessages
                        .AddRange(validationResult.Errors
                            .Select(c => c.ErrorMessage).ToList());

                if ((response.ValidationMessages != null) && response.ValidationMessages.Any())
                    return response;

				var entity = await _repository.FindAsync(model.Id);
				if (entity == null) return Response<TerminalTransactionUpdateResponse>.Failed("Record not found");

				_mapper.Map(model, entity);
				entity.LastUpdatedOn = DateTime.UtcNow;
				await _repository.UpdateAsync(entity);
				
                response = Response<TerminalTransactionUpdateResponse>.Success(new TerminalTransactionUpdateResponse()
				{
					Id = model.Id,
					Message = "Updated successfully"
				});

            }
			catch (Exception ex)
			{
				response= Response<TerminalTransactionUpdateResponse>.Failed(ErrorMessages.Terminal_Update_Failed);

            }
			return await Task.FromResult(response);
		}

		public async Task<Response<PagedList<TerminalTransactionItem>>> GetTransactions(int page, int pagesize, TerminalTransactionFilter filter)
        {
			try
			{
				var terminalData = _repository.GetData();
				var totalCount = terminalData.Count;
				return Response<PagedList<TerminalTransactionItem>>.Success(new PagedList<TerminalTransactionItem>()
				{
					Items = terminalData.Select(c => _mapper.Map<TerminalTransactionItem>(c))
					.Skip((page - 1) * pagesize).Take(pagesize).ToList(),
					Total = totalCount
                }) ;
			}
			catch (Exception)
			{
				return await Task.FromResult(Response<PagedList<TerminalTransactionItem>>.Failed(ErrorMessages.Error_Loading_Content));
			}
        }
		public async Task<Response<IEnumerable<TerminalTransactionItem>>> QueryTransactions(int page, int pagesize, TerminalTransactionFilter filter)
        {
			try
			{
				var terminalData = _repository.GetData();
				var entities = terminalData.Select(c => _mapper.Map<TerminalTransactionItem>(c))
					.Skip((page - 1) * pagesize).Take(pagesize).ToList();

                return Response<IEnumerable<TerminalTransactionItem>>.Success(entities) ;
			}
			catch (Exception)
			{
				return await Task.FromResult(Response<IEnumerable<TerminalTransactionItem>>.Failed(ErrorMessages.Error_Loading_Content));
			}
        }

		public async Task<Response<TerminalTransactionItem>> GetById(int id)
		{
			try
			{
				var entity = await _repository.FindAsync(id);
				if (entity == null) return Response<TerminalTransactionItem>.Failed("Record not found");

				return Response<TerminalTransactionItem>.Success(_mapper.Map<TerminalTransactionItem>(entity));	
            }
			catch (Exception)
			{
				return Response<TerminalTransactionItem>.Failed(ErrorMessages.Error_Loading_Content);

            }
		}

		public async Task<Response<TerminalTransactionDeleteResponse>> Delete(int id)
		{
            var response = Response<TerminalTransactionDeleteResponse>.ValidationError(new List<string>());

            try
            {
                 
                var entity = await _repository.FindAsync(id);
                if (entity == null) return Response<TerminalTransactionDeleteResponse>.Failed("Record not found");

                await _repository.DeleteAsync(entity);

                response = Response<TerminalTransactionDeleteResponse>.Success(new TerminalTransactionDeleteResponse()
                {
                    Message = "Deleted successfully"
                });

            }
            catch (Exception)
            {
                response = Response<TerminalTransactionDeleteResponse>.Failed(ErrorMessages.Terminal_Deletion_Failed);

            }
            return await Task.FromResult(response);
        }
	}
}
