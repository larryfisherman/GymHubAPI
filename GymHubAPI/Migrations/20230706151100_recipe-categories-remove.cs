using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class recipecategoriesremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                columns: new[] { "Id", "Active", "RecipeId", "Title" },
                values: new object[,]
                {
                    { 1, false, null, "Breakfast" },
                    { 2, false, null, "Lunch" },
                    { 3, false, null, "Dinner" },
                    { 4, false, null, "Saper" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_RecipeId",
                table: "RecipeCategories",
                column: "RecipeId");
        }
    }
}
