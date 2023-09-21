using BookShopData.DAL;
using BookShopData.UnitOfWorks;
using BookShopEntity.Entities;
using BookShopEntity.Entity;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites.Home;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookShopService.Services.Concrete
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AppDbContext appDbContext;

        public ReviewService(IUnitOfWork unitOfWork, AppDbContext appDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.appDbContext = appDbContext;
        }

        public async Task AddReviewAsync(int? id, HomeVM homeVM)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            if (book is not null)
            {
                Review review = new Review()
                {
                    Name = homeVM.Review.Name,
                    Email = homeVM.Review.Email,
                    Comment = homeVM.Review.Comment,
                    BookId = book.Id
                };

                await unitOfWork.GetRepository<Review>().AddAsync(review);
                await unitOfWork.SaveChangeAsync();
            }
        }

        public async Task DeleteReviewAsync(int? id)
        {
            var review = await unitOfWork.GetRepository<Review>().GetByIdAsync(id);
            if (review is not null)
            {
                await unitOfWork.GetRepository<Review>().DeleteAsync(review);
                await unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<ICollection<Review>> GetAllReviewIncludeBookIdAsync(int? id)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            if (book is not null)
                return await appDbContext.Reviews.Where(r => r.BookId == book.Id).ToListAsync();
            return null;
        }

        public async Task<ICollection<Review>> GetAllReviewsAsync()
        {
            return await unitOfWork.GetRepository<Review>().GetAllAsync();
        }

        public async Task<Review> GetReviewById(int? id)
        {
            return await unitOfWork.GetRepository<Review>().GetByIdAsync(id);
        }
    }
}
