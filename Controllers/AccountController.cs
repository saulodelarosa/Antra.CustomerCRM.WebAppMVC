using Microsoft.AspNetCore.Mvc;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
