using System.ComponentModel.DataAnnotations;

using static BookReviewerV2.Models.Constants;

namespace BookReviewerV2.Models.Books;

public class BookFormModel
{
    [Required]
    [StringLength(BookMaxTitle,
        MinimumLength = BookMinTitle,
        ErrorMessage = "The title of the book must be between {2} and {1} characters!")]
    public string Title { get; init; }

    [StringLength(AuthorMaxName,
        MinimumLength = AuthorMinName)]
    public string? Author { get; init; }

    [Required]
    [Url]
    [Display(Name = "Cover")]
    public string CoverUrl { get; init; }

    [Required]
    [Range(YearMinValue, YearMaxValue, ErrorMessage = "The year must be between 999 and 3000.")]
    [Display(Name = "Year published")]
    public int YearPublished { get; set; }

    [Required]
    [Range(BookMinPages ,BookMaxPages,
        ErrorMessage = "The pages of the book must be between {1} and {2}!")]
    public int Pages { get; init; }

    [Required]
    [StringLength(BookMaxDescription, MinimumLength = BookMinDescription,
        ErrorMessage = "The description of the book must be between {2} and {1} characters!")]
    public string Description { get; init; }

    [Required] [Display(Name = "Genres")] public ICollection<string> BookGenres { get; init; } = new List<string>();

    public IEnumerable<string>? Genres { get; set; } 

    public IEnumerable<string>? Authors { get; set; }
}