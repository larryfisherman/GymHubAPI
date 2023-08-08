using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class recipesteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "RecipeSteps");

            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "RecipeSteps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    StepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.StepId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_StepId",
                table: "RecipeSteps",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Step_StepId",
                table: "RecipeSteps",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Step_StepId",
                table: "RecipeSteps");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropIndex(
                name: "IX_RecipeSteps_StepId",
                table: "RecipeSteps");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "RecipeSteps");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "RecipeSteps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
