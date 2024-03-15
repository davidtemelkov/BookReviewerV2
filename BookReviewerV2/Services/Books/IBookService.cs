using BookReviewerV2.Data.Models;
using BookReviewerV2.Models.Books;

namespace BookReviewerV2.Services.Books;

public interface IBookService
{
    IEnumerable<BookGridViewModel> GetAcceptedBooks();

    IEnumerable<BookGridViewModel> GetNonAcceptedBooks();

    void AdminCreate(BookFormModel book);

    void UserCreate(User currentUser, BookFormModel book);

    void Edit(string id, BookFormModel editedBook);

    BookDetailsViewModel BookDetails(string id);

    BookQueryViewModel SearchBooks(string searchTerm, string genre);

    public void AdminAcceptBook(string id);

    public void AdminDenyBook(string id);
}