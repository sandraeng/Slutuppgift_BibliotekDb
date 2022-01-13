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
        public DbSet<LoanHistory> LoanHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanHistory>().HasKey(lh => lh.LoanId);
            modelBuilder.Entity<LoanHistory>().HasOne(lh => lh.Book).WithMany(b => b.LoanHistories).HasForeignKey(lh => lh.BookId);

            modelBuilder.Entity<Customer>().HasKey(c => c.LibraryCardNr);
            modelBuilder.HasSequence<int>("Sequense", schema: "shared").StartsAt(1001).IncrementsBy(1);
            modelBuilder.Entity<Customer>().Property(c => c.LibraryCardNr).HasDefaultValueSql("NEXT VALUE FOR shared.Sequense");

            modelBuilder.Entity<BookLoan>().HasOne(rh => rh.Customer).WithMany(c => c.BookLoans).HasForeignKey(rh => rh.LibraryCardNr);

            modelBuilder.Entity<BookLoan>().HasOne(bl => bl.Book).WithMany(b => b.BookLoans).HasForeignKey(bl => bl.BookId);

            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.AuthorId, ba.BookId});

            modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Book).WithMany(c => c.BookAuthors).HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Author).WithMany(c => c.BookAuthors).HasForeignKey(ba => ba.AuthorId);


        }
    }
}
