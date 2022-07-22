using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fastfood_order.Data.Migrations
{
    public partial class AddedHotdogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ExtraBalonesia",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExtraBeef",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExtraCheese",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExtraSausage",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExtraTurkey",
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
                name: "ExtraBalonesia",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExtraBeef",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExtraCheese",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExtraSausage",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExtraTurkey",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FranchHotDog",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MeatHotDog",
                table: "Users");
        }
    }
}
