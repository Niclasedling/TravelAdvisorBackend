using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class UptDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttractionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "LastName", "Modified", "Password" },
                values: new object[,]
                {
                    { new Guid("6d157d49-58ca-4760-9fe1-7917fb8189da"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pontus.Bjornfot@outlook.com", "Pontus", "Bjornfot", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "????a??.?5?]z=?8w=.?s??>~N?Y" },
                    { new Guid("7a2dcb8d-2195-4b41-a4d0-875c6ebcf1e8"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robin.Edin@gmail.com", "Robin", "Robin", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "????a??.?5?]z=?8w=.?s??>~N?Y" },
                    { new Guid("ab731f94-c0d5-4246-a4f6-8245c723d72c"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex.Stenberg@gmail.com", "Alex", "Stenberg", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "????a??.?5?]z=?8w=.?s??>~N?Y" },
                    { new Guid("ece1da1c-6263-47e7-c36a-08d8911e42f9"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jens.Svensson@gmail.com", "Jens", "Svensson", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "????a??.?5?]z=?8w=.?s??>~N?Y" },
                    { new Guid("72898113-5015-44ed-9cc2-57382b5cd7f2"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johan.Andersson@gmail.com", "Johan", "Andersson", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "????a??.?5?]z=?8w=.?s??>~N?Y" },
                    { new Guid("109b6e0a-a64a-4feb-f16c-e68926ab2658"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mattias.Andersson@gmail.com", "Mattias", "Andersson", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "????a??.?5?]z=?8w=.?s??>~N?Y" },
                    { new Guid("4b3f3998-c612-4b5f-9994-887ba7496a21"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicki.Edling@gmail.com", "Nicki", "Edling", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "????a??.?5?]z=?8w=.?s??>~N?Y" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AttractionId",
                table: "Reviews",
                column: "AttractionId");

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
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
