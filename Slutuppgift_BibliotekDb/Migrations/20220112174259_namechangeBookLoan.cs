using Microsoft.EntityFrameworkCore.Migrations;

namespace Slutuppgift_BibliotekDb.Migrations
{
    public partial class namechangeBookLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanHistories");

            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LibraryCardNr = table.Column<int>(type: "int", nullable: false),
                    IsLoanActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookLoans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoans_Customers_LibraryCardNr",
                        column: x => x.LibraryCardNr,
                        principalTable: "Customers",
                        principalColumn: "LibraryCardNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_BookId",
                table: "BookLoans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_LibraryCardNr",
                table: "BookLoans",
                column: "LibraryCardNr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoans");

            migrationBuilder.CreateTable(
                name: "LoanHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    IsLoanActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibraryCardNr = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanHistories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanHistories_Customers_LibraryCardNr",
                        column: x => x.LibraryCardNr,
                        principalTable: "Customers",
                        principalColumn: "LibraryCardNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistories_BookId",
                table: "LoanHistories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistories_LibraryCardNr",
                table: "LoanHistories",
                column: "LibraryCardNr");
        }
    }
}
