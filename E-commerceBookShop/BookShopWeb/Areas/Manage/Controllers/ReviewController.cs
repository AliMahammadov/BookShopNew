using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ReviewController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Add() => View();
    }
}
