using BookReviewerV2.Models.Authors;
using BookReviewerV2.Models.Books;
using BookReviewerV2.Services.Authors;
using BookReviewerV2.Services.Books;
using BookReviewerV2.Services.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static BookReviewerV2.Areas.Admin.AdminConstants;

namespace BookReviewerV2.Areas.Admin.Controllers;

[Area(AreaName)]
[Authorize(Roles = AdministratorRoleName)]
public class AdminController : Controller
{
    private readonly IAuthorService authors;
    private readonly IBookService books;
    private readonly IGenreService genres;

    public AdminController(IAuthorService authors,
        IBookService books,
        IGenreService genres)
    {
        this.authors = authors;
        this.books = books;
        this.genres = genres;
    }

    public IActionResult AddAuthor() => View();

    [HttpPost]
    public IActionResult AddAuthor(AuthorFormModel author)
    {
        if (!ModelState.IsValid)
        {
            return View(author);
        }

        this.authors.AdminCreate(author);

        return Redirect("/");
    }

    public IActionResult AddBook() => View(new BookFormModel
    {
        Genres = this.genres.GetGenres(),
        Authors = this.authors.GetAuthors()
    });

    [HttpPost]
    public IActionResult AddBook(BookFormModel book)
    {
        if (!ModelState.IsValid)
        {
            book.Genres = this.genres.GetGenres();
            book.Authors = this.authors.GetAuthors();

            return View(book);
        }

        this.books.AdminCreate(book);

        return Redirect("/");
    }

    public IActionResult AcceptNewBooks() 
        => View(this.books.GetNonAcceptedBooks());

    public IActionResult AcceptBook(string id)
    {
        this.books.AdminAcceptBook(id);

        return RedirectToAction("AcceptNewBooks", "Admin");
    }

    public IActionResult DenyBook(string id)
    {
        this.books.AdminDenyBook(id);

        return RedirectToAction("AcceptNewBooks", "Admin");
    }
}
