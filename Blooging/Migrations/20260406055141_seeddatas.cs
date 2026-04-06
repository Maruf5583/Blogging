using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blooging.Migrations
{
    /// <inheritdoc />
    public partial class seeddatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Posts related to technology and gadgets.", "Technology" },
                    { 2, "Posts about travel experiences and tips.", "Travel" },
                    { 3, "Posts about recipes, restaurants, and food culture.", "Food" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "FeaturesImagePath", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Jhon Smith", 1, "Artificial Intelligence is rapidly evolving...", "img1.png", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Future of AI" },
                    { 2, "Jhon Smith", 2, "Looking for your next travel adventure...", "img2.png", new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Top 10 Travel Destinations for 2024" },
                    { 3, "Jhon Smith", 3, "Discover delicious vegan recipes...", "img3.png", new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delicious Vegan Recipes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
