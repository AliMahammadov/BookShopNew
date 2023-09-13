using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin,Admin")]
    public class ReviewController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Add() => View();
    }
}
