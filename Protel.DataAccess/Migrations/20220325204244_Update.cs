using Microsoft.EntityFrameworkCore.Migrations;

namespace Protel.DataAccess.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyChangeInfos_Currencies_CurrencyTypeId1",
                table: "CurrencyChangeInfos");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyChangeInfos_CurrencyTypeId1",
                table: "CurrencyChangeInfos");

            migrationBuilder.DropColumn(
                name: "CurrencyTypeId1",
                table: "CurrencyChangeInfos");

            migrationBuilder.AlterColumn<long>(
                name: "CurrencyTypeId",
                table: "CurrencyChangeInfos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Change",
                table: "CurrencyChangeInfos",
                type: "text",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyChangeInfos_CurrencyTypeId",
                table: "CurrencyChangeInfos",
                column: "CurrencyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyChangeInfos_Currencies_CurrencyTypeId",
                table: "CurrencyChangeInfos",
                column: "CurrencyTypeId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyChangeInfos_Currencies_CurrencyTypeId",
                table: "CurrencyChangeInfos");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyChangeInfos_CurrencyTypeId",
                table: "CurrencyChangeInfos");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyTypeId",
                table: "CurrencyChangeInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "Change",
                table: "CurrencyChangeInfos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyTypeId1",
                table: "CurrencyChangeInfos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyChangeInfos_CurrencyTypeId1",
                table: "CurrencyChangeInfos",
                column: "CurrencyTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyChangeInfos_Currencies_CurrencyTypeId1",
                table: "CurrencyChangeInfos",
                column: "CurrencyTypeId1",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
