using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostedAt",
                table: "Reviews",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 26, 3, 10, 13, 191, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 26, 3, 10, 13, 191, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 26, 3, 10, 13, 189, DateTimeKind.Local).AddTicks(1202));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedAt",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 25, 2, 49, 8, 849, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 25, 2, 49, 8, 849, DateTimeKind.Local).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 25, 2, 49, 8, 847, DateTimeKind.Local).AddTicks(1479));
        }
    }
}
