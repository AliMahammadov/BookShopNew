using System.Linq.Expressions;

namespace BookShopData.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        Task AddAsync(T entity);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int? id);
        Task DeleteAsync(T entity);
    }
}
