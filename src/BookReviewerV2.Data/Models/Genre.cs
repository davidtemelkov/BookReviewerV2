using System.ComponentModel.DataAnnotations;

using static BookReviewerV2.Data.Constants;

namespace BookReviewerV2.Data.Models;

public class Genre
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GenreMaxName)]
    public string Name { get; set; }

    public ICollection<BookGenre> BookGenres { get; set; }
}