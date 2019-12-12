using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class BestPathDBModifiedDBSET : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Token = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReviewComment = table.Column<string>(maxLength: 300, nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 40, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 40, nullable: false),
                    ReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "Password", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("42001e55-c6ec-4b56-8008-0d5930895867"), 0, "456", new Guid("585b28b1-1713-4716-9c7a-81e3e0094ac2"), "Balmy" },
                    { new Guid("7e665add-6dda-4e36-b813-ecbd534dfffa"), 0, "234", new Guid("5609c777-70dd-40d2-b21d-3c213c666deb"), "Scorching" },
                    { new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"), 0, "567", new Guid("5664888b-3d93-4547-aee9-d487d973de68"), "Scorching" },
                    { new Guid("744b602b-e8a7-4083-ac81-6ed65eebb56a"), 0, "678", new Guid("e73bc12c-fa81-4812-9945-6fd8656c744e"), "Scorching" },
                    { new Guid("f463cd1e-42b9-412b-b294-5880080e0883"), 0, "567", new Guid("2c51b120-924a-4606-8d9a-e31b2c4e0f25"), "Bracing" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "ReviewComment", "Stars", "UserId" },
                values: new object[,]
                {
                    { new Guid("be868109-4a59-4040-8c6f-de7a55287223"), "College Bar este un loc aparte , nu am mai vazut bar ca acesta.Cu mancare foarte buna si bauturile deasemenea !", 4, new Guid("42001e55-c6ec-4b56-8008-0d5930895867") },
                    { new Guid("08fcdf3a-bdc2-40fe-8c09-262514fc0004"), "Perfect place for students but otherways it.s not that good", 5, new Guid("42001e55-c6ec-4b56-8008-0d5930895867") },
                    { new Guid("46accd10-32e6-4037-a606-734116594544"), "Perfect place for students but otherways it.s not that good", 1, new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6") },
                    { new Guid("883f770a-d75d-461a-8fa7-193a4f628f25"), "Perfect place for students but otherways it.s not that good", 4, new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6") },
                    { new Guid("5d282d4b-496e-4515-bb73-7f65eab84379"), "Burger făcut la rapid,ars pe o parte, pe cealaltă roz, în interior era între nefăcut și nefăcut :)  cartofii fără nici un gust. Sosul picant este excelent în schimb. Restul adus fără 10 lei. Am fost client fidel pe timpul anului, mergeam în fiecare zi,dar de ceva timp e cam bătaie de joc. Nu e frumos.", 4, new Guid("f463cd1e-42b9-412b-b294-5880080e0883") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");
        }
    }
}
