using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class recipecategoriesupdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "RecipeId", "Title" },
                values: new object[,]
                {
                    { 1, null, "All dishes" },
                    { 2, null, "Meat dishes" },
                    { 3, null, "Salads" },
                    { 4, null, "Seafood" },
                    { 5, null, "Soups" },
                    { 6, null, "Desserts" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_RecipeId",
                table: "RecipeCategories",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeCategories");
        }
    }
}
