using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class BestPathDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 40, nullable: false),
                    Token = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 40, nullable: false),
                    ReviewComment = table.Column<string>(nullable: true),
                    Stars = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
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
                columns: new[] { "Id", "Password", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("42001e55-c6ec-4b56-8008-0d5930895867"), "789", new Guid("160dcabf-94dc-42d4-90c1-018edbae7fe0"), "Balmy" },
                    { new Guid("7e665add-6dda-4e36-b813-ecbd534dfffa"), "678", new Guid("e3940a84-ccf5-4f7a-b8f9-fb81473de2d2"), "Bracing" },
                    { new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"), "234", new Guid("96220253-30ca-4b1d-8982-47a1b44dc75a"), "Bracing" },
                    { new Guid("744b602b-e8a7-4083-ac81-6ed65eebb56a"), "456", new Guid("21e36819-b3c1-427c-8e5b-b250c16106e0"), "Cool" },
                    { new Guid("f463cd1e-42b9-412b-b294-5880080e0883"), "456", new Guid("6af44d56-71b9-475c-b67c-ca375d22e518"), "Cool" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "ReviewComment", "Stars", "UserId" },
                values: new object[,]
                {
                    { new Guid("accc57e4-75c2-4557-b570-1865b8a53101"), "College Bar este un loc aparte , nu am mai vazut bar ca acesta.Cu mancare foarte buna si bauturile deasemenea !", 2, new Guid("42001e55-c6ec-4b56-8008-0d5930895867") },
                    { new Guid("5584714d-e32b-4376-8b3f-83e8efbbf83d"), "E aproape ca in vama..nu-i un loc pt printi și prințese :))", 4, new Guid("42001e55-c6ec-4b56-8008-0d5930895867") },
                    { new Guid("6507766f-b43a-4d9c-ae95-33b8dd6e7663"), "Locație bună, preturi ok, personal amabil. Big like", 4, new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6") },
                    { new Guid("38ebb74a-2cf1-4799-80e5-0fef88bcc639"), "O afacere studențească, fără un program clar și cu activități diverse. Personalul e binevoitor, dar fără experiență. Toată lumea face de toate...", 5, new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6") },
                    { new Guid("0d13a451-3aa8-4d17-9cd0-7dd21fd3ebb9"), "O afacere studențească, fără un program clar și cu activități diverse. Personalul e binevoitor, dar fără experiență. Toată lumea face de toate...", 5, new Guid("f463cd1e-42b9-412b-b294-5880080e0883") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
