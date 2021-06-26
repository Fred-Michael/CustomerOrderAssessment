using CustomerOrder.Domain.Dto;
using CustomerOrder.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CustomerOrderAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetRequiredService<ILogger<CustomerController>>();
            _customerService = serviceProvider.GetRequiredService<ICustomerService>();
        }

        [HttpGet("get-all-customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var result = await _customerService.GetAllCustomers();
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("get-customer-by-id/{id}")]
        public async Task<IActionResult> GetCustomerByCustomerId([FromQuery] string id)
        {
            try
            {
                var result = await _customerService.GetCustomerByCustomerId(id);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("get-customer-by-name/{name}")]
        public async Task<IActionResult> GetCustomerByCustomerName([FromQuery] string name)
        {
            try
            {
                var result = await _customerService.GetCustomerByCustomerName(name);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("add-customer")]
        public async Task<IActionResult> AddNewCustomer([FromBody] CustomerToAddDto model)
        {
            try
            {
                var result = await _customerService.AddCustomer(model);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPatch("update-customer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerToUpdateDto model)
        {
            try
            {
                var result = await _customerService.UpdateCustomer(model);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("delete-customer")]
        public async Task<IActionResult> DeleteCustomer([FromQuery] string id)
        {
            try
            {
                var result = await _customerService.DeleteCustomer(id);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }
    }
}
