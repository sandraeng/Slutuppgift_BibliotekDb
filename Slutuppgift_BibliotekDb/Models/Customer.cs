using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Slutuppgift_BibliotekDb.Models
{
    public class Customer
    {
        public int LibraryCardNr { get; set; }
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }
        public ICollection<BookLoan> BookLoans { get; set; }
    }
}
