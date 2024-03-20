using System.ComponentModel.DataAnnotations;

namespace BookReviewerV2.Models.Users;

public class ChangeProfilePictureFormModel
{
    [Required]
    [Url]
    public string PictureUrl { get; init; }
}