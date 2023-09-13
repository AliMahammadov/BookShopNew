using BookShopData.UnitOfWorks;
using BookShopEntity.Entities.User;
using BookShopService.Services.Abstraction;

namespace BookShopService.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ICollection<AppUser>> GetAllUsersAsync()
        {
            return await unitOfWork.GetRepository<AppUser>().GetAllAsync();
        }
    }
}
