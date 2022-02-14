using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class moved_likes_comments_to_review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReviewId",
                table: "Like",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Like_ReviewId",
                table: "Like",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ReviewId",
                table: "Comment",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Reviews_ReviewId",
                table: "Comment",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Reviews_ReviewId",
                table: "Like",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Reviews_ReviewId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Reviews_ReviewId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_ReviewId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ReviewId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Comment");
        }
    }
}
