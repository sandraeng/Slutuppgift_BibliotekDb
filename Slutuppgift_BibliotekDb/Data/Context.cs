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
                optionsBuilder.UseSqlServer("Data Source=tcp:sandraengserver.database.windows.net,1433;Initial Catalog=Librarydb;User Id=Sandra;Password=qwerty123-");
            }
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ActiveBookLoan> ActiveBookLoans { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<LoanHistory> LoanHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanHistory>().HasKey(lh => lh.LoanId);
            modelBuilder.Entity<LoanHistory>().HasOne(lh => lh.Book).WithMany(b => b.LoanHistories).HasForeignKey(lh => lh.BookId);

            modelBuilder.Entity<Customer>().HasKey(c => c.LibraryCardNr);
            modelBuilder.HasSequence<int>("Sequense", schema: "shared").StartsAt(1001).IncrementsBy(1);
            modelBuilder.Entity<Customer>().Property(c => c.LibraryCardNr).HasDefaultValueSql("NEXT VALUE FOR shared.Sequense");

            modelBuilder.Entity<ActiveBookLoan>().HasOne(rh => rh.Customer).WithMany(c => c.BookLoans).HasForeignKey(rh => rh.LibraryCardNr);

            modelBuilder.Entity<ActiveBookLoan>().HasOne(bl => bl.Book).WithMany(b => b.BookLoans).HasForeignKey(bl => bl.BookId);

            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.AuthorId, ba.BookId});

            modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Book).WithMany(c => c.BookAuthors).HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Author).WithMany(c => c.BookAuthors).HasForeignKey(ba => ba.AuthorId);


        }
    }
}
