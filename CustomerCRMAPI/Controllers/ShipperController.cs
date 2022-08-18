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
    public class ShipperController : ControllerBase
    {
        IShipperServiceAsync shipperServiceAsync;

        public ShipperController(IShipperServiceAsync _reg)
        {
            shipperServiceAsync = _reg;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await shipperServiceAsync.GetAllAsync();
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
            return Ok(await shipperServiceAsync.GetShipperByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ShipperModel shipper)
        {
            if (await shipperServiceAsync.InsertShipperAsync(shipper) > 0)
            {
                return Ok(shipper);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ShipperModel shipper)
        {
            if (ModelState.IsValid)
            {
                if (await shipperServiceAsync.UpdateShipperAsync(shipper) > 0)
                {
                    return Ok(shipper);
                }

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{Id:int:min(0)}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await shipperServiceAsync.DeleteShipperAsync(Id) > 0)
            {
                var msg = new { Message = "Shipper Deleted" };
                return Ok(msg);
            }

            return BadRequest();
        }

    }
}
