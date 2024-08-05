using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeePattisserie.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "real", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Allergens = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ShelfLife = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
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
                name: "PattisserieCategories",
                columns: table => new
                {
                    PattisserieId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PattisserieCategories", x => new { x.PattisserieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PattisserieCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PattisserieCategories_PattisserieProducts_PattisserieId",
                        column: x => x.PattisserieId,
                        principalTable: "PattisserieProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "PattisserieProducts",
                columns: new[] { "Id", "Allergens", "CreatedDate", "Description", "Ingredients", "IsActive", "ModifiedDate", "Name", "Price", "ShelfLife", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Dairy, Nuts, Gluten", new DateTime(2024, 7, 21, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2565), "Traditional French dessert made with choux pastry and praline-flavored cream.", "Choux pastry, Praline cream, Almonds", true, new DateTime(2024, 8, 5, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2571), "Paris Brest", 155m, "2 days in refrigerator", 20 },
                    { 2, "Dairy, Gluten, Eggs", new DateTime(2024, 7, 26, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2578), "Classic Italian dessert with coffee-soaked ladyfingers and mascarpone cheese.", "Ladyfingers, Mascarpone cheese, Coffee, Cocoa", true, new DateTime(2024, 8, 5, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2579), "Tiramisu", 145m, "3 days refrigerated", 30 },
                    { 3, "Nuts, Gluten", new DateTime(2024, 7, 31, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2581), "Traditional Turkish dessert made with layers of filo pastry, nuts, and honey syrup.", "Filo pastry, Walnuts, Honey syrup", true, new DateTime(2024, 8, 5, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2582), "Baklava", 700m, "5 days", 50 },
                    { 4, "Dairy, Gluten", new DateTime(2024, 7, 16, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2584), "Rich dessert with a cream cheese filling on a graham cracker crust.", "Cream cheese, Graham crackers, Sugar", true, new DateTime(2024, 8, 5, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2585), "Cheesecake", 150m, "5 days refrigerated", 40 },
                    { 5, "Dairy, Gluten, Eggs", new DateTime(2024, 7, 26, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2587), "Long French pastry made with choux dough filled with cream and topped with icing.", "Choux pastry, Chocolate icing, Pastry cream", true, new DateTime(2024, 8, 5, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2588), "Éclair", 80m, "1 day", 50 },
                    { 6, "Gluten, Dairy", new DateTime(2024, 7, 29, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2590), "Light, flaky pastry with a variety of sweet fillings.", "Flour, Butter, Sugar, Fruit filling", true, new DateTime(2024, 8, 5, 11, 57, 0, 378, DateTimeKind.Local).AddTicks(2591), "Danish Pastry", 140m, "2 days", 60 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CaffeineContent", "CategoryId", "CreatedDate", "FlavorNotes", "IsActive", "ModifiedDate", "Name", "OriginCountry", "Price", "RoastLevel", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 120, 0, new DateTime(2024, 7, 26, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8279), "Floral, Citrus", true, new DateTime(2024, 8, 5, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8278), "Ethiopian Yirgacheffe", "Ethiopia", 350m, "Light", 45 },
                    { 2, 110, 0, new DateTime(2024, 7, 14, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8289), "Nutty, Chocolate", true, new DateTime(2024, 8, 5, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8288), "Colombian Supremo", "Colombia", 299m, "Medium", 100 },
                    { 3, 100, 0, new DateTime(2024, 7, 31, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8292), "Earthy, Herbal", true, new DateTime(2024, 8, 5, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8292), "Sumatra Mandheling", "Indonesia", 499m, "Dark", 30 },
                    { 4, 115, 0, new DateTime(2024, 7, 26, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8294), "Sweet, Nutty", true, new DateTime(2024, 8, 5, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8294), "Brazil Santos", "Brazil", 250m, "Medium", 120 },
                    { 5, 105, 0, new DateTime(2024, 7, 6, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8297), "Smooth, Sweet, Mild", true, new DateTime(2024, 8, 5, 11, 57, 0, 377, DateTimeKind.Local).AddTicks(8296), "Jamaican Blue Mountain", "Jamaica", 899m, "Light", 10 }
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

            migrationBuilder.InsertData(
                table: "PattisserieCategories",
                columns: new[] { "CategoryId", "PattisserieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 2, 5 },
                    { 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCategories_CategoryId",
                table: "CoffeeCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PattisserieCategories_CategoryId",
                table: "PattisserieCategories",
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
                name: "PattisserieCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PattisserieProducts");
        }
    }
}
