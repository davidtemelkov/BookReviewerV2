using BookReviewerV2.Models.Lists;

namespace BookReviewerV2.Services.Lists;

public interface IListService
{
    AllListsViewModel GetUserLists(string id);

    int Create(string userId, ListFormModel list);

    void Delete(string id);

    ListDetailsViewModel GetListDetails(string id);

    void AddBook(string bookId, string listId);

    void RemoveBook(string bookId, string listId);

    bool UserOwnsList(string userId, string listId);
}