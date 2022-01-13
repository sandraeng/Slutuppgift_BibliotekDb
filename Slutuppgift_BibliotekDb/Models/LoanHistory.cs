namespace Slutuppgift_BibliotekDb.Models
{
    public class LoanHistory
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string LoanDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
