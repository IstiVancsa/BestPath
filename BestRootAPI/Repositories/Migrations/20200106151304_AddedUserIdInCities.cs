using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Repositories.Migrations
{
    public partial class AddedUserIdInCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Cities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "DestinationPoint",
                table: "Cities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MuseumType",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NeedsHotel",
                table: "Cities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NeedsMuseum",
                table: "Cities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NeedsRestaurant",
                table: "Cities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantType",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StartPoint",
                table: "Cities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Cities",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DestinationPoint",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "MuseumType",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "NeedsHotel",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "NeedsMuseum",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "NeedsRestaurant",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "RestaurantType",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StartPoint",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cities");
        }
    }
}
