using AutoMapper;
using Entities.DTOs;
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
        private IMapper _mapper;

        public BookController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _repository.Book.GetAllBooks();
                _logger.LogInfo($"GetAllBooks: Returned all books from db.");

                var booksList = _mapper.Map<IEnumerable<BookDTO>>(books);
                return Ok(booksList);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllBooks: Something went wrong inside GetAllBooks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{bookId}", Name = "BookById")]
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

        [HttpPost]
        public IActionResult AddBook([FromBody] BookForCreationDTO book)
        {
            try
            {
                if (book == null)
                {
                    _logger.LogError("AddBook: Book object sent from client is null.");
                    return BadRequest("Book object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("AddBook: Invalid book object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var bookEntity = _mapper.Map<Book>(book);
                _repository.Book.CreateBook(bookEntity);
                _repository.Save();

                var createdBook = _mapper.Map<BookDTO>(bookEntity);

                return CreatedAtRoute("BookById", new { bookId = createdBook.BookId }, createdBook);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddBook: Something went wrong inside AddBook action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                if (book == null)
                {
                    _logger.LogError("UpdateBook: Book object sent from client is null.");
                    return BadRequest("Book object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("UpdateBook: Invalid book object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var bookEntity = _repository.Book.GetBookById(id);
                if(bookEntity == null)
                {
                    _logger.LogError($"UpdateBook: Book with id: {id}, isn't found.");
                    return NotFound();
                }
                _repository.Book.UpdateBook(bookEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateBook: Something went wrong inside AddBook action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var book = _repository.Book.GetBookById(id);
                if (book == null)
                {
                    _logger.LogError($"DeleteBook: Book with id: {id}, isn't found");
                    return NotFound();
                }

                _repository.Book.DeleteBook(book);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteBook: Something went wrong inside AddBook action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
