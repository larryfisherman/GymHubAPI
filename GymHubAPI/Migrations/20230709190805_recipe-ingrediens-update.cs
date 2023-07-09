using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class recipeingrediensupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingrediens_Recipes_RecipeId",
                table: "Ingrediens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingrediens",
                table: "Ingrediens");

            migrationBuilder.RenameTable(
                name: "Ingrediens",
                newName: "RecipeIngrediens");

            migrationBuilder.RenameIndex(
                name: "IX_Ingrediens_RecipeId",
                table: "RecipeIngrediens",
                newName: "IX_RecipeIngrediens_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeIngrediens",
                table: "RecipeIngrediens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngrediens_Recipes_RecipeId",
                table: "RecipeIngrediens",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngrediens_Recipes_RecipeId",
                table: "RecipeIngrediens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeIngrediens",
                table: "RecipeIngrediens");

            migrationBuilder.RenameTable(
                name: "RecipeIngrediens",
                newName: "Ingrediens");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngrediens_RecipeId",
                table: "Ingrediens",
                newName: "IX_Ingrediens_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingrediens",
                table: "Ingrediens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingrediens_Recipes_RecipeId",
                table: "Ingrediens",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
