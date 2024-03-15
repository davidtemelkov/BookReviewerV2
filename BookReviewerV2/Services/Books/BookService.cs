using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookReviewerV2.Data;
using BookReviewerV2.Data.Models;
using BookReviewerV2.Models.Books;
using BookReviewerV2.Services.Genre;
using Microsoft.EntityFrameworkCore;

namespace BookReviewerV2.Services.Books;

public class BookService : IBookService
{
        private readonly ApplicationDbContext data;
        private readonly IGenreService genres;
        private readonly IMapper mapper;

        public BookService(ApplicationDbContext data,
            IGenreService genres,
            IMapper mapper)
        {
            this.data = data;
            this.genres = genres;
            this.mapper = mapper;
        }

        public IEnumerable<BookGridViewModel> GetAcceptedBooks()
        {
            var books = this.data.Books
               .OrderByDescending(b => b.Reviews.Select(r => r.Stars).Average())
               .Where(b => b.IsAccepted)
               .ProjectTo<BookGridViewModel>(this.mapper.ConfigurationProvider)
               .ToList();

            return books;
        }

        public IEnumerable<BookGridViewModel> GetNonAcceptedBooks()
        {
            var books = this.data
               .Books
               .Where(b => !b.IsAccepted)
               .OrderByDescending(b => b.DateAdded)
               .ProjectTo<BookGridViewModel>(this.mapper.ConfigurationProvider)
               .ToList();

            return books;
        }

        public void AdminCreate(BookFormModel book)
        {
            var bookData = this.mapper.Map<Book>(book);
            bookData.Author = this.data.Authors.FirstOrDefault(a => a.Name == book.Author);
            bookData.IsAccepted = true;

            foreach (var genre in book.BookGenres)
            {
                bookData.BookGenres.Add(new BookGenre { Book = bookData, Genre = this.data.Genres.FirstOrDefault(g => g.Name == genre) });
            }

            this.data.Books.Add(bookData);
            this.data.SaveChanges();
        }

        public void UserCreate(User currentUser, BookFormModel book)
        {
            var bookData = this.mapper.Map<Book>(book);
            bookData.Author = this.data.Authors.FirstOrDefault(a => a.Id == currentUser.AuthorId);

            foreach (var genre in book.BookGenres)
            {
                bookData.BookGenres.Add(new BookGenre { Book = bookData, Genre = data.Genres.FirstOrDefault(g => g.Name == genre) });
            }

            this.data.Books.Add(bookData);
            this.data.SaveChanges();
        }

        public void Edit(string id, BookFormModel editedBook)
        {
            var bookData = this.data.Books.Find(int.Parse(id));

            bookData.Title = editedBook.Title;
            bookData.CoverURL = editedBook.CoverUrl;
            bookData.Description = editedBook.Description;
            bookData.Pages = editedBook.Pages;
            bookData.YearPublished = editedBook.YearPublished;
            var genres = this.data.BookGenres.Where(bg => bg.BookId == int.Parse(id)).ToList();

            foreach (var genre in genres)
            {
                this.data.BookGenres.Remove(genre);
            }

            foreach (var genre in editedBook.BookGenres)
            {
                bookData.BookGenres.Add(new BookGenre { Book = bookData, Genre = data.Genres.FirstOrDefault(g => g.Name == genre) });
            }

            this.data.SaveChanges();
        }

        public BookDetailsViewModel BookDetails(string id)
        {
            var book = this.data.Books
                .Where(b => b.Id == int.Parse(id))
                .Include(b => b.Reviews)
                .ThenInclude(r => r.User);

            var bookDetails = book.ProjectTo<BookDetailsViewModel>(this.mapper.ConfigurationProvider).FirstOrDefault();

            return bookDetails;
        }

        public BookQueryViewModel SearchBooks(string searchTerm, string genre)
        {
            var books = this.GetAcceptedBooks();

            if (searchTerm == null && genre == "All")
            {
                return null;
            }
            else if (searchTerm == null && genre != "All")
            {
                return new BookQueryViewModel
                {
                    Genres = this.genres.GetGenres(),
                    Books = books.Where(b => b.Genres.ToLower().Split(",").Any(g => g == genre.ToLower()))
                };
            }
            else if (searchTerm != null && genre == "All")
            {
                return new BookQueryViewModel
                {
                    Genres = this.genres.GetGenres(),
                    Books = books.Where(b => b.Title.ToLower().Contains(searchTerm.ToLower()))
                };
            }
            else
            {
                return new BookQueryViewModel
                {
                    Genres = this.genres.GetGenres(),
                    Books = books.Where(b => b.Title.ToLower().Contains(searchTerm.ToLower()) && b.Genres.ToLower().Split(",").Any(g => g == genre.ToLower()))
                };
            }
        }

        public void AdminAcceptBook(string id)
        {
            var book = this.data.Books.Find(int.Parse(id));

            book.IsAccepted = true;
            this.data.SaveChanges();
        }

        public void AdminDenyBook(string id)
        {
            var book = this.data.Books.Find(int.Parse(id));
            this.data.Books.Remove(book);
            this.data.SaveChanges();
        }
    }