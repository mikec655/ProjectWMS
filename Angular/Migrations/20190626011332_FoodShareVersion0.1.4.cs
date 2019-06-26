using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 26, 3, 13, 32, 134, DateTimeKind.Local).AddTicks(466));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 26, 3, 13, 32, 133, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "PostedAt", "Rating", "ReviewTargetId", "ReviewUserId" },
                values: new object[] { 1, "Lekkere kaas wel.", new DateTime(2019, 6, 26, 1, 13, 32, 144, DateTimeKind.Utc).AddTicks(3908), (short)5, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 26, 3, 13, 32, 130, DateTimeKind.Local).AddTicks(6315));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

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
    }
}
