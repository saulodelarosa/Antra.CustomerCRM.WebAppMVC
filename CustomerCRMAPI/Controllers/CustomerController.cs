using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCRMAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerServiceAsync customerServiceAsync;

        public CustomerController(ICustomerServiceAsync _reg)
        {
            customerServiceAsync = _reg;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await customerServiceAsync.GetAllAsync();
            if (result == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("GetById/{Id:int:min(0)}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await customerServiceAsync.GetCustomerByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerModel customer)
        {
            if (await customerServiceAsync.InsertCustomerAsync(customer) > 0)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                if (await customerServiceAsync.UpdateCustomerAsync(customer) > 0)
                {
                    return Ok(customer);
                }

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{Id:int:min(0)}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await customerServiceAsync.DeleteCustomerAsync(Id) > 0)
            {
                var msg = new { Message = "Customer Deleted" };
                return Ok(msg);
            }

            return BadRequest();
        }

    }
}
