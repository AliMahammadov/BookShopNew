using BookShopData.UnitOfWorks;
using BookShopEntity.Entities;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites;
using BookShopViewModel.Entites.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopService.Services.Concrete
{
    public class BasketContactService : IBasketContactService
    {
        private readonly IUnitOfWork unitOfWork;

        public BasketContactService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddBasketAsync(HomeVM homeVM)
        {
            if (homeVM is not null)
            {
                BasketContact contact = new BasketContact()
                {
                    Name = homeVM.BasketContactVM.Name,
                    Surname = homeVM.BasketContactVM.Surname,
                    Phone = homeVM.BasketContactVM.Phone,
                    Message = homeVM.BasketContactVM.Message,
                    Email = homeVM.BasketContactVM.Email,
                    CreateAt = DateTime.Now,
                    BookId = homeVM.Book.Id,
                    BookName = homeVM.Book.Name,
                    Author = homeVM.Book.Author,
                    BookPrice = homeVM.Book.Price

                };
                await unitOfWork.GetRepository<BasketContact>().AddAsync(contact);
                await unitOfWork.SaveChangeAsync();

            }
           
             
        }

        public async Task<ICollection<BasketContact>> GetAllContactsAsync()
        {
           return await unitOfWork.GetRepository<BasketContact>().GetAllAsync();
        }
    }
}
