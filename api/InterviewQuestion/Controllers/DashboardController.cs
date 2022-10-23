using InterviewQuestion.API.DTOs;
using InterviewQuestion.API.Services.TerminalTransactions;
using InterviewQuestion.API.StaticConfigurations;
using InterviewQuestion.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DashboardController : ControllerBase
    {
        
        private readonly ILogger<DashboardController> _logger;
        private readonly ITerminalTransactionService _service;
        public DashboardController(ILogger<DashboardController> logger, ITerminalTransactionService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<Response<DashboardModel>>> GetDashboard()
        {
            try
            {
                var response = await _service.GetDashboard();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(Response<DashboardModel>.Failed(ErrorMessages.Generic_Error));
            }
        }        
	 
    }
}