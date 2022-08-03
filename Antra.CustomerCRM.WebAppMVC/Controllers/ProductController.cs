using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class ProductController : Controller
    {
        IRegionServiceAsync regionServiceAsync;
        IProductServiceAsync productServiceAsync;
        public ProductController(IRegionServiceAsync regionServiceAsync, IProductServiceAsync productServiceAsync)
        {
            this.productServiceAsync = productServiceAsync;
            this.regionServiceAsync = regionServiceAsync;
        }
        public async Task<IActionResult> Index(string cityname = "")
        {
            var result = await productServiceAsync.GetAllAsync();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await productServiceAsync.GetProductByIdAsync(id);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.Regions = new SelectList(await regionServiceAsync.GetAllRegions(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                await productServiceAsync.InsertProductAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }



        public async Task<IActionResult> Delete(int productId)
        {
            await productServiceAsync.DeleteProductAsync(productId); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Regions = new SelectList(await regionServiceAsync.GetAllRegions(), "Id", "Name");
            ProductModel model = await productServiceAsync.GetProductByIdAsync(id);
            return View(model);         
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Regions = new SelectList(await regionServiceAsync.GetAllRegions(), "Id", "Name");
                await productServiceAsync.UpdateProductAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }




    }
}
