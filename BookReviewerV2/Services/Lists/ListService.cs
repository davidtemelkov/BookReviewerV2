using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookReviewerV2.Data;
using BookReviewerV2.Data.Models;
using BookReviewerV2.Models.Books;
using BookReviewerV2.Models.Lists;
using BookReviewerV2.Services.Books;
using Microsoft.EntityFrameworkCore;

namespace BookReviewerV2.Services.Lists;

public class ListService : IListService
{
        private readonly ApplicationDbContext data;
        private readonly IBookService books;
        private readonly IMapper mapper;

        public ListService(ApplicationDbContext data,
            IBookService books,
            IMapper mapper)
        {
            this.data = data;
            this.books = books;
            this.mapper = mapper;
        }

        public AllListsViewModel GetUserLists(string id)
        {
            var listData = new AllListsViewModel
            {
                UserId = id,
                Lists = this.data.Users.Include(x => x.Lists).FirstOrDefault(u => u.Id == id).Lists.ToList()
            };

            return listData;
        }

        public int Create(string userId, ListFormModel list)
        {
            var listData = this.mapper.Map<List>(list);
            listData.UserId = userId;

            this.data.Lists.Add(listData);
            this.data.SaveChanges();
            this.data.Entry(listData).GetDatabaseValues();

            return listData.Id;
        }

        public ListDetailsViewModel GetListDetails(string id)
        {
            var list = this.data.Lists.Where(l => l.Id == int.Parse(id));

            var bookDetails = list.ProjectTo<ListDetailsViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

            var addedBooks = this.data.ListBooks.Where(l => l.ListId == int.Parse(id))
                .Select(b => b.Book).ProjectTo<BookGridViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            var availableBooks = this.books.GetAcceptedBooks()
               .Where(b => addedBooks.FirstOrDefault(x => x.Id == b.Id) == null)
               .ToList();

            bookDetails.AddedBooks = addedBooks;
            bookDetails.AvailableBooks = availableBooks;

            return bookDetails;
        }

        public void Delete(string id)
        {
            var list = this.data.Lists.FirstOrDefault(l => l.Id == int.Parse(id));
            this.data.Lists.Remove(list);
            this.data.SaveChanges();
        }

        public void AddBook(string bookId, string listId)
        {
            this.data.ListBooks.Add(new ListBook { BookId = int.Parse(bookId), ListId = int.Parse(listId) });
            this.data.SaveChanges();
        }

        public void RemoveBook(string bookId, string listId)
        {
            var book = this.data.ListBooks.FirstOrDefault(b => b.BookId == int.Parse(bookId) && b.ListId == int.Parse(listId));
            this.data.ListBooks.Remove(book);
            this.data.SaveChanges();
        }

        public bool UserOwnsList(string userId, string listId)
            => this.data.Lists
            .FirstOrDefault(l => l.Id == int.Parse(listId)).UserId == userId;
    }