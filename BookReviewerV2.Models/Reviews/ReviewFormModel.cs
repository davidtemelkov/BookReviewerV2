using System.ComponentModel.DataAnnotations;

namespace BookReviewerV2.Models.Reviews;

public class ReviewFormModel
{
    [Required(ErrorMessage = "This field is required!")]
    public string Stars { get; init; }

    public string Text { get; init; }
       
    public string? UserId { get; init; }
       
    public int? BookId {get;init;}
}