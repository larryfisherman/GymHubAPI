using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class recipestepsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Steps_StepId",
                table: "RecipeSteps");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_RecipeSteps_StepId",
                table: "RecipeSteps");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "RecipeSteps");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "RecipeSteps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    StepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.StepId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_StepId",
                table: "RecipeSteps",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Steps_StepId",
                table: "RecipeSteps",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "StepId");
        }
    }
}
