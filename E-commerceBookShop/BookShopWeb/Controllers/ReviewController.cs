using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites.Home;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public async Task<IActionResult> Comment(int? id, HomeVM homeVM)
        {
            await reviewService.AddReviewAsync(id, homeVM);
            return RedirectToAction("Detail", new RouteValueDictionary(new { Controller = "Home", Action = "Detail", id = id }));
        }
    }
}
