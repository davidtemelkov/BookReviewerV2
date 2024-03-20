using System.ComponentModel.DataAnnotations;

namespace BookReviewerV2.Data.Models;

public class Genre
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<BookGenre> BookGenres { get; set; }
}