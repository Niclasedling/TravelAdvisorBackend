using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class add_thumbinteractions_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<Guid>(
            //    name: "Id",
            //    table: "Comments",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "ThumbInteractions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasLiked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThumbInteractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThumbInteractions_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThumbInteractions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThumbInteractions_ReviewId",
                table: "ThumbInteractions",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ThumbInteractions_UserId",
                table: "ThumbInteractions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThumbInteractions");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
