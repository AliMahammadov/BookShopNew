using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class AliController : Controller
    {
        public IActionResult Index()
        {
            if(ModelState.IsValid) return View();
            return View();
        }
    }
}
