using Microsoft.EntityFrameworkCore;

namespace BookReviewerV2.Data.Models;

[PrimaryKey(nameof(BookId), nameof(GenreId))] 
public class BookGenre
{
    public int BookId { get; set; }
    public int GenreId { get; set; }
    
    public Book Book { get; set; }
    public Genre Genre { get; set; }
}