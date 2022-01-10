using System.Collections.Generic;

namespace Slutuppgift_BibliotekDb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int LibraryCardNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<RentHistory> RentHistory { get; set; }
    }
}
