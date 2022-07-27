using Microsoft.AspNetCore.Mvc;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
