using InterviewQuestion.API;
using InterviewQuestion.API.DTOs;
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
        public async Task<ActionResult<Response<AgentDto>>> Post([FromBody] AgentCreateDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(c => c.Errors.Select(d => d.ErrorMessage)).ToList();
                    var modelResponse = Response<AgentDto>.ValidationError(errors);
                    return BadRequest(modelResponse);
                }
                var response = await _service.Create(model);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<AgentDto>.Failed(ErrorMessages.Generic_Error));
            }
        }
        [HttpPut("")]
        public async Task<ActionResult<Response<AgentUpdateDto>>> Put([FromBody] AgentUpdateDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(c => c.Errors.Select(d => d.ErrorMessage)).ToList();
                    var modelResponse = Response<AgentUpdateDto>.ValidationError(errors);
                    return BadRequest(modelResponse);
                }
                var response = await _service.Update(model);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<AgentUpdateDto>.Failed(ErrorMessages.Generic_Error));
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Response<AgentDeleteDto>>> Delete(int id)
        {
            try
            {
                 
                var response = await _service.Delete(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<AgentDeleteDto>.Failed(ErrorMessages.Generic_Error));
            }
        }
	 
    }
}