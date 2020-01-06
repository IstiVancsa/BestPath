using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Repositories.Migrations
{
    public partial class AddedUserIdInCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "DestinationPoint",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MuseumType",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NeedsHotel",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NeedsMuseum",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NeedsRestaurant",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantType",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StartPoint",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
