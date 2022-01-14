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
    public class CustomersController : ControllerBase
    {
        private readonly Context _context;

        public CustomersController(Context context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.LibraryCardNr)
            {
                return BadRequest();
            }

            _context.Update(customer);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.LibraryCardNr }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            LoanHistory loanHistory = new LoanHistory();
            var customer = await _context.Customers.Include(c => c.BookLoans).FirstOrDefaultAsync(c => c.LibraryCardNr == id);
            if (customer == null)
            {
                return NotFound();
            }
            if(customer.BookLoans.Any(c => c.ReturnDate == ""))
            {
                ActiveBookLoan bookLoan = _context.BookLoans.FirstOrDefault(c => c.LibraryCardNr == id && c.ReturnDate == "");
                loanHistory.BookId = bookLoan.BookId;
                loanHistory.LoanDate = bookLoan.LoanDate;
                loanHistory.ReturnDate = "Book not returned!";
                _context.LoanHistories.Add(loanHistory);
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.LibraryCardNr == id);
        }
    }
}
