using Microsoft.AspNetCore.Mvc;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
