using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReviewerV2.Data.Models;

public class Review
{
    [Key]
    public int Id { get; set; }

    public int Stars { get; set; }

    public string? Text { get; set; }

    public DateTime DateAdded { get; set; }

    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }

    public int BookId { get; set; }
    [ForeignKey("BookId")]
    public Book Book { get; set; }
}