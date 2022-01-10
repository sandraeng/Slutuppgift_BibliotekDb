using System;

namespace Slutuppgift_BibliotekDb.Models
{
    public class RentHistory
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentedDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; }

    }
}
