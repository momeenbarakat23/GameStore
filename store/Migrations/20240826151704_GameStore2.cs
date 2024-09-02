using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.Migrations
{
    /// <inheritdoc />
    public partial class GameStore2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageBar1",
                table: "GameStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageBar2",
                table: "GameStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageBar3",
                table: "GameStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageBar4",
                table: "GameStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageBar5",
                table: "GameStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageBar6",
                table: "GameStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBar1",
                table: "GameStores");

            migrationBuilder.DropColumn(
                name: "ImageBar2",
                table: "GameStores");

            migrationBuilder.DropColumn(
                name: "ImageBar3",
                table: "GameStores");

            migrationBuilder.DropColumn(
                name: "ImageBar4",
                table: "GameStores");

            migrationBuilder.DropColumn(
                name: "ImageBar5",
                table: "GameStores");

            migrationBuilder.DropColumn(
                name: "ImageBar6",
                table: "GameStores");
        }
    }
}
