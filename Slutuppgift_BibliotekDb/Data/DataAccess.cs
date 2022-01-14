using Slutuppgift_BibliotekDb.Models;
using System;

namespace Slutuppgift_BibliotekDb.Data
{
    public class DataAccess
    {

        public void SeedDatabase()
        {
            Context context = new Context();

            Author author = new Author();
            author.FirstName = "Jon";
            author.LastName = "Källqvuist";
            context.Authors.Add(author);

            Author author1 = new Author();
            author1.FirstName = "Sven";
            author1.LastName = "Hellman";
            context.Authors.Add(author1);

            Author author2 = new Author();
            author2.FirstName = "Folke";
            author2.LastName = "Nordman";
            context.Authors.Add(author2);

            Book book = new Book();
            book.ISBN = 6798268;
            book.BookTitle = "Into the blue";
            book.PublishDate = "12-12-2020";
            book.Rating = 3.2;
            book.Loaned = "Yes";
            context.Books.Add(book);

            Book book1 = new Book();
            book1.ISBN = 2687585;
            book1.BookTitle = "Once upon a time";
            book1.PublishDate = "06-10-2018";
            book1.Rating = 4.3;
            book1.Loaned = "No";
            context.Books.Add(book1);

            Book book2 = new Book();
            book2.ISBN = 1185093;
            book2.BookTitle = "The empty space";
            book2.PublishDate = "01-09-2015";
            book2.Rating = 4.8;
            book2.Loaned = "No";
            context.Books.Add(book2);

            Book book3 = new Book();
            book3.ISBN = 3597254;
            book3.BookTitle = "To eat a spider";
            book3.PublishDate = "07-11-2007";
            book3.Rating = 2.5;
            book3.Loaned = "Yes";
            context.Books.Add(book3);

            Customer customer = new Customer();
            customer.FirstName = "Mikael";
            customer.LastName = "Svensson";
            context.Customers.Add(customer);

            Customer customer1 = new Customer();
            customer1.FirstName = "Gustav";
            customer1.LastName = "Jonsson";
            context.Customers.Add(customer1);

            Customer customer2 = new Customer();
            customer2.FirstName = "Dea";
            customer2.LastName = "Magnusson";
            context.Customers.Add(customer2);

            Customer customer3 = new Customer();
            customer3.FirstName = "Lisa";
            customer3.LastName = "Fritz";
            context.Customers.Add(customer3);
           
            context.SaveChanges();

            BookAuthor bookAuthor = new BookAuthor();
            bookAuthor.BookId = 1;
            bookAuthor.AuthorId = 2;
            context.BookAuthors.Add(bookAuthor);

            BookAuthor bookAuthor1 = new BookAuthor();
            bookAuthor1.BookId = 2;
            bookAuthor1.AuthorId = 2;
            context.BookAuthors.Add(bookAuthor1);

            BookAuthor bookAuthor2 = new BookAuthor();
            bookAuthor2.BookId = 2;
            bookAuthor2.AuthorId = 3;
            context.BookAuthors.Add(bookAuthor2);

            BookAuthor bookAuthor3 = new BookAuthor();
            bookAuthor3.BookId = 3;
            bookAuthor3.AuthorId = 1;
            context.BookAuthors.Add(bookAuthor3);

            BookAuthor bookAuthor4 = new BookAuthor();
            bookAuthor4.BookId = 4;
            bookAuthor4.AuthorId = 3;
            context.BookAuthors.Add(bookAuthor4);

            ActiveBookLoan bookLoan = new ActiveBookLoan();
            bookLoan.BookId = 4;
            bookLoan.LibraryCardNr = 1001;
            bookLoan.LoanDate = DateTime.Now.ToString(@"MM\-dd\-yyyy HH\:mm");
            bookLoan.ReturnDate = "";
            context.BookLoans.Add(bookLoan);

            ActiveBookLoan bookLoan1 = new ActiveBookLoan();
            bookLoan1.BookId = 1;
            bookLoan1.LibraryCardNr = 1003;
            bookLoan1.LoanDate = DateTime.Now.ToString(@"MM\-dd\-yyyy HH\:mm");
            bookLoan1.ReturnDate = "";
            context.BookLoans.Add(bookLoan1);
            context.SaveChanges();
        }
    }
}
