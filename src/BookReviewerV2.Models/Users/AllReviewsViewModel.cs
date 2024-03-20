using BookReviewerV2.Data.Models;

namespace BookReviewerV2.Models.Users;

public class AllReviewsViewModel
{
    public ICollection<Review> Reviews { get; set; }
}