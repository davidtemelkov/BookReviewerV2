using AutoMapper;
using BookReviewerV2.Data;
using BookReviewerV2.Data.Models;
using BookReviewerV2.Models.Users;

namespace BookReviewerV2.Services.Users;

public class UserService : IUserService
{
    private readonly ApplicationDbContext data;
    private readonly IMapper mapper;

    public UserService(ApplicationDbContext data,
        IMapper mapper)
    {
        this.data = data;
        this.mapper = mapper;
    }

    public UserProfileViewModel Profile(string id)
    {
        var user = this.data.Users.FirstOrDefault(u => u.Id == id);

        var profile = this.mapper.Map<UserProfileViewModel>(user);

        return profile;
    }

    public void ChangeProfilePicture(string id, ChangeProfilePictureFormModel picture)
    {
        this.GetUserById(id).ProfilePictureURL = picture.PictureUrl;
        this.data.SaveChanges();
    }

    public User GetUserById(string id) 
        => this.data.Users.FirstOrDefault(u => u.Id == id);
}