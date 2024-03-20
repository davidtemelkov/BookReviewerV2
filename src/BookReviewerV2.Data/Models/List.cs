using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReviewerV2.Data.Models;

public class List
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public string? Description { get; set; }
    
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    public ICollection<ListBook> ListBooks { get; set; }
}