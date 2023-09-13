using BookShopEntity.Entities;
using BookShopViewModel.Entites;
using BookShopViewModel.Entites.Home;

namespace BookShopService.Services.Abstraction
{
    public interface IBasketContactService
    {
        Task AddBasketAsync(HomeVM homeVM);
        Task<ICollection<BasketContact>> GetAllContactsAsync();
    }
}
