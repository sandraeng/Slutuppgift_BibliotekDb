using System;
using System.ComponentModel.DataAnnotations;

namespace Slutuppgift_BibliotekDb.Models
{
    public class BookLoan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int LibraryCardNr { get; set; }
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public string IsLoanActive { get; set; }
        public string LoanDate { get; set; } 
        public string ReturnDate { get; set; }

        public BookLoan()
        {
            IsLoanActive = "Yes";
           
        }
    }
}
