using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_CommentPostId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "More",
                table: "Users",
                newName: "Number");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileDescription",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentPostId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

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
                columns: new[] { "BirthDate", "City", "Number", "ProfileDescription", "ProfilePicture", "Street", "ZipCode" },
                values: new object[] { new DateTime(2019, 6, 25, 2, 49, 8, 847, DateTimeKind.Local).AddTicks(1479), "Stadskanaal", 611992103, "Kaas", "Putin.jpg", "Hoofdkade", "9503HH" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_CommentPostId",
                table: "Comments",
                column: "CommentPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_CommentPostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileDescription",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Users",
                newName: "More");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentPostId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 19, 15, 0, 7, 101, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 19, 15, 0, 7, 101, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "BirthDate", "More" },
                values: new object[] { new DateTime(2019, 6, 19, 15, 0, 7, 99, DateTimeKind.Local).AddTicks(7161), 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_CommentPostId",
                table: "Comments",
                column: "CommentPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
