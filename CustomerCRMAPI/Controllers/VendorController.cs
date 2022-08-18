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
    public class VendorController : ControllerBase
    {
        IVendorServiceAsync vendorServiceAsync;

        public VendorController(IVendorServiceAsync _reg)
        {
            vendorServiceAsync = _reg;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await vendorServiceAsync.GetAllAsync();
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
            return Ok(await vendorServiceAsync.GetVendorByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VendorModel vendor)
        {
            if (await vendorServiceAsync.InsertVendorAsync(vendor) > 0)
            {
                return Ok(vendor);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(VendorModel vendor)
        {
            if (ModelState.IsValid)
            {
                if (await vendorServiceAsync.UpdateVendorAsync(vendor) > 0)
                {
                    return Ok(vendor);
                }

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{Id:int:min(0)}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await vendorServiceAsync.DeleteVendorAsync(Id) > 0)
            {
                var msg = new { Message = "Vendor Deleted" };
                return Ok(msg);
            }

            return BadRequest();
        }

    }
}
