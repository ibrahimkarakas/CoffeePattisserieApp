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
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PreparationMethod = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "real", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    FlavorProfile = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
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
                name: "MoctailCategories",
                columns: table => new
                {
                    MoctailId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoctailCategories", x => new { x.MoctailId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MoctailCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoctailCategories_Moctails_MoctailId",
                        column: x => x.MoctailId,
                        principalTable: "Moctails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Moctails",
                columns: new[] { "Id", "CreatedDate", "Description", "FlavorProfile", "Ingredients", "IsActive", "ModifiedDate", "Name", "PreparationMethod", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 21, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3342), "Refreshing non-alcoholic cocktail with mint and lime.", "Minty, Citrusy, Refreshing", "Mint leaves, Lime juice, Soda water, Sugar", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3348), "Virgin Mojito", "Muddle mint leaves with sugar and lime juice. Add soda water and ice.", 120m, 20 },
                    { 2, new DateTime(2024, 7, 26, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3352), "Tropical blend of pineapple and coconut.", "Tropical, Sweet, Creamy", "Pineapple juice, Coconut milk, Ice", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3353), "Pineapple Coconut Delight", "Blend all ingredients until smooth. Serve chilled.", 110m, 30 },
                    { 3, new DateTime(2024, 7, 28, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3356), "A sweet and tangy blend of mixed berries.", "Fruity, Tangy, Refreshing", "Strawberries, Blueberries, Raspberries, Lemon juice, Soda water", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3356), "Berry Blast", "Blend berries with lemon juice. Top with soda water and serve over ice.", 135m, 25 },
                    { 4, new DateTime(2024, 7, 24, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3358), "Sparkling mango drink with a hint of lime.", "Mango, Citrusy, Sparkling", "Mango puree, Lime juice, Sparkling water", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3359), "Mango Fizz", "Mix mango puree and lime juice. Add sparkling water and serve over ice.", 135m, 35 },
                    { 5, new DateTime(2024, 7, 18, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3361), "Cool and refreshing cucumber drink with mint.", "Fresh, Minty, Light", "Cucumber, Mint leaves, Lemon juice, Soda water", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3361), "Cucumber Cooler", "Blend cucumber and mint. Add lemon juice and soda water. Serve chilled.", 125m, 40 },
                    { 6, new DateTime(2024, 7, 16, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3363), "A vibrant blend of orange and grenadine.", "Citrusy, Sweet, Vibrant", "Orange juice, Grenadine syrup, Ice", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(3364), "Orange Sunset", "Mix orange juice and grenadine. Serve over ice for a layered effect.", 120m, 50 }
                });

            migrationBuilder.InsertData(
                table: "PattisserieProducts",
                columns: new[] { "Id", "Allergens", "CreatedDate", "Description", "Ingredients", "IsActive", "ModifiedDate", "Name", "Price", "ShelfLife", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Dairy, Nuts, Gluten", new DateTime(2024, 7, 21, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6474), "Traditional French dessert made with choux pastry and praline-flavored cream.", "Choux pastry, Praline cream, Almonds", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6478), "Paris Brest", 155m, "2 days in refrigerator", 20 },
                    { 2, "Dairy, Gluten, Eggs", new DateTime(2024, 7, 26, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6486), "Classic Italian dessert with coffee-soaked ladyfingers and mascarpone cheese.", "Ladyfingers, Mascarpone cheese, Coffee, Cocoa", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6486), "Tiramisu", 145m, "3 days refrigerated", 30 },
                    { 3, "Nuts, Gluten", new DateTime(2024, 7, 31, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6491), "Traditional Turkish dessert made with layers of filo pastry, nuts, and honey syrup.", "Filo pastry, Walnuts, Honey syrup", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6491), "Baklava", 700m, "5 days", 50 },
                    { 4, "Dairy, Gluten", new DateTime(2024, 7, 16, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6495), "Rich dessert with a cream cheese filling on a graham cracker crust.", "Cream cheese, Graham crackers, Sugar", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6496), "Cheesecake", 150m, "5 days refrigerated", 40 },
                    { 5, "Dairy, Gluten, Eggs", new DateTime(2024, 7, 26, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6498), "Long French pastry made with choux dough filled with cream and topped with icing.", "Choux pastry, Chocolate icing, Pastry cream", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6499), "Éclair", 80m, "1 day", 50 },
                    { 6, "Gluten, Dairy", new DateTime(2024, 7, 29, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6501), "Light, flaky pastry with a variety of sweet fillings.", "Flour, Butter, Sugar, Fruit filling", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(6501), "Danish Pastry", 140m, "2 days", 60 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CaffeineContent", "CategoryId", "CreatedDate", "FlavorNotes", "IsActive", "ModifiedDate", "Name", "OriginCountry", "Price", "RoastLevel", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 120, 0, new DateTime(2024, 7, 26, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(16), "Floral, Citrus", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(15), "Ethiopian Yirgacheffe", "Ethiopia", 350m, "Light", 45 },
                    { 2, 110, 0, new DateTime(2024, 7, 14, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(26), "Nutty, Chocolate", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(25), "Colombian Supremo", "Colombia", 299m, "Medium", 100 },
                    { 3, 100, 0, new DateTime(2024, 7, 31, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(29), "Earthy, Herbal", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(28), "Sumatra Mandheling", "Indonesia", 499m, "Dark", 30 },
                    { 4, 115, 0, new DateTime(2024, 7, 26, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(31), "Sweet, Nutty", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(31), "Brazil Santos", "Brazil", 250m, "Medium", 120 },
                    { 5, 105, 0, new DateTime(2024, 7, 6, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(34), "Smooth, Sweet, Mild", true, new DateTime(2024, 8, 5, 16, 51, 9, 915, DateTimeKind.Local).AddTicks(33), "Jamaican Blue Mountain", "Jamaica", 899m, "Light", 10 }
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
                table: "MoctailCategories",
                columns: new[] { "CategoryId", "MoctailId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 4, 4 },
                    { 3, 5 },
                    { 5, 6 }
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
                name: "IX_MoctailCategories_CategoryId",
                table: "MoctailCategories",
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
                name: "MoctailCategories");

            migrationBuilder.DropTable(
                name: "PattisserieCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Moctails");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PattisserieProducts");
        }
    }
}
