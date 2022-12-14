using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class RegionController : Controller
    {
        IRegionServiceAsync regionServiceAsync;
        public RegionController(IRegionServiceAsync _service)
        {
            regionServiceAsync = _service;
        }
        public async Task<IActionResult> Index()
        {
            var result = await regionServiceAsync.GetAllRegions();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegionModel model)
        {
            if (ModelState.IsValid) { 
           await regionServiceAsync.InsertRegion(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int regionId)
        {
            await regionServiceAsync.DeleteRegionAsync(regionId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            RegionModel model = await regionServiceAsync.GetRegionByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RegionModel model)
        {
            if (ModelState.IsValid)
            {
                await regionServiceAsync.UpdateRegionAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
