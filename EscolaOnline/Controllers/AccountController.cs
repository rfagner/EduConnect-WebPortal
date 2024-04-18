using Microsoft.AspNetCore.Mvc;

namespace EscolaOnline.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
