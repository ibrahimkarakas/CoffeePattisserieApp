using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeePattisserie.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moctails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", nullable: false),
                    PreparationMethod = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    FlavorProfile = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moctails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PattisserieProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", nullable: false),
                    Allergens = table.Column<string>(type: "TEXT", nullable: false),
                    ShelfLife = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PattisserieProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "real", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OriginCountry = table.Column<string>(type: "TEXT", nullable: false),
                    RoastLevel = table.Column<string>(type: "TEXT", nullable: false),
                    FlavorNotes = table.Column<string>(type: "TEXT", nullable: false),
                    CaffeineContent = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeCategories",
                columns: table => new
                {
                    CoffeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeCategories", x => new { x.CoffeeId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CoffeeCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeCategories_Products_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kahve kategorisi", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coffees" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tatlı kategorisi", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deserts" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fırın kategorisi", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pattisserie" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toptan satış kategorisi", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wholesales" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CaffeineContent", "CategoryId", "CreatedDate", "FlavorNotes", "IsActive", "ModifiedDate", "Name", "OriginCountry", "Price", "RoastLevel", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 120, 0, new DateTime(2024, 7, 25, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6655), "Floral, Citrus", true, new DateTime(2024, 8, 4, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6654), "Ethiopian Yirgacheffe", "Ethiopia", 350m, "Light", 45 },
                    { 2, 110, 0, new DateTime(2024, 7, 13, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6664), "Nutty, Chocolate", true, new DateTime(2024, 8, 4, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6664), "Colombian Supremo", "Colombia", 299m, "Medium", 100 },
                    { 3, 100, 0, new DateTime(2024, 7, 30, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6667), "Earthy, Herbal", true, new DateTime(2024, 8, 4, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6667), "Sumatra Mandheling", "Indonesia", 499m, "Dark", 30 },
                    { 4, 115, 0, new DateTime(2024, 7, 25, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6670), "Sweet, Nutty", true, new DateTime(2024, 8, 4, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6669), "Brazil Santos", "Brazil", 250m, "Medium", 120 },
                    { 5, 105, 0, new DateTime(2024, 7, 5, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6672), "Smooth, Sweet, Mild", true, new DateTime(2024, 8, 4, 23, 59, 30, 251, DateTimeKind.Local).AddTicks(6671), "Jamaican Blue Mountain", "Jamaica", 899m, "Light", 10 }
                });

            migrationBuilder.InsertData(
                table: "CoffeeCategories",
                columns: new[] { "CategoryId", "CoffeeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 2, 5 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCategories_CategoryId",
                table: "CoffeeCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeCategories");

            migrationBuilder.DropTable(
                name: "Moctails");

            migrationBuilder.DropTable(
                name: "PattisserieProducts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
