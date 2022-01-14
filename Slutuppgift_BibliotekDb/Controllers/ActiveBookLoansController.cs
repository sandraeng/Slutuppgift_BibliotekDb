using System;
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
    public class ActiveBookLoansController : ControllerBase
    {
        private readonly Context _context;

        public ActiveBookLoansController(Context context)
        {
            _context = context;
          
        }

        // GET: api/ActiveBookLoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiveBookLoan>>> GetActiveBookLoans()
        {
            return await _context.ActiveBookLoans.ToListAsync();
        }

        // GET: api/ActiveBookLoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActiveBookLoan>> GetActiveBookLoan(int id)
        {
            var activeBookLoan = await _context.ActiveBookLoans.FindAsync(id);

            if (activeBookLoan == null)
            {
                return NotFound();
            }

            return activeBookLoan;
        }

        // PUT: api/BookLoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActiveBookLoan(int id, ActiveBookLoan activeBookLoan)
        {
            LoanHistory loanHistory = new LoanHistory();
            try
            {
                
                var testString = activeBookLoan.IsLoanActive.ToUpper();
                if (id != activeBookLoan.Id)
                {
                    return BadRequest($"The id input is incorrect, activebookloan id: {activeBookLoan.Id}, request id: {id}");
                }
                if (testString == "NO")
                {
                    Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == activeBookLoan.BookId);
                    activeBookLoan.Book = book;
                    activeBookLoan.Book.Loaned = "no";
                    activeBookLoan.ReturnDate = DateTime.Now.ToString(@"MM\-dd\-yyyy HH\:mm");
                    _context.Update(activeBookLoan);
                    loanHistory.Book = book;
                    loanHistory.LoanDate = activeBookLoan.LoanDate;
                    loanHistory.ReturnDate = activeBookLoan.ReturnDate;
                    _context.LoanHistories.Add(loanHistory);
                    _context.Remove(activeBookLoan);
                }
                if(testString != "YES" && testString != "NO")
                {
                    return BadRequest("IsLoanActive must contain 'Yes' or 'No'.");
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiveBookLoanExists(id))
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

        // POST: api/ActiveBookLoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActiveBookLoan>> PostActiveBookLoan(ActiveBookLoan activeBookLoan)
        {
            Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == activeBookLoan.BookId);
            activeBookLoan.Book = book;
            if(activeBookLoan.Book.Loaned.ToUpper() == "yes".ToUpper())
            {
                return BadRequest("Book is already loaned out!");
            }
            else
            {
                activeBookLoan.Book.Loaned = "yes";
            }
            activeBookLoan.LoanDate = DateTime.Now.ToString(@"MM\-dd\-yyyy HH\:mm");
            activeBookLoan.ReturnDate = "";
            _context.ActiveBookLoans.Add(activeBookLoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActiveBookLoanExists(activeBookLoan.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActiveBookLoan", new { id = activeBookLoan.Id }, activeBookLoan);
        }

        // DELETE: api/BookLoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActiveBookLoan(int id)
        {
            var activeBookLoan = await _context.ActiveBookLoans.FindAsync(id);
            if (activeBookLoan == null)
            {
                return NotFound($"BookLoan with id: {id} dont exist");
            }

            _context.ActiveBookLoans.Remove(activeBookLoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActiveBookLoanExists(int id)
        {
            return _context.ActiveBookLoans.Any(e => e.Id == id);
        }
    }
}
