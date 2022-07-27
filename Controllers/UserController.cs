using Microsoft.AspNetCore.Mvc;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
