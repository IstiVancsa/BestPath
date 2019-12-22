using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class BestPathDBAddUserAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("0d13a451-3aa8-4d17-9cd0-7dd21fd3ebb9"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("38ebb74a-2cf1-4799-80e5-0fef88bcc639"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("5584714d-e32b-4376-8b3f-83e8efbbf83d"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("6507766f-b43a-4d9c-ae95-33b8dd6e7663"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("accc57e4-75c2-4557-b570-1865b8a53101"));

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "ReviewComment", "Stars", "UserId" },
                values: new object[,]
                {
                    { new Guid("776fefca-b609-4b51-bb6e-c6b90969a849"), "College Bar este un loc aparte , nu am mai vazut bar ca acesta.Cu mancare foarte buna si bauturile deasemenea !", 1, new Guid("42001e55-c6ec-4b56-8008-0d5930895867") },
                    { new Guid("d4e0beea-8835-4ff3-a498-e2798cb46c76"), "Locație bună, preturi ok, personal amabil. Big like", 5, new Guid("42001e55-c6ec-4b56-8008-0d5930895867") },
                    { new Guid("5dc4004d-e649-4524-a4c0-901de3f0924a"), "Burger făcut la rapid,ars pe o parte, pe cealaltă roz, în interior era între nefăcut și nefăcut :)  cartofii fără nici un gust. Sosul picant este excelent în schimb. Restul adus fără 10 lei. Am fost client fidel pe timpul anului, mergeam în fiecare zi,dar de ceva timp e cam bătaie de joc. Nu e frumos.", 3, new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6") },
                    { new Guid("2a59d09e-ac98-4c0b-8630-ee9d6a58f137"), "College Bar este un loc aparte , nu am mai vazut bar ca acesta.Cu mancare foarte buna si bauturile deasemenea !", 4, new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6") },
                    { new Guid("010ce692-ffd6-4276-86d4-455d173096ea"), "E aproape ca in vama..nu-i un loc pt printi și prințese :))", 1, new Guid("f463cd1e-42b9-412b-b294-5880080e0883") }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("42001e55-c6ec-4b56-8008-0d5930895867"),
                columns: new[] { "Password", "Token", "Username" },
                values: new object[] { "456", new Guid("e8394775-3c73-45e3-bdac-b513cfb5d7e8"), "Warm" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("744b602b-e8a7-4083-ac81-6ed65eebb56a"),
                columns: new[] { "Token", "Username" },
                values: new object[] { new Guid("15a193ff-1872-447d-a65a-3bce5ac76467"), "Freezing" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7e665add-6dda-4e36-b813-ecbd534dfffa"),
                columns: new[] { "Token", "Username" },
                values: new object[] { new Guid("a4e4e153-e27b-466c-814f-1c5d69b4323a"), "Sweltering" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"),
                columns: new[] { "Password", "Token" },
                values: new object[] { "567", new Guid("9fa67833-ece2-4834-8d64-274549f0c747") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f463cd1e-42b9-412b-b294-5880080e0883"),
                columns: new[] { "Password", "Token" },
                values: new object[] { "789", new Guid("372777e6-9430-4216-9a10-ec21966bc729") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("010ce692-ffd6-4276-86d4-455d173096ea"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("2a59d09e-ac98-4c0b-8630-ee9d6a58f137"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("5dc4004d-e649-4524-a4c0-901de3f0924a"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("776fefca-b609-4b51-bb6e-c6b90969a849"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("d4e0beea-8835-4ff3-a498-e2798cb46c76"));

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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("42001e55-c6ec-4b56-8008-0d5930895867"),
                columns: new[] { "Password", "Token", "Username" },
                values: new object[] { "789", new Guid("160dcabf-94dc-42d4-90c1-018edbae7fe0"), "Balmy" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("744b602b-e8a7-4083-ac81-6ed65eebb56a"),
                columns: new[] { "Token", "Username" },
                values: new object[] { new Guid("21e36819-b3c1-427c-8e5b-b250c16106e0"), "Cool" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7e665add-6dda-4e36-b813-ecbd534dfffa"),
                columns: new[] { "Token", "Username" },
                values: new object[] { new Guid("e3940a84-ccf5-4f7a-b8f9-fb81473de2d2"), "Bracing" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"),
                columns: new[] { "Password", "Token" },
                values: new object[] { "234", new Guid("96220253-30ca-4b1d-8982-47a1b44dc75a") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f463cd1e-42b9-412b-b294-5880080e0883"),
                columns: new[] { "Password", "Token" },
                values: new object[] { "456", new Guid("6af44d56-71b9-475c-b67c-ca375d22e518") });
        }
    }
}
