using InterviewQuestion.API;
using InterviewQuestion.API.DTOs;
using InterviewQuestion.API.Services.Agents;
using InterviewQuestion.API.Services.Agents;
using InterviewQuestion.API.StaticConfigurations;
using InterviewQuestion.Domain.DTOs;
using InterviewQuestion.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ValidateModel]
    public class AgentController : ControllerBase
    {
        
        private readonly ILogger<AgentController> _logger;
        private readonly IAgentService _service;
        public AgentController(ILogger<AgentController> logger, IAgentService service)
        {
            _logger = logger;
            _service = service;
        }

        //[HttpGet("get-paged-requests/{page}/{pagesize}/{wherecondition}")]
        //public async Task<ActionResult<Response<PagedList<AgentItem>>>> GetPagedRequests(int page, int pagesize, string wherecondition = "{}")
        //{
        //    try
        //    {
        //        var filter = AgentFilter.Deserialize(wherecondition);
        //        var response = await _service.GetTransactions(page, pagesize, filter);
        //        return Ok(response);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest(Response<PagedList<AgentItem>>.Failed(ErrorMessages.Generic_Error));
        //    }
        //}

        //[HttpGet("query-paged-requests/{page}/{pagesize}/{wherecondition}")]
        //public async Task<ActionResult<Response<IEnumerable<AgentItem>>>> QueryPagedRequests(int page, int pagesize, string wherecondition = "{}")
        //{
        //    try
        //    {
        //        var filter = AgentFilter.Deserialize(wherecondition);
        //        var response = await _service.QueryTransactions(page, pagesize, filter);
        //        return Ok(response);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest(Response<IEnumerable<AgentItem>>.Failed(ErrorMessages.Generic_Error));
        //    }
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<AgentItem>>> Get(int id)
        {
            try
            {
                var response = await _service.GetById(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<AgentItem>.Failed(ErrorMessages.Generic_Error));
            }
        }
        [HttpPost("")]
        public async Task<ActionResult<Response<AgentAddResponse>>> Post([FromBody] AgentAddDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(c => c.Errors.Select(d => d.ErrorMessage)).ToList();
                    var modelResponse = Response<AgentAddResponse>.ValidationError(errors);
                    return BadRequest(modelResponse);
                }
                var response = await _service.Create(model);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<AgentAddResponse>.Failed(ErrorMessages.Generic_Error));
            }
        }
        [HttpPut("")]
        public async Task<ActionResult<Response<AgentAddResponse>>> Put([FromBody] AgentUpdateDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(c => c.Errors.Select(d => d.ErrorMessage)).ToList();
                    var modelResponse = Response<AgentAddResponse>.ValidationError(errors);
                    return BadRequest(modelResponse);
                }
                var response = await _service.Update(model);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<AgentAddResponse>.Failed(ErrorMessages.Generic_Error));
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Response<AgentAddResponse>>> Delete(int id)
        {
            try
            {
                 
                var response = await _service.Delete(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<AgentAddResponse>.Failed(ErrorMessages.Generic_Error));
            }
        }
	 
    }
}