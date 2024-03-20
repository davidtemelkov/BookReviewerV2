using BookReviewerV2.Models.Authors;

namespace BookReviewerV2.Services.Authors;

public interface IAuthorService
{
    void AdminCreate(AuthorFormModel author);

    void UserCreate(AuthorFormModel author, string userId);

    void Edit(string id, AuthorFormModel editedAuthor);

    AuthorDetailsViewModel Details(string id);

    IEnumerable<string> GetAuthors();

    bool IsAuthorOfBook(string userId, string bookId);

    bool IsAuthor(string id);

    bool IsCurrentAuthor(string userId, string authorId);
}