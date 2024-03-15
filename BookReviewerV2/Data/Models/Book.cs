using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReviewerV2.Data.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(255)]
    public string CoverURL { get; set; }

    public int? YearPublished { get; set; }

    public int? Pages { get; set; }

    public string Description { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool IsAccepted { get; set; }
    
    public int AuthorId { get; set; }
    
    [ForeignKey("AuthorId")]
    public Author Author { get; set; }
    
    public ICollection<BookGenre> BookGenres { get; set; }
    public ICollection<ListBook> ListBooks { get; set; }
    public ICollection<Review> Reviews { get; set; }
}