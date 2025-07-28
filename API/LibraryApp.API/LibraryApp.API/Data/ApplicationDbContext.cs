using LibraryApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Book> Books { get; set; }
    }
}
