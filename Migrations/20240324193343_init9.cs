using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collab_API.Migrations
{
    /// <inheritdoc />
    public partial class init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "TeamUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TeamUsers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "TeamUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TeamUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
