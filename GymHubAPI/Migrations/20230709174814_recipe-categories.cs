using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class recipecategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFile",
                table: "Recipes",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "All dishes" },
                    { 2, "Meat dishes" },
                    { 3, "Salads" },
                    { 4, "Seafood" },
                    { 5, "Soups" },
                    { 6, "Desserts" }
                });
        }
    }
}
