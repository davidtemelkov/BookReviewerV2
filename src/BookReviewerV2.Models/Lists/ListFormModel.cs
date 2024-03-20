using System.ComponentModel.DataAnnotations;

namespace BookReviewerV2.Models.Lists;

public class ListFormModel
{
    [Required]
    [StringLength(50,
        MinimumLength = 1,
        ErrorMessage = "The title of the book must be between {2} and {1} characters!")]
    public string Name { get; set; }

    [StringLength(500,
        ErrorMessage = "The title of the book must be between less than {1} characters!")]
    public string Description { get; set; }
}