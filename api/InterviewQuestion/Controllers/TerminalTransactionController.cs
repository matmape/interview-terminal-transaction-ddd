using InterviewQuestion.API;
using InterviewQuestion.API.DTOs;
using InterviewQuestion.API.Services.TerminalTransactions;
using InterviewQuestion.API.StaticConfigurations;
using InterviewQuestion.Domain.DTOs;
using InterviewQuestion.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ValidateModel]
    public class TerminalTransactionController : ControllerBase
    {
        
        private readonly ILogger<TerminalTransactionController> _logger;
        private readonly ITerminalTransactionService _service;
        public TerminalTransactionController(ILogger<TerminalTransactionController> logger, ITerminalTransactionService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("get-paged-requests/{page}/{pagesize}/{wherecondition}")]
        public async Task<ActionResult<Response<PagedList<TerminalTransactionItem>>>> GetPagedRequests(int page, int pagesize, string wherecondition = "{}")
        {
            try
            {
                var filter = TerminalTransactionFilter.Deserialize(wherecondition);
                var response = await _service.GetTransactions(page, pagesize, filter);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<PagedList<TerminalTransactionItem>>.Failed(ErrorMessages.Generic_Error));
            }
        }

        [HttpGet("query-paged-requests/{page}/{pagesize}/{wherecondition}")]
        public async Task<ActionResult<Response<IEnumerable<TerminalTransactionItem>>>> QueryPagedRequests(int page, int pagesize, string wherecondition = "{}")
        {
            try
            {
                var filter = TerminalTransactionFilter.Deserialize(wherecondition);
                var response = await _service.QueryTransactions(page, pagesize, filter);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<IEnumerable<TerminalTransactionItem>>.Failed(ErrorMessages.Generic_Error));
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<TerminalTransactionItem>>> Get(int id)
        {
            try
            {
                var response = await _service.GetById(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<TerminalTransactionItem>.Failed(ErrorMessages.Generic_Error));
            }
        }
        [HttpPost("")]
        public async Task<ActionResult<Response<TerminalTransactionAddResponse>>> Post([FromBody] TerminalTransactionAddDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(c => c.Errors.Select(d => d.ErrorMessage)).ToList();
                    var modelResponse = Response<TerminalTransactionAddResponse>.ValidationError(errors);
                    return BadRequest(modelResponse);
                }
                var response = await _service.Create(model);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<TerminalTransactionAddResponse>.Failed(ErrorMessages.Generic_Error));
            }
        }
        [HttpPut("")]
        public async Task<ActionResult<Response<TerminalTransactionAddResponse>>> Put([FromBody] TerminalTransactionUpdateDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(c => c.Errors.Select(d => d.ErrorMessage)).ToList();
                    var modelResponse = Response<TerminalTransactionAddResponse>.ValidationError(errors);
                    return BadRequest(modelResponse);
                }
                var response = await _service.Update(model);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<TerminalTransactionAddResponse>.Failed(ErrorMessages.Generic_Error));
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<TerminalTransactionAddResponse>>> Delete(int id)
        {
            try
            {
                 
                var response = await _service.Delete(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<TerminalTransactionAddResponse>.Failed(ErrorMessages.Generic_Error));
            }
        }
	 
    }
}