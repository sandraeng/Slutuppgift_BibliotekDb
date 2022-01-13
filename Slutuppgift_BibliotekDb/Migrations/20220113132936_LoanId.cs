using Microsoft.EntityFrameworkCore.Migrations;

namespace Slutuppgift_BibliotekDb.Migrations
{
    public partial class LoanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoanHistories",
                newName: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "LoanHistories",
                newName: "Id");
        }
    }
}
