using hangi_kredi_restful.Common;
using hangi_kredi_restful.Models;
using hangi_kredi_restful.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hangi_kredi_restful.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {

        private readonly ILogger<LoanController> _logger;
        private readonly ILoanService _service;

        public LoanController(ILogger<LoanController> logger, ILoanService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("get")]
        public async Task<ActionResult<ApiResponse<LoanReturnType>>> Get()
        {
            try
            {
                ApiResponse<LoanReturnType> response = new() { Success = true, Data = await _service.GetBanks() };
                return Ok(response);
            }
            catch (Exception e)
            {

                return BadRequest(new ApiResponse<LoanReturnType> { Success = false, Error = e.Message });
            }

        }

    }

}

