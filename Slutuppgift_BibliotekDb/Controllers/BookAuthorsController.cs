using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class BookAuthorsController : ControllerBase
    {
        private readonly Context _context;

        public BookAuthorsController(Context context)
        {
            _context = context;
        }

        // GET: api/BookAuthors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthors()
        {
            return await _context.BookAuthors.ToListAsync();
        }

        // GET: api/BookAuthors/bookId/authorId
        [HttpGet("{bookId}/{authorId}")]
        public async Task<ActionResult<BookAuthor>> GetBookAuthor(int bookId, int authorId)
{
            var bookAuthor = await _context.BookAuthors.FirstOrDefaultAsync(ba => ba.BookId == bookId && ba.AuthorId == authorId);

            if (bookAuthor == null)
            {
                return NotFound();
            }

            return bookAuthor;
        }

        // PUT: api/BookAuthors/bookId/authorId
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{bookId}/{authorId}")]
        public async Task<IActionResult> PutBookAuthor(int bookId, int authorId, BookAuthor bookAuthor)
        {
            if (authorId != bookAuthor.AuthorId && bookId != bookAuthor.BookId)
            {
                return BadRequest();
            }

            _context.Update(bookAuthor);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAuthorExists(authorId, bookId))
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

        // POST: api/BookAuthors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookAuthor>> PostBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Add(bookAuthor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookAuthorExists(bookAuthor.AuthorId, bookAuthor.BookId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookAuthor", new { id = bookAuthor.AuthorId }, bookAuthor);
        }

        // DELETE: api/BookAuthors/bookId/authorId
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAuthor(int bookId, int authorId)
        { 
            var bookAuthor = await _context.BookAuthors.FirstOrDefaultAsync(ba => ba.BookId == bookId && ba.AuthorId == authorId);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            _context.BookAuthors.Remove(bookAuthor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookAuthorExists(int bookId, int authorId)
        {
            return _context.BookAuthors.Any(e => e.AuthorId == authorId && e.BookId == bookId);
        }
    }
}
