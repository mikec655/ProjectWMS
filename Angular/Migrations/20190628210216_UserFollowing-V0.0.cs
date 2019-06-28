using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class UserFollowingV00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAccountUserId",
                table: "Followings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAccountUserId1",
                table: "Followings",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 23, 2, 16, 13, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 23, 2, 16, 12, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 21, 2, 16, 22, DateTimeKind.Utc).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 28, 23, 2, 16, 9, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.CreateIndex(
                name: "IX_Followings_UserAccountUserId",
                table: "Followings",
                column: "UserAccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_UserAccountUserId1",
                table: "Followings",
                column: "UserAccountUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Users_UserAccountUserId",
                table: "Followings",
                column: "UserAccountUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Users_UserAccountUserId1",
                table: "Followings",
                column: "UserAccountUserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Users_UserAccountUserId",
                table: "Followings");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Users_UserAccountUserId1",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_UserAccountUserId",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_UserAccountUserId1",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "UserAccountUserId",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "UserAccountUserId1",
                table: "Followings");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 16, 17, 50, 872, DateTimeKind.Local).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 16, 17, 50, 872, DateTimeKind.Local).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 14, 17, 50, 878, DateTimeKind.Utc).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 28, 16, 17, 50, 870, DateTimeKind.Local).AddTicks(5607));
        }
    }
}
