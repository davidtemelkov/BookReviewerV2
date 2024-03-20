using BookReviewerV2.Models.Books;

namespace BookReviewerV2.Models.Lists;

public class ListDetailsViewModel
{
    public int Id { get; init; }

    public string UserId { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public IEnumerable<BookGridViewModel> AddedBooks { get; set; } 

    public IEnumerable<BookGridViewModel> AvailableBooks { get; set; } 
}