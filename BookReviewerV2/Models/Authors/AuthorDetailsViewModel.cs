using BookReviewerV2.Models.Books;

namespace BookReviewerV2.Models.Authors;

public class AuthorDetailsViewModel
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string DateOfBirth { get; init; }

    public string Details { get; init; }

    public string PictureUrl { get; init; }

    public IEnumerable<BookGridViewModel> Books { get; set; }
}