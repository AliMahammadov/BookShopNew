using BookShopEntity.Entities;
using BookShopViewModel.Entites;

namespace BookShopService.Services.Abstraction
{
    public interface IContactService
    {
        Task AddContactAsync(ContactVM contactVM);
        Task<ICollection<Contact>> GetAllContactsAsync();
    }
}
