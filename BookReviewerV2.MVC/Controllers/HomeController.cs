using System.Diagnostics;
using BookReviewerV2.Data.Models;
using Microsoft.AspNetCore.Mvc;
using BookReviewerV2.Models;
using BookReviewerV2.Models.Books;
using BookReviewerV2.Services.Books;
using BookReviewerV2.Services.Genre;
using Microsoft.AspNetCore.Identity;

namespace BookReviewerV2.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IBookService books;
    private readonly IGenreService genres;

    public HomeController(IBookService books,
        IGenreService genres,
        UserManager<User> userManager)
    {
        this.books = books;
        this.genres = genres;
    }

    public IActionResult Index() => View(new BookQueryViewModel
    {
        Genres = this.genres.GetGenres(),
        Books = this.books.GetAcceptedBooks()
    });

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}