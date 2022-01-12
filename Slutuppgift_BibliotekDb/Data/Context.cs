using Microsoft.EntityFrameworkCore;
using Slutuppgift_BibliotekDb.Models;

namespace Slutuppgift_BibliotekDb.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public Context()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database = LibraryDb; Trusted_Connection = true");
            }
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.LibraryCardNr);

            modelBuilder.Entity<BookLoan>().HasOne(rh => rh.Customer).WithMany(c => c.BookLoans).HasForeignKey(rh => rh.LibraryCardNr);

            modelBuilder.Entity<BookLoan>().HasOne(rh => rh.Book).WithMany(b => b.BookLoans).HasForeignKey(rh => rh.BookId);

            modelBuilder.Entity<BookAuthor>().HasKey(ab => new { ab.AuthorId, ab.BookId});

            modelBuilder.Entity<BookAuthor>().HasOne(rh => rh.Book).WithMany(c => c.BookAuthors).HasForeignKey(rh => rh.BookId);

            modelBuilder.Entity<BookAuthor>().HasOne(rh => rh.Author).WithMany(c => c.BookAuthors).HasForeignKey(rh => rh.AuthorId);


        }
    }
}
