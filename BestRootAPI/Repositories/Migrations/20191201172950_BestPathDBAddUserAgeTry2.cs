using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class BestPathDBAddUserAgeTry2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "User",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("42001e55-c6ec-4b56-8008-0d5930895867"),
                columns: new[] { "Token", "Username" },
                values: new object[] { new Guid("585b28b1-1713-4716-9c7a-81e3e0094ac2"), "Balmy" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("744b602b-e8a7-4083-ac81-6ed65eebb56a"),
                columns: new[] { "Password", "Token", "Username" },
                values: new object[] { "678", new Guid("e73bc12c-fa81-4812-9945-6fd8656c744e"), "Scorching" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7e665add-6dda-4e36-b813-ecbd534dfffa"),
                columns: new[] { "Password", "Token", "Username" },
                values: new object[] { "234", new Guid("5609c777-70dd-40d2-b21d-3c213c666deb"), "Scorching" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"),
                columns: new[] { "Token", "Username" },
                values: new object[] { new Guid("5664888b-3d93-4547-aee9-d487d973de68"), "Scorching" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f463cd1e-42b9-412b-b294-5880080e0883"),
                columns: new[] { "Password", "Token", "Username" },
                values: new object[] { "567", new Guid("2c51b120-924a-4606-8d9a-e31b2c4e0f25"), "Bracing" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("08fcdf3a-bdc2-40fe-8c09-262514fc0004"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("46accd10-32e6-4037-a606-734116594544"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("5d282d4b-496e-4515-bb73-7f65eab84379"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("883f770a-d75d-461a-8fa7-193a4f628f25"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("be868109-4a59-4040-8c6f-de7a55287223"));

            migrationBuilder.DropColumn(
                name: "Age",
                table: "User");

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
                columns: new[] { "Token", "Username" },
                values: new object[] { new Guid("e8394775-3c73-45e3-bdac-b513cfb5d7e8"), "Warm" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("744b602b-e8a7-4083-ac81-6ed65eebb56a"),
                columns: new[] { "Password", "Token", "Username" },
                values: new object[] { "456", new Guid("15a193ff-1872-447d-a65a-3bce5ac76467"), "Freezing" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7e665add-6dda-4e36-b813-ecbd534dfffa"),
                columns: new[] { "Password", "Token", "Username" },
                values: new object[] { "678", new Guid("a4e4e153-e27b-466c-814f-1c5d69b4323a"), "Sweltering" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"),
                columns: new[] { "Token", "Username" },
                values: new object[] { new Guid("9fa67833-ece2-4834-8d64-274549f0c747"), "Bracing" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f463cd1e-42b9-412b-b294-5880080e0883"),
                columns: new[] { "Password", "Token", "Username" },
                values: new object[] { "789", new Guid("372777e6-9430-4216-9a10-ec21966bc729"), "Cool" });
        }
    }
}
