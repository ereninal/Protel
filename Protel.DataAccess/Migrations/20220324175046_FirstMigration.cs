using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Protel.DataAccess.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyChangeInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrencyTypeId = table.Column<int>(type: "integer", nullable: false),
                    CurrentRate = table.Column<decimal>(type: "numeric", nullable: false),
                    Change = table.Column<double>(type: "double precision", nullable: false),
                    CurrencyTypeId1 = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyChangeInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyChangeInfos_Currencies_CurrencyTypeId1",
                        column: x => x.CurrencyTypeId1,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrencyTypeId = table.Column<int>(type: "integer", nullable: false),
                    CurrentRate = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyTypeId1 = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyInfo_Currencies_CurrencyTypeId1",
                        column: x => x.CurrencyTypeId1,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyChangeInfos_CurrencyTypeId1",
                table: "CurrencyChangeInfos",
                column: "CurrencyTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyInfo_CurrencyTypeId1",
                table: "CurrencyInfo",
                column: "CurrencyTypeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyChangeInfos");

            migrationBuilder.DropTable(
                name: "CurrencyInfo");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
