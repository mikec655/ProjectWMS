using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class DefaultImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 4, 23, 47, 55, 883, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Medias",
                keyColumn: "MediaId",
                keyValue: 1,
                column: "ImageData",
                value: new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 1, 0, 96, 0, 96, 0, 0, 255, 225, 0, 88, 69, 120, 105, 102, 0, 0, 77, 77, 0, 42, 0, 0, 0, 8, 0, 4, 1, 49, 0, 2, 0, 0, 0, 17, 0, 0, 0, 62, 81, 16, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 81, 17, 0, 4, 0, 0, 0, 1, 0, 0, 0, 0, 81, 18, 0, 4, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 65, 100, 111, 98, 101, 32, 73, 109, 97, 103, 101, 82, 101, 97, 100, 121, 0, 0, 255, 219, 0, 67, 0, 8, 6, 6, 7, 6, 5, 8, 7, 7, 7, 9, 9, 8 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "Message", "PostMediaId", "PostedAt", "Title" },
                values: new object[] { "Vanavond zieke kaas maaltijd jo!", 1, new DateTime(2019, 7, 2, 21, 47, 55, 883, DateTimeKind.Utc).AddTicks(2217), "Kaas" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "MediaId", "Message", "PostMediaId", "PostUserId", "PostedAt", "Title" },
                values: new object[,]
                {
                    { 2, null, "Kaas van gisteren was zo goed, k doe vanavond nog zo'n zieke kaas party", 1, 1, new DateTime(2019, 7, 5, 21, 47, 55, 883, DateTimeKind.Utc).AddTicks(2219), "Kaas" },
                    { 3, null, "Vanavond gewoon weer zieke kaas!!", 1, 1, new DateTime(2019, 7, 4, 21, 47, 55, 883, DateTimeKind.Utc).AddTicks(2221), "Kaas" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 4, 21, 47, 55, 892, DateTimeKind.Utc).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 7, 4, 23, 47, 55, 880, DateTimeKind.Local).AddTicks(9040));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 29, 22, 45, 32, 173, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: "Medias",
                keyColumn: "MediaId",
                keyValue: 1,
                column: "ImageData",
                value: new byte[] { 66, 76, 89, 65, 84 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "Message", "PostMediaId", "PostedAt", "Title" },
                values: new object[] { "Kaas", 0, new DateTime(2019, 6, 29, 22, 45, 32, 173, DateTimeKind.Local).AddTicks(569), null });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 30, 16, 50, 59, 714, DateTimeKind.Utc).AddTicks(2078));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 29, 22, 45, 32, 171, DateTimeKind.Local).AddTicks(19));
        }
    }
}
