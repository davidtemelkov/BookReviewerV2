using System.ComponentModel.DataAnnotations;

using static BookReviewerV2.Data.Constants;

namespace BookReviewerV2.Data.Models;

public class Author
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(AuthorMaxName)]
    public string Name { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; } 

    [Required]
    [MaxLength(AuthorMaxDetails)]
    public string Details { get; set; }

    public string PictureUrl { get; set; }

    public ICollection<Book> AuthoredBooks { get; init; }
}