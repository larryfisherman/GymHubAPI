using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class recipecategoriesupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Recipes");

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Active", "RecipeId", "Title" },
                values: new object[,]
                {
                    { 1, false, null, "Breakfast" },
                    { 2, false, null, "Lunch" },
                    { 3, false, null, "Dinner" },
                    { 4, false, null, "Saper" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
