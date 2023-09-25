using BookShopData.UnitOfWorks;
using BookShopEntity.Entities;
using BookShopService.Services.Abstraction;

namespace BookShopService.Services.Concrete
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Notification notification)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Notification>> GetListAsync()
        {
            return await unitOfWork.GetRepository<Notification>().GetAllAsync();
        }
    }
}
