using BookShopData.DAL;
using BookShopEntity.Entities.User;
using BookShopService.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BookShopService.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly AppDbContext appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ICollection<AppUser>> GetAllUsersAsync()
        {
            string adminId = "32504d3d-7115-4e77-a744-c5044d9ab796";
            return await appDbContext.AppUsers.Where(u => u.Id != adminId).ToListAsync();
        }
    }
}
