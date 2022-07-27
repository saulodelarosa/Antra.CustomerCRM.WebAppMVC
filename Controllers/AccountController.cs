using Antra.CustomerCRM.WebAppMVC.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserName = "test";

            List<Account> lstAccounts = new List<Account>
            {
                new Account() {Id = 1, Balance = 50},
                new Account() {Id = 2, Balance = 90}
            };

            return View(lstAccounts);
        }
    }
}
