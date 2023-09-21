using BookShopService.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin,Admin")]
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await reviewService.GetAllReviewsAsync());

        [HttpGet]
        public async Task<IActionResult> View(int? id)
        {
            if (id is not null)
                return View(await reviewService.GetReviewById(id));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is not null)
            {
                await reviewService.DeleteReviewAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


    }
}
