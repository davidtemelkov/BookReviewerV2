using System.ComponentModel.DataAnnotations;

namespace BookReviewerV2.Models.Books;

public class BookQueryViewModel
{
    [Display(Name = "Search by text")]
    public string SearchTerm { get; init; }

    public IEnumerable<string> Genres { get; set; }

    public string Genre { get; set; }

    public IEnumerable<BookGridViewModel> Books { get; init; }
}