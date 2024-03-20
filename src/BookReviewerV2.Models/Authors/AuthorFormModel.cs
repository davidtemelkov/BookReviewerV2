using System.ComponentModel.DataAnnotations;

namespace BookReviewerV2.Models.Authors;

public class AuthorFormModel
{
    [Required]
    [StringLength(50,
        MinimumLength = 1)]
    public string Name { get; init; }

    [StringLength(10,
        MinimumLength = 10,
        ErrorMessage = "Format must be dd.mm.yyyy")]
    [Required]
    [Display(Name = "Date of birth")]
    public string DateOfBirth { get; init; }

    [Required]
    [StringLength(500,
        MinimumLength = 1,
        ErrorMessage = "Author details must be between {2} and {1} characters!")]
    public string Details { get; init; }

    [Required]
    [Url]
    [Display(Name = "Picture")]
    public string PictureUrl { get; init; }
}