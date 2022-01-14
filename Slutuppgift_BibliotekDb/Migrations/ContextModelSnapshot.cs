﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Slutuppgift_BibliotekDb.Data;

namespace Slutuppgift_BibliotekDb.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.HasSequence<int>("Sequense", "shared")
                .StartsAt(1001L);

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.ActiveBookLoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("IsLoanActive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LibraryCardNr")
                        .HasColumnType("int");

                    b.Property<string>("LoanDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReturnDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("LibraryCardNr");

                    b.ToTable("BookLoans");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<string>("Loaned")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.BookAuthor", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.Customer", b =>
                {
                    b.Property<int>("LibraryCardNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR shared.Sequense");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LibraryCardNr");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.LoanHistory", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("LoanDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReturnDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoanId");

                    b.HasIndex("BookId");

                    b.ToTable("LoanHistories");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.ActiveBookLoan", b =>
                {
                    b.HasOne("Slutuppgift_BibliotekDb.Models.Book", "Book")
                        .WithMany("BookLoans")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Slutuppgift_BibliotekDb.Models.Customer", "Customer")
                        .WithMany("BookLoans")
                        .HasForeignKey("LibraryCardNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.BookAuthor", b =>
                {
                    b.HasOne("Slutuppgift_BibliotekDb.Models.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Slutuppgift_BibliotekDb.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.LoanHistory", b =>
                {
                    b.HasOne("Slutuppgift_BibliotekDb.Models.Book", "Book")
                        .WithMany("LoanHistories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookLoans");

                    b.Navigation("LoanHistories");
                });

            modelBuilder.Entity("Slutuppgift_BibliotekDb.Models.Customer", b =>
                {
                    b.Navigation("BookLoans");
                });
#pragma warning restore 612, 618
        }
    }
}
