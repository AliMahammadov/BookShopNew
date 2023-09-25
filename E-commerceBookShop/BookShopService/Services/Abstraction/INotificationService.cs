using BookShopEntity.Entities;

namespace BookShopService.Services.Abstraction
{
    public interface INotificationService
    {
        Task<ICollection<Notification>> GetListAsync();
        Task AddAsync(Notification notification);
    }
}
