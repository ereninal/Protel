using Microsoft.EntityFrameworkCore.Migrations;

namespace Protel.DataAccess.Migrations
{
    public partial class CurrencyTypeTableUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Currencies",
                newName: "TrName");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Currencies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngName",
                table: "Currencies",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "EngName",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "TrName",
                table: "Currencies",
                newName: "Name");
        }
    }
}
