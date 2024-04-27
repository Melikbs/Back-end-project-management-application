using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collab_API.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "member",
                table: "Team");

            migrationBuilder.AddColumn<int>(
                name: "TeamUsersId",
                table: "Team",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "memberId",
                table: "Team",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamUsersId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_memberId",
                table: "Team",
                column: "memberId");

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
                name: "FK_Team_AspNetUsers_memberId",
                table: "Team",
                column: "memberId",
                principalTable: "AspNetUsers",
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
                name: "FK_Team_AspNetUsers_memberId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_TeamUsers_TeamUsersId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "TeamUsers");

            migrationBuilder.DropIndex(
                name: "IX_Team_memberId",
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
                name: "memberId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TeamUsersId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "member",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
