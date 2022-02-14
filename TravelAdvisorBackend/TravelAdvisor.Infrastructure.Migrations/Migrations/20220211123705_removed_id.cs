using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class removed_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Reviews_CommentId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Reviews_LikeId",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_LikeId",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CommentId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "LikeId",
                table: "Like",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CommentId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "LikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Reviews_CommentId",
                table: "Comment",
                column: "CommentId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Reviews_LikeId",
                table: "Like",
                column: "LikeId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Reviews_CommentId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Reviews_LikeId",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "LikeId",
                table: "Like",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Like",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CommentId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Like_LikeId",
                table: "Like",
                column: "LikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentId",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Reviews_CommentId",
                table: "Comment",
                column: "CommentId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Reviews_LikeId",
                table: "Like",
                column: "LikeId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
