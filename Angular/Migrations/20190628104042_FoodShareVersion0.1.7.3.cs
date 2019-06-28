using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion0173 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Invitations",
                newName: "PostedAt");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 12, 40, 41, 714, DateTimeKind.Local).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 12, 40, 41, 714, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 10, 40, 41, 720, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 28, 12, 40, 41, 712, DateTimeKind.Local).AddTicks(3707));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostedAt",
                table: "Invitations",
                newName: "Time");

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
    }
}
