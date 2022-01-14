using Microsoft.EntityFrameworkCore.Migrations;

namespace Slutuppgift_BibliotekDb.Migrations
{
    public partial class gaaaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AktiveBookLoans_Books_BookId",
                table: "AktiveBookLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_AktiveBookLoans_Customers_LibraryCardNr",
                table: "AktiveBookLoans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AktiveBookLoans",
                table: "AktiveBookLoans");

            migrationBuilder.RenameTable(
                name: "AktiveBookLoans",
                newName: "ActiveBookLoans");

            migrationBuilder.RenameIndex(
                name: "IX_AktiveBookLoans_LibraryCardNr",
                table: "ActiveBookLoans",
                newName: "IX_ActiveBookLoans_LibraryCardNr");

            migrationBuilder.RenameIndex(
                name: "IX_AktiveBookLoans_BookId",
                table: "ActiveBookLoans",
                newName: "IX_ActiveBookLoans_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActiveBookLoans",
                table: "ActiveBookLoans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveBookLoans_Books_BookId",
                table: "ActiveBookLoans",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveBookLoans_Customers_LibraryCardNr",
                table: "ActiveBookLoans",
                column: "LibraryCardNr",
                principalTable: "Customers",
                principalColumn: "LibraryCardNr",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActiveBookLoans_Books_BookId",
                table: "ActiveBookLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_ActiveBookLoans_Customers_LibraryCardNr",
                table: "ActiveBookLoans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActiveBookLoans",
                table: "ActiveBookLoans");

            migrationBuilder.RenameTable(
                name: "ActiveBookLoans",
                newName: "AktiveBookLoans");

            migrationBuilder.RenameIndex(
                name: "IX_ActiveBookLoans_LibraryCardNr",
                table: "AktiveBookLoans",
                newName: "IX_AktiveBookLoans_LibraryCardNr");

            migrationBuilder.RenameIndex(
                name: "IX_ActiveBookLoans_BookId",
                table: "AktiveBookLoans",
                newName: "IX_AktiveBookLoans_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AktiveBookLoans",
                table: "AktiveBookLoans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AktiveBookLoans_Books_BookId",
                table: "AktiveBookLoans",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AktiveBookLoans_Customers_LibraryCardNr",
                table: "AktiveBookLoans",
                column: "LibraryCardNr",
                principalTable: "Customers",
                principalColumn: "LibraryCardNr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
