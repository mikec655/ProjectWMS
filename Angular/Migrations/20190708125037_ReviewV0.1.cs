using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class ReviewV01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Reviews",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 2, 30, 45, 187, DateTimeKind.Local).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 6, 0, 30, 45, 187, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PostedAt",
                value: new DateTime(2019, 7, 9, 0, 30, 45, 187, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 0, 30, 45, 187, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 0, 30, 45, 194, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 7, 8, 2, 30, 45, 185, DateTimeKind.Local).AddTicks(8240));
        }
    }
}
