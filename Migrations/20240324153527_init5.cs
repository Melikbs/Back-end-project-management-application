using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collab_API.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_project_projectAssignedId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_projectAssignedId",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "projectAssignedId",
                table: "Team",
                newName: "projectAssigned");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "projectAssigned",
                table: "Team",
                newName: "projectAssignedId");

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
    }
}
