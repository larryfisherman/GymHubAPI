using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class recipeingrediensandsteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngrediens_Recipes_RecipeId",
                table: "RecipeIngrediens");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "WorkoutsExercises");

            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeSteps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeIngrediens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngrediens_Recipes_RecipeId",
                table: "RecipeIngrediens",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngrediens_Recipes_RecipeId",
                table: "RecipeIngrediens");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "WorkoutsExercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeSteps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFile",
                table: "Recipes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeIngrediens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngrediens_Recipes_RecipeId",
                table: "RecipeIngrediens",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
