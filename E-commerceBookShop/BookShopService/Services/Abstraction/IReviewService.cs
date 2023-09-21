using BookShopEntity.Entities;
using BookShopViewModel.Entites;
using BookShopViewModel.Entites.Home;

namespace BookShopService.Services.Abstraction
{
    public interface IReviewService
    {
        Task<ICollection<Review>> GetAllReviewsAsync();
        Task<ICollection<Review>> GetAllReviewIncludeBookIdAsync(int? id);
        Task AddReviewAsync(int? id, HomeVM homeVM);
        Task<Review> GetReviewById(int? id);
        Task DeleteReviewAsync(int? id);
    }
}
