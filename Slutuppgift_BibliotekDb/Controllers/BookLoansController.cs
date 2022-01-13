﻿using System;
using System.Collections.Generic;
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
    public class BookLoansController : ControllerBase
    {
        private readonly Context _context;

        public BookLoansController(Context context)
        {
            _context = context;
          
        }

        // GET: api/BookLoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookLoan>>> GetBookLoans()
        {
            return await _context.BookLoans.ToListAsync();
        }

        // GET: api/BookLoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookLoan>> GetBookLoan(int id)
        {
            var bookLoan = await _context.BookLoans.FindAsync(id);

            if (bookLoan == null)
            {
                return NotFound();
            }

            return bookLoan;
        }

        // PUT: api/BookLoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookLoan(int id, BookLoan bookLoan)
        {
            LoanHistory loanHistory = new LoanHistory();
            try
            {
                
                var testString = bookLoan.IsLoanActive.ToUpper();
                if (id != bookLoan.Id)
                {
                    return BadRequest($"The id input is incorrect, bookloan id: {bookLoan.Id}, request id: {id}");
                }
                if (testString == "NO")
                {
                    Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookLoan.BookId);
                    bookLoan.Book = book;
                    bookLoan.Book.Loaned = "no";
                    bookLoan.ReturnDate = DateTime.Now.ToString(@"MM\-dd\-yyyy HH\:mm");
                    _context.Update(bookLoan);
                    loanHistory.Book = book;
                    loanHistory.LoanDate = bookLoan.LoanDate;
                    loanHistory.ReturnDate = bookLoan.ReturnDate;
                    _context.LoanHistories.Add(loanHistory);
                }
                if(testString != "YES" && testString != "NO")
                {
                    return BadRequest("IsLoanActive must contain 'Yes' or 'No'.");
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookLoanExists(id))
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

        // POST: api/BookLoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookLoan>> PostBookLoan(BookLoan bookLoan)
        {
            Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookLoan.BookId);
            bookLoan.Book = book;
            if(bookLoan.Book.Loaned.ToUpper() == "yes".ToUpper())
            {
                return BadRequest("Book is already loaned out!");
            }
            else
            {
                bookLoan.Book.Loaned = "yes";
            }
            bookLoan.LoanDate = DateTime.Now.ToString(@"MM\-dd\-yyyy HH\:mm");
            bookLoan.ReturnDate = "";
            _context.BookLoans.Add(bookLoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookLoanExists(bookLoan.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookLoan", new { id = bookLoan.Id }, bookLoan);
        }

        // DELETE: api/BookLoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookLoan(int id)
        {
            var bookLoan = await _context.BookLoans.FindAsync(id);
            if (bookLoan == null)
            {
                return NotFound($"BookLoan with id: {id} dont exist");
            }

            _context.BookLoans.Remove(bookLoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookLoanExists(int id)
        {
            return _context.BookLoans.Any(e => e.Id == id);
        }
    }
}
