﻿using BookShopEntity.Entities;
using BookShopEntity.Entity;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites;
using BookShopViewModel.Entites.Home;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BookShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;
        private readonly IContactService contactService;

        public HomeController(IBookService bookService, IContactService contactService)
        {
            this.bookService = bookService;
            this.contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await bookService.GetAllBooksAsync());

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            Book book = await bookService.GetBookIncludeAsync(id);
            if (book is not null)
            {
                HomeVM homeVM = new HomeVM()
                {
                    Book = book,
                    Books = await bookService.GetBookForAsCategory(id),
                };

                return View(homeVM);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Contact() => View();

        [HttpPost]
        public async Task<IActionResult> Contact(ContactVM contactVM)
        {
            if (!ModelState.IsValid) return View();
            await contactService.AddContactAsync(contactVM);
            return View();
        }
        public async Task<IActionResult> AddBasket(/*int? id*/)
        {

            //List<int> ids = new List<int>();
            //ids.Add((int)id);
            //string basket = JsonConvert.SerializeObject(ids);
            //HttpContext.Response.Cookies.Append("basket", basket);
            //return Content(HttpContext.Request.Cookies["basket"]);
            return View();
        }
    }
}
