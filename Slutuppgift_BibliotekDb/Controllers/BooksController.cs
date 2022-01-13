using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slutuppgift_BibliotekDb.Data;
using Slutuppgift_BibliotekDb.Models;

namespace Slutuppgift_BibliotekDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Context _context;

        public BooksController(Context context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound($"No book with id: {id} found");
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest($"No book with id: {id} found");
            }
            var testString = book.Loaned.ToUpper();
            if (book.ISBN < 1000000 || book.ISBN > 9999999)
            {
                return BadRequest("The books ISBN must contain 7 numbers and cant start with 0");
            }
            if (testString == null)
            {
                return BadRequest("Loaned cant be empty");
            }
            if (testString != "YES" && testString != "NO")
            {
                return BadRequest("Loaned must contain 'yes' or 'no'");
            }
            if (!DateTime.TryParseExact(book.PublishDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime datetime))
            {
                return BadRequest("PublishDate must be in format dd-MM-yyyy");
            }
            _context.Update(book);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            try
            {
                var testString = book.Loaned.ToUpper();
                if (book.ISBN < 1000000 || book.ISBN > 9999999)
                {
                    return BadRequest("The books ISBN must contain 7 numbers and cant start with 0");
                }
                if(testString == null)
                {
                    return BadRequest("Loaned cant be empty");
                }
                if(testString != "YES" && testString != "NO")
                {
                    return BadRequest("Loaned must contain 'yes' or 'no'");
                }
                if(!DateTime.TryParseExact(book.PublishDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime datetime))
                {
                    return BadRequest("PublishDate must be in format dd-MM-yyyy");
                }
                _context.Books.Add(book);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
