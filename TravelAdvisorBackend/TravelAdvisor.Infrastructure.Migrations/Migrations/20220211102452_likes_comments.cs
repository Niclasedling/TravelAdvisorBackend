using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class likes_comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Reviews_ReviewTargetId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Reviews_ReviewTargetId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_ReviewTargetId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ReviewTargetId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewTargetId",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "ReviewTargetId",
                table: "Comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewTargetId",
                table: "Like",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewTargetId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Like_ReviewTargetId",
                table: "Like",
                column: "ReviewTargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ReviewTargetId",
                table: "Comment",
                column: "ReviewTargetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Reviews_ReviewTargetId",
                table: "Comment",
                column: "ReviewTargetId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Reviews_ReviewTargetId",
                table: "Like",
                column: "ReviewTargetId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
