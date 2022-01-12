using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Slutuppgift_BibliotekDb.Models
{
    public class Author
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
