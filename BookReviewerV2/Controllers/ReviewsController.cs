using BookReviewerV2.Infrastructure;
using BookReviewerV2.Models.Reviews;
using BookReviewerV2.Services.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewerV2.Controllers;

public class ReviewsController : Controller
{
    private readonly IReviewService reviews;

    public ReviewsController(IReviewService reviews)
    {
        this.reviews = reviews;
    }

    [Authorize]
    public IActionResult Add()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public IActionResult Add(string id, ReviewFormModel review)
    {
        if (!ModelState.IsValid)
        {
            return View(review);
        }

        this.reviews.Create(id, User.Id(), review);

        return Redirect($"/Books/Details/{id}");
    }

    [Authorize]
    public IActionResult Edit(string id)
    {
        if (!this.reviews.UserOwnsReview(User.Id(), id) && !User.IsAdmin())
        {
            return Redirect("/Home/Error");
        }

        return View(this.reviews.Details(id));
    }


    [Authorize]
    [HttpPost]
    public IActionResult Edit(string id, ReviewFormModel editedReview)
    {
        var currentUserId = User.Id();

        this.reviews.Edit(id, editedReview);

        return Redirect($"/Reviews/UserReviews/{currentUserId}");
    }

    [Authorize]
    public IActionResult Delete(string id)
    {
        if (!this.reviews.UserOwnsReview(User.Id(), id) && !User.IsAdmin())
        {
            return Redirect("/Home/Error");
        }

        var userId = User.Id();

        this.reviews.Delete(id);

        return Redirect($"/Reviews/UserReviews/{userId}");
    }

    public IActionResult UserReviews(string id) => View(this.reviews.GetUserReviews(id));
}