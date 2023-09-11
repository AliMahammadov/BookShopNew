using BookShopData.Repositories;

namespace BookShopData.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChangeAsync();
    }
}
