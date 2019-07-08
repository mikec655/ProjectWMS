using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class CommentPostRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 9, 0, 14, 42, 882, DateTimeKind.Local).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 6, 22, 14, 42, 882, DateTimeKind.Utc).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PostedAt",
                value: new DateTime(2019, 7, 7, 22, 14, 42, 882, DateTimeKind.Utc).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 22, 14, 42, 882, DateTimeKind.Utc).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 22, 14, 42, 890, DateTimeKind.Utc).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 7, 9, 0, 14, 42, 881, DateTimeKind.Local).AddTicks(790));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
