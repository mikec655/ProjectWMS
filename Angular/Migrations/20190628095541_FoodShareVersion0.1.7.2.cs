using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion0172 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 11, 55, 41, 401, DateTimeKind.Local).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 11, 55, 41, 401, DateTimeKind.Local).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 9, 55, 41, 407, DateTimeKind.Utc).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 28, 11, 55, 41, 399, DateTimeKind.Local).AddTicks(4447));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 11, 52, 59, 221, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 11, 52, 59, 220, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 9, 52, 59, 230, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 28, 11, 52, 59, 218, DateTimeKind.Local).AddTicks(7050));
        }
    }
}
