using Microsoft.EntityFrameworkCore.Migrations;

namespace Protel.DataAccess.Migrations
{
    public partial class CurrencyInfoColumnsNameIsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentRate",
                table: "CurrencyInfo",
                newName: "ForexSelling");

            migrationBuilder.AddColumn<decimal>(
                name: "BanknoteBuying",
                table: "CurrencyInfo",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BanknoteSelling",
                table: "CurrencyInfo",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ForexBuying",
                table: "CurrencyInfo",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanknoteBuying",
                table: "CurrencyInfo");

            migrationBuilder.DropColumn(
                name: "BanknoteSelling",
                table: "CurrencyInfo");

            migrationBuilder.DropColumn(
                name: "ForexBuying",
                table: "CurrencyInfo");

            migrationBuilder.RenameColumn(
                name: "ForexSelling",
                table: "CurrencyInfo",
                newName: "CurrentRate");
        }
    }
}
