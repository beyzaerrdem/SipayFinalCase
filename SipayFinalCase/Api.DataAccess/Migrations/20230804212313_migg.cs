using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.DataAccess.Migrations
{
    public partial class migg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditAmount",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "DebitAmount",
                table: "Invoices",
                newName: "ÖdenenAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ÖdenenAmount",
                table: "Invoices",
                newName: "DebitAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "CreditAmount",
                table: "Invoices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
