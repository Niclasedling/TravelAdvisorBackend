using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class UpdateAttrction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Attractions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Attractions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Attractions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "Address", "Created", "Details", "Image", "Latitude", "Longitude", "Modified", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("514fae50-43a7-4958-9abd-c549817b9414"), "Stockholm Södra", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stockholms södra station är en överbyggd järnvägsstation på Västra stambanan i stadsdelen Södermalm i centrala Stockholm. ", "", 45.0, 54.0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stockholm", 100 },
                    { new Guid("252e9eea-9f1e-4fe2-bbf2-bcc17d1df943"), "Berlin Norra", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inräknat förorter har staden omkring 4,6 miljoner invånare och hela storstadsregionen 6,1 miljoner. ", "", 45.0, 54.0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berlin", 100 },
                    { new Guid("e0044d7a-3b3b-4a10-b67c-d85b2181fbe9"), "Oslo Centrum", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oslo, från 1624 till 1925 Kristiania, äldst Anslo/Ásló/Ósló, är Norges huvudstad och administrativt är Oslo kommun ett eget fylke, med drygt 690 000 invånare. ", "", 45.0, 54.0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oslo", 100 },
                    { new Guid("9b6cd306-a29f-40f5-9ba6-25906164d849"), "Prag Centrum Norra", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prag är huvudstad och största stad i Tjeckien samt är belägen vid floden Moldau.", "", 45.0, 54.0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prag", 100 },
                    { new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), "Rome Colosseum", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bygget som slutfördes av hans son Titus", "", 45.0, 54.0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rome", 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("252e9eea-9f1e-4fe2-bbf2-bcc17d1df943"));

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("514fae50-43a7-4958-9abd-c549817b9414"));

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("9b6cd306-a29f-40f5-9ba6-25906164d849"));

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: new Guid("e0044d7a-3b3b-4a10-b67c-d85b2181fbe9"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Attractions");
        }
    }
}
