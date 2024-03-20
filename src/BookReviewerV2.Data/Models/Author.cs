using System.ComponentModel.DataAnnotations;

namespace BookReviewerV2.Data.Models;

public class Author
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(256)]
    public string Name { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; } 

    [Required]
    [MaxLength(500)]
    public string Details { get; set; }

    public string PictureUrl { get; set; }

    public ICollection<Book> AuthoredBooks { get; init; }
}