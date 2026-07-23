using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NoBeard.Learn.AspNet.MvcApp.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PetShops",
                columns: new[] { "Id", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "123 Main St", null, "Happy Paws" },
                    { 2, "456 Elm St", null, "Furry Friends" }
                });

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Dog" },
                    { 2, null, "Cat" },
                    { 3, null, "Bird" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetShops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetShops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
