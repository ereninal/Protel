using Microsoft.EntityFrameworkCore.Migrations;

namespace Protel.DataAccess.Migrations
{
    public partial class CurrencyTypeTableUpdates2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyInfo_Currencies_CurrencyTypeId1",
                table: "CurrencyInfo");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyInfo_CurrencyTypeId1",
                table: "CurrencyInfo");

            migrationBuilder.DropColumn(
                name: "CurrencyTypeId1",
                table: "CurrencyInfo");

            migrationBuilder.AlterColumn<long>(
                name: "CurrencyTypeId",
                table: "CurrencyInfo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyInfo_CurrencyTypeId",
                table: "CurrencyInfo",
                column: "CurrencyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyInfo_Currencies_CurrencyTypeId",
                table: "CurrencyInfo",
                column: "CurrencyTypeId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyInfo_Currencies_CurrencyTypeId",
                table: "CurrencyInfo");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyInfo_CurrencyTypeId",
                table: "CurrencyInfo");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyTypeId",
                table: "CurrencyInfo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "CurrencyTypeId1",
                table: "CurrencyInfo",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyInfo_CurrencyTypeId1",
                table: "CurrencyInfo",
                column: "CurrencyTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyInfo_Currencies_CurrencyTypeId1",
                table: "CurrencyInfo",
                column: "CurrencyTypeId1",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
