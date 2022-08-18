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
    public class ProductController : ControllerBase
    {
        IProductServiceAsync productServiceAsync;

        public ProductController(IProductServiceAsync _reg)
        {
            productServiceAsync = _reg;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await productServiceAsync.GetAllAsync();
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
            return Ok(await productServiceAsync.GetProductByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductModel product)
        {
            if (await productServiceAsync.InsertProductAsync(product) > 0)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                if (await productServiceAsync.UpdateProductAsync(product) > 0)
                {
                    return Ok(product);
                }

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{Id:int:min(0)}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await productServiceAsync.DeleteProductAsync(Id) > 0)
            {
                var msg = new { Message = "Product Deleted" };
                return Ok(msg);
            }

            return BadRequest();
        }

    }
}
