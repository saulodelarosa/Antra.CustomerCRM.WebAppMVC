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
    public class EmployeeController : ControllerBase
    {
        IEmployeeServiceAsync employeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync _reg)
        {
            employeeServiceAsync = _reg;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await employeeServiceAsync.GetAllAsync();
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
            return Ok(await employeeServiceAsync.GetEmployeeByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeModel employee)
        {
            if (await employeeServiceAsync.InsertEmployeeAsync(employee) > 0)
            {
                return Ok(employee);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                if (await employeeServiceAsync.UpdateEmployeeAsync(employee) > 0)
                {
                    return Ok(employee);
                }

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{Id:int:min(0)}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await employeeServiceAsync.DeleteEmployeeAsync(Id) > 0)
            {
                var msg = new { Message = "Employee Deleted" };
                return Ok(msg);
            }

            return BadRequest();
        }

    }
}
