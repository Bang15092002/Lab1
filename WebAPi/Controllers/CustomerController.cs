using BusinessObjects.DataTranfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.CustomerRepo;
using System.Text.Json;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository repository;
        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<string> GetAllCustomer()
        {
            return JsonSerializer.Serialize(await repository.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetCustomer(int id)
        {
            return JsonSerializer.Serialize(await repository.GetCustomer(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDTO customer)
        {
            var _customer = await repository.CheckCustomerExist(customer.Username);
            if (_customer == false)
            {
                await repository.AddCustomer(customer);
                return Created();
            }
            return BadRequest("Customer is exist");
        }

        [HttpPost]
        [Route("MultipleDelete")]
        public async Task<IActionResult> MultipleDelete(int[] selectedIds)
        {
            Boolean isDelete = await repository.MultipleDeleteCustomer(selectedIds);
            if (isDelete == true)
            {
                return Ok("Delete customer successfully");
            }
            return NotFound("Customer is not exist");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customer)
        {
            var _customer = await repository.GetCustomer(id);
            if(_customer != null)
            {
                await repository.UpdateCustomer(id, customer);
                return NoContent();
            }
            return NotFound("Customer is not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            Boolean isDelete = await repository.DeleteCustomer(id);
            if(isDelete == true)
            {
                return Ok("Delete customer successfully");
            }
            return NotFound("Customer is not exist");
        }
    }
}