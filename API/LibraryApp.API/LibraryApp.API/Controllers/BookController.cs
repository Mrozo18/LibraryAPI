using LibraryApp.API.Data;
using LibraryApp.API.Models.Domain;
using LibraryApp.API.Models.DTO;
using LibraryApp.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // 
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequestDto request)
        {
            // Mao DTO to Domain Model
            var category = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Year = request.Year,
                ISBN = request.ISBN
            };

            await bookRepository.CreateBook(category);

            // Domain model to DTO
            var response = new BookDto
            {
                Id = category.Id,
                Title = category.Title,
                Author = category.Author,
                Year = category.Year,
                ISBN = category.ISBN
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookRepository.GetAllBooksAsync();

            //Map Domain model to DTO

            var response = new List<BookDto>();
            foreach (var book in books)
            {
                response.Add(new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Year = book.Year,
                    ISBN = book.ISBN
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBooksById([FromRoute] Guid id)
        {
            var existingBook = await bookRepository.GetById(id);

            if(existingBook is null)
            {
                return NotFound();
            }

            var response = new BookDto
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
                Author = existingBook.Author,
                Year = existingBook.Year,
                ISBN = existingBook.ISBN
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditBook([FromRoute] Guid id, UpdateBookRequestDto request)
        {
            // Convert DTO to Domain Model
            var book = new Book
            {
                Id = id,
                Title = request.Title,
                Author = request.Author,
                Year = request.Year,
                ISBN = request.ISBN
            };

            book = await bookRepository.UpdateAsync(book);

            if (book == null)
            {
                return NotFound();
            }

            // Convert Domain model to DTO
            var response = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                ISBN = book.ISBN
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
           var book = await bookRepository.DeleteAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            var response = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                ISBN = book.ISBN
            };

            return Ok(response);
        }
    }
}
