using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment5.Migrations
{
    /// <inheritdoc />
    public partial class CreatePODb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItDesc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ItRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItCode);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierNo);
                });

            migrationBuilder.CreateTable(
                name: "POMasters",
                columns: table => new
                {
                    PONo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PODate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SupplierNo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POMasters", x => x.PONo);
                    table.ForeignKey(
                        name: "FK_POMasters_Items_ItCode",
                        column: x => x.ItCode,
                        principalTable: "Items",
                        principalColumn: "ItCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POMasters_Suppliers_SupplierNo",
                        column: x => x.SupplierNo,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_POMasters_ItCode",
                table: "POMasters",
                column: "ItCode");

            migrationBuilder.CreateIndex(
                name: "IX_POMasters_SupplierNo",
                table: "POMasters",
                column: "SupplierNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POMasters");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
