using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class VendorController : Controller
    {
        IRegionServiceAsync regionServiceAsync;
        IVendorServiceAsync vendorServiceAsync;
        public VendorController(IRegionServiceAsync regionServiceAsync, IVendorServiceAsync vendorServiceAsync)
        {
            this.vendorServiceAsync = vendorServiceAsync;
            this.regionServiceAsync = regionServiceAsync;
        }
        public async Task<IActionResult> Index(string cityname = "")
        {
            var result = await vendorServiceAsync.GetAllAsync();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await vendorServiceAsync.GetVendorByIdAsync(id);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.Regions = new SelectList(await regionServiceAsync.GetAllRegions(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VendorModel model)
        {
            if (ModelState.IsValid)
            {
                await vendorServiceAsync.InsertVendorAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }



        public async Task<IActionResult> Delete(int vendorId)
        {
            await vendorServiceAsync.DeleteVendorAsync(vendorId); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Regions = new SelectList(await regionServiceAsync.GetAllRegions(), "Id", "Name");
            VendorModel model = await vendorServiceAsync.GetVendorByIdAsync(id);
            return View(model);         
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VendorModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Regions = new SelectList(await regionServiceAsync.GetAllRegions(), "Id", "Name");
                await vendorServiceAsync.UpdateVendorAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }




    }
}
