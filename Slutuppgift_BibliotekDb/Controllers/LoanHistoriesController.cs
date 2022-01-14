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
    public class LoanHistoriesController : ControllerBase
    {
        private readonly Context _context;

        public LoanHistoriesController(Context context)
        {
            _context = context;
        }

        // GET: api/LoanHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanHistory>>> GetLoanHistories()
        {
            return await _context.LoanHistories.ToListAsync();
        }

        // GET: api/LoanHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanHistory>> GetLoanHistory(int id)
        {
            var loanHistory = await _context.LoanHistories.FindAsync(id);

            if (loanHistory == null)
            {
                return NotFound();
            }

            return loanHistory;
        }

        // PUT: api/LoanHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanHistory(int id, LoanHistory loanHistory)
        {
            if (id != loanHistory.LoanId)
            {
                return BadRequest($"LoanHistory with id: {id} dont exist");
            }

            _context.Update(loanHistory);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanHistoryExists(id))
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

        // POST: api/LoanHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanHistory>> PostLoanHistory(LoanHistory loanHistory)
        {
            
            _context.LoanHistories.Add(loanHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanHistory", new { id = loanHistory.LoanId }, loanHistory);
        }

        // DELETE: api/LoanHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanHistory(int id)
        {
            var loanHistory = await _context.LoanHistories.FindAsync(id);
            if (loanHistory == null)
            {
                return NotFound("No loanhistory found");
            }

            _context.LoanHistories.Remove(loanHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanHistoryExists(int id)
        {
            return _context.LoanHistories.Any(e => e.LoanId == id);
        }
    }
}
