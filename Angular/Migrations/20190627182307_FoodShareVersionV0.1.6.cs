using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersionV016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserMediaId",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 27, 20, 23, 6, 687, DateTimeKind.Local).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 27, 20, 23, 6, 686, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 27, 18, 23, 6, 696, DateTimeKind.Utc).AddTicks(366));

            migrationBuilder.InsertData(
                table: "Medias",
                column: "Type",
                value: "image/png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "BirthDate", "UserMediaId" },
                values: new object[] { new DateTime(2019, 6, 27, 20, 23, 6, 684, DateTimeKind.Local).AddTicks(1356), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserMediaId",
                table: "Users",
                column: "UserMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Medias_UserMediaId",
                table: "Users",
                column: "UserMediaId",
                principalTable: "Medias",
                principalColumn: "MediaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Medias_UserMediaId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserMediaId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserMediaId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 27, 18, 18, 35, 723, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 27, 18, 18, 35, 722, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 27, 16, 18, 35, 729, DateTimeKind.Utc).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "BirthDate", "ProfilePicture" },
                values: new object[] { new DateTime(2019, 6, 27, 18, 18, 35, 720, DateTimeKind.Local).AddTicks(6730), "Putin.jpg" });
        }
    }
}
