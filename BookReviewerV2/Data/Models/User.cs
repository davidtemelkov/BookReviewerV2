using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookReviewerV2.Data.Models;

public class User : IdentityUser
{
    [MaxLength(500)]
    public string? Description { get; set; }
    
    [MaxLength(255)]
    public string? ProfilePictureURL { get; set; }

    public bool IsAuthor { get; set; }

    public DateTime? DateOfBirth { get; set; }
    
    public DateTime? AccountCreation { get; set; }
    
    public ICollection<Review> Reviews { get; set; }
    public ICollection<List> Lists { get; set; }
    public ICollection<Book> AuthoredBooks { get; set; }
}