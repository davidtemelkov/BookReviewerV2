using BookReviewerV2.Models.Reviews;
using BookReviewerV2.Models.Users;

namespace BookReviewerV2.Services.Reviews;

public interface IReviewService
{
    void Create(string bookId, string userId, ReviewFormModel review);

    void Edit(string id, ReviewFormModel editedReview);

    void Delete(string id);

    ReviewFormModel Details(string id);

    AllReviewsViewModel GetUserReviews(string id);

    bool UserOwnsReview(string userId, string reviewId);
}