using Microsoft.EntityFrameworkCore;
using Slutuppgift_BibliotekDb.Models;

namespace Slutuppgift_BibliotekDb.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentHistory> RentHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentHistory>().HasKey(rh => new { rh.CustomerId, rh.BookId });

            modelBuilder.Entity<RentHistory>().HasOne(rh => rh.Customer).WithMany(c => c.RentHistory).HasForeignKey(rh => rh.CustomerId);

            modelBuilder.Entity<RentHistory>().HasOne(rh => rh.Book).WithMany(b => b.RentHistory).HasForeignKey(rh => rh.BookId);

            modelBuilder.Entity<Book>().HasKey(b => new { b.AuthorId });
        }
    }
}
