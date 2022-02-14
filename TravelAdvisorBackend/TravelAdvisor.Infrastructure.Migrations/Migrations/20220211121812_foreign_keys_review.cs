using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class foreign_keys_review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Reviews_ReviewId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Reviews_ReviewId",
                table: "Like");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Like",
                newName: "LikeId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_ReviewId",
                table: "Like",
                newName: "IX_Like_LikeId");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Comment",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ReviewId",
                table: "Comment",
                newName: "IX_Comment_CommentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Reviews_CommentId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Reviews_LikeId",
                table: "Like");

            migrationBuilder.RenameColumn(
                name: "LikeId",
                table: "Like",
                newName: "ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_LikeId",
                table: "Like",
                newName: "IX_Like_ReviewId");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comment",
                newName: "ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CommentId",
                table: "Comment",
                newName: "IX_Comment_ReviewId");

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
    }
}
