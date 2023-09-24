using BookShopEntity.Entity;
using BookShopViewModel;
using BookShopViewModel.Entites;

namespace BookShopService.Services.Abstraction
{
    public interface IBookService
    {
        Task<ICollection<Book>> GetAllBooksAsync();
        Task<IEnumerable<Book>> GetAllBooksWithPagination(int page);
        Task AddBookAsync(BookVM bookVM);
        Task DeleteBookAsync(int? id);
        Task<Book> GetBookByIdAsync(int? id);
        Task<Book> GetBookIncludeAsync(int? id);
        Task<ICollection<Book>> GetBookForAsCategory(int? id);
        Task<BookVM> GetBookEditAsync(int? id);
        Task UpdateBookAsync(int? id, BookVM bookVM);
        Task<PaginationVM<Book>> PaginationForBookAsync(int page);
    }
}
