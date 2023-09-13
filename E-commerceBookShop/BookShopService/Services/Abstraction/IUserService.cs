using BookShopEntity.Entities.User;

namespace BookShopService.Services.Abstraction
{
    public interface IUserService
    {
        Task<ICollection<AppUser>> GetAllUsersAsync();
    }
}
