using BookApi.Models;
using BookApi.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = dbContext.Books.ToList();
            return Ok(allBooks);
        }
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = dbContext.Books.Find(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult AddBook(AddBookDTO addEmployeeDTo)
        {
            var Book = new Book
            {
                Author = addEmployeeDTo.Author,
                Description = addEmployeeDTo.Description,
                PublishDate = addEmployeeDTo.PublishDate,
                Title = addEmployeeDTo.Title,
            };
            dbContext.Books.Add(Book);
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBookDTO updateBookDTO)
        {
            var updatedBook = dbContext.Books.Find(id);
            if(updatedBook == null)
            {
                return NotFound();
            }

            updatedBook.Author = updateBookDTO.Author;
            updatedBook.Description = updateBookDTO.Description;
            updatedBook.PublishDate = updateBookDTO.PublishDate;
            updatedBook.Title = updateBookDTO.Title;
            

            dbContext.SaveChanges();
            return Ok(updatedBook);
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var deletedBook = dbContext.Books.Find(id);
            if (deletedBook == null)
            {
                return NotFound();
            }
            dbContext.Books.Remove(deletedBook);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
