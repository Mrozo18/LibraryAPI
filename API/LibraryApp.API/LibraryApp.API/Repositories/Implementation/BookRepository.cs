using LibraryApp.API.Data;
using LibraryApp.API.Models.Domain;
using LibraryApp.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.API.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Book> CreateBook(Book book)
        {
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
           return await dbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetById(Guid id)
        {
            return await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book?> UpdateAsync(Book book)
        {
            var existingBook = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == book.Id);

            if(existingBook != null)
            {
                dbContext.Entry(existingBook).CurrentValues.SetValues(book);
                await dbContext.SaveChangesAsync();
                return book;
            }

            return null;
        }

        public async Task<Book?> DeleteAsync(Guid id) 
        {
            var existingBook = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBook is null)
            {
                return null;
            }

            dbContext.Books.Remove(existingBook);
            await dbContext.SaveChangesAsync();
            return existingBook;
        }
    }
}
