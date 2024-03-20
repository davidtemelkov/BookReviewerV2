using AutoMapper;
using BookReviewerV2.Data;
using BookReviewerV2.MVC.Infrastructure;
using BookReviewerV2.Models.Books;
using BookReviewerV2.Services.Authors;
using BookReviewerV2.Services.Books;
using BookReviewerV2.Services.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewerV2.MVC.Controllers;

public class BooksController : Controller
{
    private readonly IBookService books;
    private readonly ApplicationDbContext data;
    private readonly IGenreService genres;
    private readonly IAuthorService authors;
    private readonly IMapper mapper;

    public BooksController(IBookService books,
        ApplicationDbContext data,
        IGenreService genres,
        IAuthorService authors,
        IMapper mapper)
    {
        this.books = books;
        this.data = data;
        this.genres = genres;
        this.authors = authors;
        this.mapper = mapper;
    }

    [Authorize]
    public IActionResult Add()
    {
        if (!this.authors.IsAuthor(User.Id()))
        {
            return RedirectToAction("Add", "Authors");
        }

        return View(new BookFormModel
        {
            Genres = this.genres.GetGenres()
        });
    }

    [Authorize]
    [HttpPost]
    public IActionResult Add(BookFormModel book)
    {
        if (!ModelState.IsValid)
        {
            book.Genres = this.genres.GetGenres();

            return View(book);
        }

        var currentUser = this.data.Users
            .FirstOrDefault(u => u.Id == User.Id());

        this.books.UserCreate(currentUser, book);

        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    public IActionResult Edit(string id)
    {
        if (!this.authors.IsAuthorOfBook(User.Id(), id) && !User.IsAdmin())
        {
            return Unauthorized();
        }

        var book = this.books.BookDetails(id);

        var editBookForm = this.mapper.Map<BookFormModel>(book);
        editBookForm.Genres = this.genres.GetGenres();

        return View(editBookForm);
    }

    [HttpPost]
    public IActionResult Edit(string id, BookFormModel editedBook)
    {
        if (!ModelState.IsValid)
        {
            editedBook.Genres = this.genres.GetGenres();

            return View(editedBook);
        }

        this.books.Edit(id, editedBook);

        return Redirect($"/Books/Details/{id}");
    }

    public IActionResult Details(string id) => View(books.BookDetails(id));

    public IActionResult Search(string searchTerm, string genre)
    {
        if (this.books.SearchBooks(searchTerm, genre) == null)
        {
            return Redirect("/");
        }

        return View((this.books.SearchBooks(searchTerm, genre)));
    }
}