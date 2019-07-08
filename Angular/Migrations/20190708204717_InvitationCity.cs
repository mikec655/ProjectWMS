using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class InvitationCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Invitations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 22, 47, 17, 510, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 6, 20, 47, 17, 510, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PostedAt",
                value: new DateTime(2019, 7, 7, 20, 47, 17, 510, DateTimeKind.Utc).AddTicks(1525));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 20, 47, 17, 510, DateTimeKind.Utc).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 20, 47, 17, 516, DateTimeKind.Utc).AddTicks(5241));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 7, 8, 22, 47, 17, 508, DateTimeKind.Local).AddTicks(6562));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Invitations");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 14, 50, 36, 780, DateTimeKind.Local).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 6, 12, 50, 36, 780, DateTimeKind.Utc).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PostedAt",
                value: new DateTime(2019, 7, 9, 12, 50, 36, 780, DateTimeKind.Utc).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 12, 50, 36, 780, DateTimeKind.Utc).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 12, 50, 36, 787, DateTimeKind.Utc).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 7, 8, 14, 50, 36, 779, DateTimeKind.Local).AddTicks(5285));
        }
    }
}
