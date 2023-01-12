using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public BooksController(BookStoreContext context) 
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks() 
        {
            var books = await _context.Books.ToArrayAsync();
            return Ok(books);
        }

        // public IEnumerable<Book> GetAllBooks()
        // {
        //     return _context.Books.ToArray();
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById(int id) 
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) {
                return NotFound();
            }
            return Ok(book);
        }
    }
}