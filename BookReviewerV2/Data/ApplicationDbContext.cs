using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookReviewerV2.Data.Models;

namespace BookReviewerV2.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<List> Lists { get; set; }
    public DbSet<ListBook> ListBooks { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}