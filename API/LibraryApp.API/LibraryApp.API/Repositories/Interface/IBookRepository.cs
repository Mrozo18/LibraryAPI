using LibraryApp.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<Book> CreateBook(Book book);

        Task<IEnumerable<Book>> GetAllBooksAsync();

        Task<Book?> GetById(Guid id);

        Task<Book?> UpdateAsync(Book book);

        Task<Book?> DeleteAsync(Guid id);

    }
}
