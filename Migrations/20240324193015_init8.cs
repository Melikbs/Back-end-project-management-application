using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collab_API.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TeamUsers_TeamUsersId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_TeamUsers_TeamUsersId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_TeamUsersId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamUsersId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamUsersId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TeamUsersId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamUsersId",
                table: "Team",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamUsersId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamUsersId",
                table: "Team",
                column: "TeamUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamUsersId",
                table: "AspNetUsers",
                column: "TeamUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TeamUsers_TeamUsersId",
                table: "AspNetUsers",
                column: "TeamUsersId",
                principalTable: "TeamUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_TeamUsers_TeamUsersId",
                table: "Team",
                column: "TeamUsersId",
                principalTable: "TeamUsers",
                principalColumn: "Id");
        }
    }
}
