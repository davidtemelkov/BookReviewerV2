using BookReviewerV2.Models.Users;
using BookReviewerV2.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewerV2.Controllers;

public class UsersController : Controller
{
    private readonly IUserService users;

    public UsersController(IUserService users)
    {
        this.users = users;
    }

    public IActionResult Profile(string id) 
        => View(users.Profile(id));

    public IActionResult ChangeProfilePicture(string id) 
        => View();

    [HttpPost]
    public IActionResult ChangeProfilePicture(string id, ChangeProfilePictureFormModel profilePic)
    {
        if (!ModelState.IsValid)
        {
            return View(profilePic);
        }

        this.users.ChangeProfilePicture(id, profilePic);

        return Redirect($"/Users/Profile/{id}");
    }
}