using BookReviewerV2.Data.Models;

namespace BookReviewerV2.Models.Lists;

public class AllListsViewModel
{
    public string UserId { get; init; }

    public IEnumerable<List> Lists { get; init; }
}