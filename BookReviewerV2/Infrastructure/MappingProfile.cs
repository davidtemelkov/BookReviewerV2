using System.Globalization;
using AutoMapper;
using BookReviewerV2.Data.Models;
using BookReviewerV2.Models.Authors;
using BookReviewerV2.Models.Books;
using BookReviewerV2.Models.Lists;
using BookReviewerV2.Models.Reviews;
using BookReviewerV2.Models.Users;

namespace BookReviewerV2.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<AuthorFormModel, Author>()
            .ForMember(a 
                => a.DateOfBirth, 
                cfg 
                    => cfg.MapFrom(a 
                        => DateTime.ParseExact(a.DateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture)));

        this.CreateMap<Author, AuthorDetailsViewModel>()
            .ForMember(a 
                => a.DateOfBirth, 
                cfg 
                    => cfg.MapFrom(a => a.DateOfBirth.ToString("dd.MM.yyyy")));

        this.CreateMap<AuthorDetailsViewModel, AuthorFormModel>();

        this.CreateMap<BookFormModel, Book>()
            .ForMember(dest => dest.CoverURL, opt 
                => opt.MapFrom(src => src.CoverUrl))
            .ForMember(b => b.Author, cfg 
                => cfg.Ignore())
            .ForMember(b => b.BookGenres, cfg 
                => cfg.Ignore());

        this.CreateMap<Book, BookGridViewModel>()
            .ForMember(b 
                => b.Author, cfg 
                => cfg.MapFrom(b => b.Author.Name))
            .ForMember(b 
                => b.Genres, cfg 
                => cfg.MapFrom(b 
                    => string.Join(",", b.BookGenres.Select(g => g.Genre.Name))));

        this.CreateMap<Book, BookDetailsViewModel>()
            .ForMember(b
                => b.Genres, 
                cfg 
                    => cfg.MapFrom(g 
                        => string.Join(", ", g.BookGenres.Select(g => g.Genre.Name))));

        this.CreateMap<BookDetailsViewModel, BookFormModel>()
            .ForMember(b 
                => b.Author, 
                cfg 
                    => cfg.MapFrom(b => b.AuthorName))
            .ForMember(b 
                => b.Genres, cfg 
                => cfg.Ignore());

        this.CreateMap<ListFormModel, List>();

        this.CreateMap<List, ListDetailsViewModel>();

        this.CreateMap<ReviewFormModel, Review>()
            .ForMember(r 
                => r.Stars, 
                cfg 
                    => cfg.MapFrom(r 
                        => int.Parse(r.Stars)))
            .ReverseMap();

        this.CreateMap<User, UserProfileViewModel>()
            .ForMember(u 
                => u.ProfilePictureUrl, 
                cfg 
                    => cfg.MapFrom(u => u.ProfilePictureURL));
    }
}