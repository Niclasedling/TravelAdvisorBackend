using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class review_property_removed_price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Attractions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Attractions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("252e9eea-9f1e-4fe2-bbf2-bcc17d1df943"),
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("514fae50-43a7-4958-9abd-c549817b9414"),
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("9b6cd306-a29f-40f5-9ba6-25906164d849"),
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("e0044d7a-3b3b-4a10-b67c-d85b2181fbe9"),
                column: "Price",
                value: 100);
        }
    }
}
