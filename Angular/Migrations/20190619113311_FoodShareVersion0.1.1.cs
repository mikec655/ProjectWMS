using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedAt",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                columns: new[] { "Content", "PostedAt" },
                values: new object[] { "Hippity hoppity", new DateTime(2019, 6, 19, 13, 33, 10, 967, DateTimeKind.Local).AddTicks(8659) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 19, 13, 33, 10, 967, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 19, 13, 33, 10, 965, DateTimeKind.Local).AddTicks(8494));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostedAt",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 19, 13, 17, 48, 595, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 19, 13, 17, 48, 593, DateTimeKind.Local).AddTicks(5446));
        }
    }
}
