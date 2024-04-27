using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collab_API.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descriptionteam",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "member",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "projectAssignedId",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Team_projectAssignedId",
                table: "Team",
                column: "projectAssignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_project_projectAssignedId",
                table: "Team",
                column: "projectAssignedId",
                principalTable: "project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_project_projectAssignedId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_projectAssignedId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "descriptionteam",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "member",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "projectAssignedId",
                table: "Team");
        }
    }
}
