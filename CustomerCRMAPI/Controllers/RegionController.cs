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
    public class RegionController : ControllerBase
    {
        IRegionServiceAsync regionServiceAsync;

        public RegionController(IRegionServiceAsync _reg)
        {
            regionServiceAsync = _reg;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await regionServiceAsync.GetAllRegions();
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
            return Ok(await regionServiceAsync.GetRegionByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegionModel region)
        {
            if (await regionServiceAsync.InsertRegion(region) > 0)
            {
                return Ok(region);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update( RegionModel region)
        {
            if (ModelState.IsValid)
            {
                    if(await regionServiceAsync.UpdateRegionAsync(region) > 0)
                    {
                        return Ok(region);
                    }

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{Id:int:min(0)}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await regionServiceAsync.DeleteRegionAsync(Id) > 0)
            {
                var msg = new { Message = "Region Deleted" };
                return Ok(msg);
            }
            
                return BadRequest();
        }

    }
}
