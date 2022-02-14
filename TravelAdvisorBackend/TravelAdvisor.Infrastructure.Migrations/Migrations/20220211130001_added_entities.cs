using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    public partial class added_entities : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "LikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reviews_CommentId",
                table: "Comments",
                column: "CommentId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Reviews_LikeId",
                table: "Likes",
                column: "LikeId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reviews_CommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Reviews_LikeId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

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
    }
}
