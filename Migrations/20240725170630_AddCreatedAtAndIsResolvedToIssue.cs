using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmer_Issues.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtAndIsResolvedToIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_Farmers_FarmerId",
                table: "Farmers");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_FarmerId",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Farmers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Issues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "Issues",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "FarmerId",
                table: "Farmers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_FarmerId",
                table: "Farmers",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farmers_Farmers_FarmerId",
                table: "Farmers",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id");
        }
    }
}
