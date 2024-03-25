using System.ComponentModel.DataAnnotations;

using static BookReviewerV2.Models.Constants;

namespace BookReviewerV2.Models.Authors;

public class AuthorFormModel
{
    [Required]
    [StringLength(AuthorMaxName,
        MinimumLength = AuthorMinName)]
    public string Name { get; init; }

    [StringLength(AuthorDateOfBirthChars,
        MinimumLength = AuthorDateOfBirthChars,
        ErrorMessage = "Format must be dd.mm.yyyy")]
    [Required]
    [Display(Name = "Date of birth")]
    public string DateOfBirth { get; init; }

    [Required]
    [StringLength(AuthorMaxDetails,
        MinimumLength = AuthorMinDetails,
        ErrorMessage = "Author details must be between {2} and {1} characters!")]
    public string Details { get; init; }

    [Required]
    [Url]
    [Display(Name = "Picture")]
    public string PictureUrl { get; init; }
}