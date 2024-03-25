using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static BookReviewerV2.Data.Constants;


namespace BookReviewerV2.Data.Models;

public class List
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ListMaxName)]
    public string Name { get; set; }

    public string? Description { get; set; }
    
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    public ICollection<ListBook> ListBooks { get; set; }
}