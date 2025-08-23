﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_store.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UrunAdı = table.Column<string>(type: "TEXT", nullable: true),
                    Fiyat = table.Column<double>(type: "REAL", nullable: false),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "Id", "Aktif", "Fiyat", "UrunAdı" },
                values: new object[,]
                {
                    { 1, true, 10000.0, "Apple 7" },
                    { 2, false, 20000.0, "Apple 8" },
                    { 3, true, 30000.0, "Apple 9" },
                    { 4, true, 40000.0, "Apple 10" },
                    { 5, false, 50000.0, "Apple 11" },
                    { 6, true, 60000.0, "Apple 12" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urunler");
        }
    }
}
