using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class EmployeeController : Controller
    {
        IRegionServiceAsync regionServiceAsync;
        IEmployeeServiceAsync employeeServiceAsync;
        public EmployeeController(IRegionServiceAsync regionServiceAsync, IEmployeeServiceAsync employeeServiceAsync)
        {
            this.employeeServiceAsync = employeeServiceAsync;
            this.regionServiceAsync = regionServiceAsync;
        }
        public async Task<IActionResult> Index(string cityname = "")
        {
            var result = await employeeServiceAsync.GetAllAsync();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await employeeServiceAsync.GetEmployeeByIdAsync(id);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.Regions = new SelectList(await regionServiceAsync.GetAllRegions(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.InsertEmployeeAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
