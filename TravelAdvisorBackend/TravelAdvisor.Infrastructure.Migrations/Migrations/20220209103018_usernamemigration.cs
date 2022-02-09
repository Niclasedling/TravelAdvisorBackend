using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class usernamemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("109b6e0a-a64a-4feb-f16c-e68926ab2658"),
                column: "UserName",
                value: "MA");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b3f3998-c612-4b5f-9994-887ba7496a21"),
                column: "UserName",
                value: "NE");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d157d49-58ca-4760-9fe1-7917fb8189da"),
                column: "UserName",
                value: "PB");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72898113-5015-44ed-9cc2-57382b5cd7f2"),
                column: "UserName",
                value: "JA");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7a2dcb8d-2195-4b41-a4d0-875c6ebcf1e8"),
                column: "UserName",
                value: "RR");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ab731f94-c0d5-4246-a4f6-8245c723d72c"),
                column: "UserName",
                value: "AS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ece1da1c-6263-47e7-c36a-08d8911e42f9"),
                column: "UserName",
                value: "JS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");
        }
    }
}
