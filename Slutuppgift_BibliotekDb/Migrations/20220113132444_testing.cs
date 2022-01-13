using Microsoft.EntityFrameworkCore.Migrations;

namespace Slutuppgift_BibliotekDb.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistories_Books_BookId1",
                table: "LoanHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanHistories",
                table: "LoanHistories");

            migrationBuilder.DropIndex(
                name: "IX_LoanHistories_BookId1",
                table: "LoanHistories");

            migrationBuilder.RenameColumn(
                name: "BookId1",
                table: "LoanHistories",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "LoanHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LoanHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanHistories",
                table: "LoanHistories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistories_BookId",
                table: "LoanHistories",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistories_Books_BookId",
                table: "LoanHistories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistories_Books_BookId",
                table: "LoanHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanHistories",
                table: "LoanHistories");

            migrationBuilder.DropIndex(
                name: "IX_LoanHistories_BookId",
                table: "LoanHistories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoanHistories",
                newName: "BookId1");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "LoanHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "BookId1",
                table: "LoanHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanHistories",
                table: "LoanHistories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistories_BookId1",
                table: "LoanHistories",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistories_Books_BookId1",
                table: "LoanHistories",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
