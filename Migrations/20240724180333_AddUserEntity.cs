using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmer_Issues.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmerId",
                table: "Farmers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_Farmers_FarmerId",
                table: "Farmers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_FarmerId",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Farmers");
        }
    }
}
