using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class recipecategoriesupdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Recipes_RecipeId",
                table: "RecipeCategories");

            migrationBuilder.DropIndex(
                name: "IX_RecipeCategories_RecipeId",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RecipeCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "RecipeCategories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "RecipeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_RecipeId",
                table: "RecipeCategories",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Recipes_RecipeId",
                table: "RecipeCategories",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
