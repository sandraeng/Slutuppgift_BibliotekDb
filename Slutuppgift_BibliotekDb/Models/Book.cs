using System.Collections.Generic;

namespace Slutuppgift_BibliotekDb.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public string BookTitle { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string PublishDate { get; set; }
        public double Rating { get; set; }
        public bool IsRented { get; set; }
        public ICollection<RentHistory> RentHistory { get; set; }

    }
}
