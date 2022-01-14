using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Slutuppgift_BibliotekDb.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public int ISBN { get; set; }
        [StringLength(100)]
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string PublishDate { get; set; }
        [Required]
        public double Rating { get; set; }
        public string Loaned { get; set; }

        public ICollection<ActiveBookLoan> BookLoans { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<LoanHistory> LoanHistories { get; set; }


    }
}
