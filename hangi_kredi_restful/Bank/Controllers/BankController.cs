using MassTransit;
using hangi_kredi_restful.Common;
using hangi_kredi_restful.Models;
using hangi_kredi_restful.Services;
using Microsoft.AspNetCore.Mvc;

namespace hangi_kredi_restful.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BankController : ControllerBase
    {

        private readonly ILogger<BankController> _logger;
        private readonly IBankService _service;
        private readonly IPublishEndpoint _publishEndpoint;

        public BankController(ILogger<BankController> logger, IBankService service, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _service = service;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("get")]
        public async Task<ActionResult<ApiResponse<BankReturnType>>> Get([FromQuery] int currentPage = 0, [FromQuery] int perPage = 10)
        {
            try
            {
                var data = _service.GetBanks(currentPage, perPage);
                var response = new ApiResponse<BankReturnType>
                {
                    Success = true,
                    Data = await data
                };

                // Publish an event after fetching the banks
                await _publishEndpoint.Publish<ApiResponse<BankReturnType>>(response);

                return Ok(response);
            }
            catch (Exception e)
            {

                return BadRequest(new ApiResponse<BankReturnType> { Success = false, Error = e.Message });
            }

        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<ApiResponse<BankDto>>> GetById(int id)
        {
            try
            {
                var data = _service.GetBankById(id);

                var response = new ApiResponse<BankDto>
                {
                    Success = true,
                    Data = await data
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<BankDto> { Success = false, Error = e.Message });
            }

        }

        [HttpPost("create")]
        public async Task<ActionResult<ApiResponse<string>>> Create([FromBody] BankDto bank)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var _bank = await _service.CreateBank(bank);
                return Ok(new ApiResponse<string> { Success = true, Data = $"{_bank.Name} created successfully." });
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string> { Success = false, Error = e.Message });
            }

        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> DeleteById(int id)
        {
            try
            {
                var data = await _service.DeleteBank(id);

                var response = new ApiResponse<string>
                {
                    Success = true,
                    Data = $"{data.Name} is deleted successfully."
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string> { Success = false, Error = e.Message });
            }

        }

        [HttpPatch("update/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> UpdateById(int id, [FromBody] BankDto updatedBank)
        {
            try
            {
                var data = await _service.UpdateBank(id, updatedBank);

                var response = new ApiResponse<string>
                {
                    Success = true,
                    Data = $"{data.Name} is updated successfully."
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string> { Success = false, Error = e.Message });
            }

        }

    }
}