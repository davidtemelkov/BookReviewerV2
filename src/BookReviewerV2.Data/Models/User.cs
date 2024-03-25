using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

using static BookReviewerV2.Data.Constants;

namespace BookReviewerV2.Data.Models;

public class User : IdentityUser
{
    [MaxLength(UserMaxDescription)]
    public string? Description { get; set; }
    
    [MaxLength(UserMaxProfilePictureUrl)]
    public string? ProfilePictureURL { get; set; }
    
    public int? AuthorId { get; set; }
    
    [ForeignKey("AuthorId")]
    public Author Author { get; set; }
    
    public DateTime? AccountCreation { get; set; }
    
    public ICollection<Review> Reviews { get; set; }
    
    public ICollection<List> Lists { get; set; }
}