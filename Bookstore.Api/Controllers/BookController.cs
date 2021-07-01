using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public BookController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _repository.Book.GetAllBooks();
                _logger.LogInfo($"GetAllBooks: Returned all books from db.");

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllBooks: Something went wrong inside GetAllBooks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
            try
            {
                var book = _repository.Book.GetBookById(bookId);
                if (book == null)
                {
                    _logger.LogError($"GetBookById: Book with id: {bookId}, isn't found.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"GetBookById: Returned book with id: {bookId}");
                    return Ok(book);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetBookById: Something went wrong inside GetBookById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{authorId}/author")]
        public IActionResult GetBookByAuthor(int authorId)
        {
            try
            {
                var books = _repository.Book.GetBookByAuthor(authorId);
                if (books == null)
                {
                    _logger.LogError($"GetBookByAuthor: Books with author id: {authorId}, isn't found.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"GetBookByAuthor: Returned books for author");

                    return Ok(books);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetBookByAuthor Something went wrong inside GetBookByAuthor action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
