using AutoMapper;
using BookReviewerV2.MVC.Infrastructure;
using BookReviewerV2.Models.Authors;
using BookReviewerV2.Services.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewerV2.MVC.Controllers;

public class AuthorsController : Controller
{
    private readonly IAuthorService authors;
    private readonly IMapper mapper;

    public AuthorsController(IAuthorService authors,
        IMapper mapper)
    {
        this.authors = authors;
        this.mapper = mapper;
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AuthorFormModel author)
    {
        if (!ModelState.IsValid)
        {
            return View(author);
        }

        this.authors.UserCreate(author, User.Id());

        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    public IActionResult Edit(string id)
    {
        if (!this.authors.IsCurrentAuthor(User.Id(), id) && !User.IsAdmin())
        {
            return Redirect("Home/Error");
        }

        var author = this.authors.Details(id);

        var editAuthorForm = this.mapper.Map<AuthorFormModel>(author);

        return View(editAuthorForm);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Edit(string id, AuthorFormModel editedAuthor)
    {
        if (!ModelState.IsValid)
        {
            return View(editedAuthor);
        }

        this.authors.Edit(id, editedAuthor);

        return Redirect($"/Authors/Details/{id}");
    }

    public IActionResult Details(string id) => View(authors.Details(id));
}
