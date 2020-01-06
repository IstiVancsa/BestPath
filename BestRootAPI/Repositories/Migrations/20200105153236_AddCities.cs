using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Repositories.Migrations
{
    public partial class AddCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    DestinationPoint = table.Column<bool>(nullable: false),
                    StartPoint = table.Column<bool>(nullable: false),
                    NeedsHotel = table.Column<bool>(nullable: false),
                    NeedsRestaurant = table.Column<bool>(nullable: false),
                    RestaurantType = table.Column<string>(nullable: true),
                    NeedsMuseum = table.Column<bool>(nullable: false),
                    MuseumType = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
