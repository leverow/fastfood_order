using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTg.Data.Migrations
{
    public partial class HotDogsAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orders",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "AmericanoHotDog",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassicHotDog",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoubleHotDog",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FranchHotDog",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeatHotDog",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmericanoHotDog",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClassicHotDog",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DoubleHotDog",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FranchHotDog",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MeatHotDog",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Orders",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }
    }
}
