using BookReviewerV2.Data.Models;
using BookReviewerV2.Models.Users;

namespace BookReviewerV2.Services.Users;

public interface IUserService
{
    UserProfileViewModel Profile(string id);

    void ChangeProfilePicture(string id, ChangeProfilePictureFormModel picture);

    User GetUserById(string id);
}