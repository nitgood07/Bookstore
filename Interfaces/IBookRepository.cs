using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    interface IBookRepository:IRepositoryBase<Book>
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int bookId);
        Book GetBookByAuthor(int authorId);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
