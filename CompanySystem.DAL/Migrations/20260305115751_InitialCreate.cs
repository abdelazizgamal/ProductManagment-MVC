using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanySystem.DAL.Migrations
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Electronics", null },
                    { 2, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Groceries", null },
                    { 3, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Home Appliances", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "CreatedAt", "Description", "ExpiryDate", "Image", "Price", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 8, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Ultra HD Smart TV with HDR and built-in streaming apps", null, null, 9500m, "Samsung 55\" 4K Smart TV", null },
                    { 2, 1, 15, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Wireless earbuds with noise cancellation", null, null, 7200m, "Apple AirPods Pro", null },
                    { 3, 2, 40, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Instant coffee made from premium roasted beans", new DateOnly(2027, 1, 10), null, 180m, "Nescafe Classic Coffee 200g", null },
                    { 4, 2, 50, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Fresh full-cream milk rich in calcium", new DateOnly(2026, 3, 20), null, 35m, "Almarai Fresh Milk 1L", null },
                    { 5, 3, 6, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Digital microwave oven with grill function", null, null, 4200m, "LG Microwave Oven 25L", null },
                    { 6, 3, 9, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Healthy air fryer with rapid air technology", null, null, 3900m, "Philips Air Fryer", null },
                    { 7, 2, 33, new DateTime(2026, 3, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Crunchy chocolate biscuits with cream filling", new DateOnly(2026, 9, 15), null, 12m, "Oreo Chocolate Biscuits", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
