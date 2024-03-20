using BookReviewerV2.Data.Models;

namespace BookReviewerV2.Models.Books;

public class BookDetailsViewModel
{
    public int Id { get; init; }
    public string Title { get; init; }

    public string CoverUrl { get; init; }

    public string YearPublished { get; init; }

    public string AuthorName { get; init; }

    public int AuthorId { get; init; }

    public string Description { get; init; }

    public int Pages { get; init; }

    public string Genres { get; set; }

    public ICollection<Review> Reviews { get; set; }

    public string AverageRating => this.Reviews.Any() 
            ? this.Reviews.Average(r => r.Stars).ToString() 
            : "No ratings yet.";
}