using BookShopService.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Manage.ViewComponents
{
    public class NotificationList : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
