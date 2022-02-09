using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class addedcitycolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Attractions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                columns: new[] { "Address", "City", "Name" },
                values: new object[] { "Rom Colosseum", "Rom", "Rom Colosseum" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("252e9eea-9f1e-4fe2-bbf2-bcc17d1df943"),
                columns: new[] { "City", "Name" },
                values: new object[] { "Berlin", "Shopping Center" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("514fae50-43a7-4958-9abd-c549817b9414"),
                columns: new[] { "City", "Name" },
                values: new object[] { "Stockholm", "Hamnen" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("9b6cd306-a29f-40f5-9ba6-25906164d849"),
                columns: new[] { "City", "Name" },
                values: new object[] { "Prag", "Prag Centrum Norra" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("e0044d7a-3b3b-4a10-b67c-d85b2181fbe9"),
                columns: new[] { "City", "Name" },
                values: new object[] { "Oslo", "Oslo Centrum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Attractions");

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                columns: new[] { "Address", "Name" },
                values: new object[] { "Rome Colosseum", "Rome" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("252e9eea-9f1e-4fe2-bbf2-bcc17d1df943"),
                column: "Name",
                value: "Berlin");

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("514fae50-43a7-4958-9abd-c549817b9414"),
                column: "Name",
                value: "Stockholm");

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("9b6cd306-a29f-40f5-9ba6-25906164d849"),
                column: "Name",
                value: "Prag");

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("e0044d7a-3b3b-4a10-b67c-d85b2181fbe9"),
                column: "Name",
                value: "Oslo");
        }
    }
}
