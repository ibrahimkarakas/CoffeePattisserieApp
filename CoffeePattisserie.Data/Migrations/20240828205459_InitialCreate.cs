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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coffees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OriginCountry = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    RoastLevel = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FlavorNotes = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CaffeineContent = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moctails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Ingredients = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    PreparationMethod = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    FlavorProfile = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moctails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pattisseries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Allergens = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    ShelfLife = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pattisseries", x => x.Id);
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
                        name: "FK_CoffeeCategories_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductType = table.Column<string>(type: "TEXT", nullable: true),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CoffeeId = table.Column<int>(type: "INTEGER", nullable: true),
                    MoctailId = table.Column<int>(type: "INTEGER", nullable: true),
                    PattisserieId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Moctails_MoctailId",
                        column: x => x.MoctailId,
                        principalTable: "Moctails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Pattisseries_PattisserieId",
                        column: x => x.PattisserieId,
                        principalTable: "Pattisseries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductType = table.Column<string>(type: "TEXT", nullable: true),
                    CoffeeId = table.Column<int>(type: "INTEGER", nullable: true),
                    MoctailId = table.Column<int>(type: "INTEGER", nullable: true),
                    PattisserieId = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Moctails_MoctailId",
                        column: x => x.MoctailId,
                        principalTable: "Moctails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Pattisseries_PattisserieId",
                        column: x => x.PattisserieId,
                        principalTable: "Pattisseries",
                        principalColumn: "Id");
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
                        name: "FK_PattisserieCategories_Pattisseries_PattisserieId",
                        column: x => x.PattisserieId,
                        principalTable: "Pattisseries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsHome", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 28, 23, 54, 59, 227, DateTimeKind.Local).AddTicks(6962), "Various types of coffee", true, true, new DateTime(2024, 8, 28, 23, 54, 59, 227, DateTimeKind.Local).AddTicks(6974), "Coffee" },
                    { 2, new DateTime(2024, 8, 28, 23, 54, 59, 227, DateTimeKind.Local).AddTicks(6976), "Various types of moctails", true, true, new DateTime(2024, 8, 28, 23, 54, 59, 227, DateTimeKind.Local).AddTicks(6976), "Moctail" },
                    { 3, new DateTime(2024, 8, 28, 23, 54, 59, 227, DateTimeKind.Local).AddTicks(6978), "Various types of pattisseries", true, true, new DateTime(2024, 8, 28, 23, 54, 59, 227, DateTimeKind.Local).AddTicks(6978), "Pattisserie" }
                });

            migrationBuilder.InsertData(
                table: "Coffees",
                columns: new[] { "Id", "CaffeineContent", "CategoryId", "CreatedDate", "FlavorNotes", "ImageUrl", "IsActive", "IsHome", "ModifiedDate", "Name", "OriginCountry", "Price", "RoastLevel", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 120, 1, new DateTime(2024, 8, 18, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(907), "Floral, Citrus", "ethiopian-yirgacheffe.jpg", true, true, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(906), "Ethiopian Yirgacheffe", "Ethiopia", 120m, "Light", 45 },
                    { 2, 110, 2, new DateTime(2024, 8, 6, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(917), "Nutty, Chocolate", "colombian-supremo.jpg", true, false, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(916), "Colombian Supremo", "Colombia", 125m, "Medium", 100 },
                    { 3, 100, 3, new DateTime(2024, 8, 23, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(920), "Earthy, Herbal", "sumatra-mandheling.jpg", true, true, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(919), "Sumatra Mandheling", "Indonesia", 130m, "Dark", 30 },
                    { 4, 115, 4, new DateTime(2024, 8, 18, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(923), "Sweet, Nutty", "brazil-santos.jpg", true, false, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(922), "Brazil Santos", "Brazil", 135m, "Medium", 120 },
                    { 5, 105, 1, new DateTime(2024, 7, 29, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(925), "Smooth, Sweet, Mild", "jamaican-blue-mountain.jpg", true, true, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(925), "Jamaican Blue Mountain", "Jamaica", 140m, "Light", 10 },
                    { 6, 110, 2, new DateTime(2024, 8, 13, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(961), "Fruity, Winey", "kenyan-aa.jpg", true, false, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(961), "Kenyan AA", "Kenya", 145m, "Medium", 50 },
                    { 7, 115, 3, new DateTime(2024, 8, 8, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(964), "Citrus, Chocolate", "costa-rican-tarrazu.jpg", true, true, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(963), "Costa Rican Tarrazu", "Costa Rica", 125m, "Light", 35 },
                    { 8, 105, 4, new DateTime(2024, 8, 3, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(967), "Spicy, Smoky", "guatemalan-antigua.jpg", true, false, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(966), "Guatemalan Antigua", "Guatemala", 150m, "Medium", 20 },
                    { 9, 100, 1, new DateTime(2024, 8, 10, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(969), "Nutty, Caramel", "mexican-altura.jpg", true, true, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(969), "Mexican Altura", "Mexico", 140m, "Light", 60 },
                    { 10, 110, 2, new DateTime(2024, 8, 16, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(972), "Rich, Buttery", "hawaiian-kona.jpg", true, false, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(971), "Hawaiian Kona", "Hawaii", 130m, "Medium", 15 },
                    { 11, 105, 3, new DateTime(2024, 8, 20, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(974), "Chocolate, Spicy", "yemen-mocha.jpg", true, true, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(974), "Yemen Mocha", "Yemen", 125m, "Dark", 25 },
                    { 12, 115, 4, new DateTime(2024, 8, 22, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(977), "Sweet, Floral", "ecuador-vilcabamba.jpg", true, false, new DateTime(2024, 8, 28, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(977), "Ecuador Vilcabamba", "Ecuador", 140m, "Light", 20 }
                });

            migrationBuilder.InsertData(
                table: "Moctails",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "FlavorProfile", "ImageUrl", "Ingredients", "IsActive", "IsHome", "ModifiedDate", "Name", "PreparationMethod", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 18, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4366), "A refreshing mint and lime drink.", "Minty, Citrusy", "virgin-mojito.jpg", "Mint, Lime, Soda Water, Sugar", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Mojito", "Muddle mint leaves and lime wedges, add sugar and soda water.", 140m, 50 },
                    { 2, 1, new DateTime(2024, 8, 19, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4375), "A sweet and fizzy drink with grenadine.", "Sweet, Fizzy", "shirley-temple.jpg", "Ginger Ale, Grenadine, Maraschino Cherry", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shirley Temple", "Mix ginger ale with grenadine and top with a cherry.", 125m, 60 },
                    { 3, 2, new DateTime(2024, 8, 20, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4378), "A tropical blend of pineapple and coconut.", "Tropical, Creamy", "pina-colada.jpg", "Pineapple Juice, Coconut Cream, Ice", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pina Colada", "Blend pineapple juice and coconut cream with ice.", 150m, 40 },
                    { 4, 2, new DateTime(2024, 8, 21, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4380), "A fruity drink with orange, pineapple, and lemon.", "Fruity, Tangy", "cinderella.jpg", "Orange Juice, Pineapple Juice, Lemon Juice, Grenadine", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cinderella", "Shake all ingredients with ice and strain into a glass.", 130m, 70 },
                    { 5, 1, new DateTime(2024, 8, 22, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4383), "A vibrant mix of orange and grenadine.", "Citrusy, Sweet", "sunrise.jpg", "Orange Juice, Grenadine, Ice", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunrise", "Pour orange juice over ice and drizzle with grenadine.", 145m, 55 },
                    { 6, 3, new DateTime(2024, 8, 23, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4385), "A delightful mix of various fruit juices.", "Fruity, Refreshing", "fruit-punch.jpg", "Orange Juice, Pineapple Juice, Cranberry Juice, Lemon Juice", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fruit Punch", "Mix all juices together and serve over ice.", 120m, 65 },
                    { 7, 3, new DateTime(2024, 8, 24, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4387), "A non-alcoholic version of the classic Bloody Mary.", "Savory, Spicy", "virgin-mary.jpg", "Tomato Juice, Lemon Juice, Worcestershire Sauce, Tabasco", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Mary", "Mix all ingredients together and serve over ice.", 135m, 45 },
                    { 8, 3, new DateTime(2024, 8, 25, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4389), "A refreshing mix of various berries.", "Berry, Tangy", "berry-cooler.jpg", "Strawberries, Blueberries, Raspberries, Lemonade", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berry Cooler", "Blend all ingredients with ice.", 125m, 50 },
                    { 9, 1, new DateTime(2024, 8, 26, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4391), "A refreshing lemonade with a hint of mint.", "Minty, Citrusy", "mint-lemonade.jpg", "Lemon Juice, Mint Leaves, Sugar, Water", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mint Lemonade", "Mix lemon juice and sugar with water and add mint leaves.", 130m, 70 },
                    { 10, 2, new DateTime(2024, 8, 27, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4393), "A fizzy drink with tropical flavors.", "Tropical, Fizzy", "tropical-fizz.jpg", "Pineapple Juice, Orange Juice, Soda Water", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tropical Fizz", "Mix pineapple juice and orange juice with soda water.", 140m, 55 },
                    { 11, 1, new DateTime(2024, 8, 16, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4396), "A zesty mix of lemon and ginger ale.", "Zesty, Fizzy", "lemon-ginger-ale.jpg", "Lemon Juice, Ginger Ale, Sugar", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lemon Ginger Ale", "Mix lemon juice with ginger ale and add sugar.", 120m, 60 },
                    { 12, 2, new DateTime(2024, 8, 17, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4398), "A vibrant blue drink with a tropical taste.", "Tropical, Sweet", "blue-lagoon.jpg", "Blue Curacao Syrup, Lemonade, Ice", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue Lagoon", "Mix blue curacao syrup with lemonade and serve over ice.", 145m, 55 },
                    { 13, 3, new DateTime(2024, 8, 18, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4400), "A refreshing iced tea with a hint of peach.", "Peachy, Refreshing", "peach-iced-tea.jpg", "Peach Syrup, Black Tea, Ice", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peach Iced Tea", "Mix peach syrup with black tea and serve over ice.", 135m, 60 },
                    { 14, 2, new DateTime(2024, 8, 19, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(4402), "A tropical twist on the classic Moscow Mule.", "Tropical, Spicy", "mango-mule.jpg", "Mango Juice, Ginger Beer, Lime Juice, Ice", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mango Mule", "Mix mango juice and lime juice with ginger beer and serve over ice.", 140m, 50 }
                });

            migrationBuilder.InsertData(
                table: "Pattisseries",
                columns: new[] { "Id", "Allergens", "CategoryId", "CreatedDate", "Description", "ImageUrl", "Ingredients", "IsActive", "IsHome", "ModifiedDate", "Name", "Price", "ShelfLife", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Eggs, Milk, Gluten", 1, new DateTime(2024, 8, 18, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7695), "A rich and moist chocolate cake.", "chocolate-cake.jpg", "Flour, Sugar, Cocoa, Baking Powder, Eggs, Milk", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chocolate Cake", 120m, "3 days", 30 },
                    { 2, "Eggs, Milk, Gluten", 1, new DateTime(2024, 8, 19, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7705), "A fluffy vanilla cupcake with buttercream frosting.", "vanilla-cupcake.jpg", "Flour, Sugar, Butter, Eggs, Vanilla Extract", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanilla Cupcake", 125m, "2 days", 40 },
                    { 3, "Milk, Gluten", 2, new DateTime(2024, 8, 20, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7709), "A tart filled with fresh strawberries and cream.", "strawberry-tart.jpg", "Flour, Sugar, Butter, Strawberries, Cream", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strawberry Tart", 130m, "1 day", 25 },
                    { 4, "Eggs, Milk, Gluten", 2, new DateTime(2024, 8, 21, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7711), "A tart lemon pie with a fluffy meringue topping.", "lemon-meringue-pie.jpg", "Flour, Sugar, Eggs, Lemons, Butter", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lemon Meringue Pie", 145m, "2 days", 20 },
                    { 5, "Eggs, Milk, Gluten", 3, new DateTime(2024, 8, 22, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7713), "A moist muffin packed with fresh blueberries.", "blueberry-muffin.jpg", "Flour, Sugar, Blueberries, Eggs, Milk", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blueberry Muffin", 135m, "3 days", 35 },
                    { 6, "Eggs, Milk, Gluten", 3, new DateTime(2024, 8, 23, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7715), "A creamy cheesecake with a raspberry swirl.", "raspberry-cheesecake.jpg", "Cream Cheese, Sugar, Eggs, Raspberries, Graham Cracker Crust", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raspberry Cheesecake", 140m, "5 days", 15 },
                    { 7, "Eggs, Milk, Gluten", 1, new DateTime(2024, 8, 24, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7717), "A classic cookie loaded with chocolate chips.", "chocolate-chip-cookie.jpg", "Flour, Sugar, Butter, Eggs, Chocolate Chips", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chocolate Chip Cookie", 120m, "5 days", 50 },
                    { 8, "Eggs, Nuts", 2, new DateTime(2024, 8, 25, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7719), "A delicate French pastry with a creamy filling.", "macaron.jpg", "Almond Flour, Sugar, Egg Whites, Food Coloring", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macaron", 150m, "1 week", 45 },
                    { 9, "Milk, Gluten", 1, new DateTime(2024, 8, 26, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7721), "A buttery, flaky pastry.", "croissant.jpg", "Flour, Butter, Sugar, Yeast, Salt", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Croissant", 125m, "2 days", 30 },
                    { 10, "Eggs, Milk, Gluten", 2, new DateTime(2024, 8, 27, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7723), "A spiced pumpkin pie with a flaky crust.", "pumpkin-pie.jpg", "Pumpkin, Sugar, Eggs, Cream, Spices, Flour", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pumpkin Pie", 140m, "3 days", 20 },
                    { 11, "Eggs, Milk, Gluten", 3, new DateTime(2024, 8, 16, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7726), "A classic red velvet cake with cream cheese frosting.", "red-velvet-cake.jpg", "Flour, Sugar, Cocoa, Buttermilk, Eggs, Red Food Coloring", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Velvet Cake", 135m, "3 days", 30 },
                    { 12, "Eggs, Milk, Gluten", 2, new DateTime(2024, 8, 17, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7729), "A moist bread made with ripe bananas.", "banana-bread.jpg", "Flour, Sugar, Bananas, Eggs, Butter", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banana Bread", 130m, "1 week", 25 },
                    { 13, "Milk, Gluten", 3, new DateTime(2024, 8, 18, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7731), "A classic pie filled with spiced apples.", "apple-pie.jpg", "Apples, Sugar, Flour, Butter, Cinnamon", true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple Pie", 145m, "3 days", 20 },
                    { 14, "Eggs, Milk, Gluten", 1, new DateTime(2024, 8, 19, 23, 54, 59, 228, DateTimeKind.Local).AddTicks(7733), "A choux pastry filled with cream and topped with chocolate.", "chocolate-eclair.jpg", "Flour, Eggs, Butter, Cream, Chocolate", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chocolate Eclair", 125m, "2 days", 15 }
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
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CoffeeId",
                table: "CartItems",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_MoctailId",
                table: "CartItems",
                column: "MoctailId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PattisserieId",
                table: "CartItems",
                column: "PattisserieId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCategories_CategoryId",
                table: "CoffeeCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MoctailCategories_CategoryId",
                table: "MoctailCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CoffeeId",
                table: "OrderItems",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MoctailId",
                table: "OrderItems",
                column: "MoctailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PattisserieId",
                table: "OrderItems",
                column: "PattisserieId");

            migrationBuilder.CreateIndex(
                name: "IX_PattisserieCategories_CategoryId",
                table: "PattisserieCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CoffeeCategories");

            migrationBuilder.DropTable(
                name: "MoctailCategories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PattisserieCategories");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Coffees");

            migrationBuilder.DropTable(
                name: "Moctails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Pattisseries");
        }
    }
}
