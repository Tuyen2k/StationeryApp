using Microsoft.AspNetCore.Mvc;

namespace StationeryManagerMVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index(string returnUrl = "/")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}
