using Entities;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return GetAll()
                .OrderBy(b => b.Title)
                .ToList();
        }

        public Book GetBookById(int bookId)
        {
            return GetByCondition(b => b.BookId.Equals(bookId))
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetBookByAuthor(int authorId)
        {
            return GetByCondition(b => b.AuthorId.Equals(authorId))
                .Include(a => a.Author)
                .OrderBy(b => b.Title)
                .ToList();
        }

        public void CreateBook(Book book)
        {
            Create(book);
        }

        public void UpdateBook(Book book)
        {
            Update(book);
        }

        public void DeleteBook(Book book)
        {
            Delete(book);
        }
    }
}
