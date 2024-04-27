using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collab_API.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Objectif",
                table: "Sprint");

            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "Sprint",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "namesprint",
                table: "Sprint",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "startDate",
                table: "Sprint",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Sprint",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endDate",
                table: "Sprint");

            migrationBuilder.DropColumn(
                name: "namesprint",
                table: "Sprint");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "Sprint");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Sprint");

            migrationBuilder.AddColumn<string>(
                name: "Objectif",
                table: "Sprint",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
