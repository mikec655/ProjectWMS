using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersionV015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Posts_MediaPostId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_MediaPostId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "MediaPostId",
                table: "Medias");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedAt",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Medias",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Medias");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedAt",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaPostId",
                table: "Medias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "City", "Firstname", "Gender", "Lastname", "Number", "Password", "ProfileDescription", "ProfilePicture", "Street", "Username", "ZipCode" },
                values: new object[] { 1, new DateTime(2019, 6, 26, 3, 13, 32, 130, DateTimeKind.Local).AddTicks(6315), "Stadskanaal", "Jans", "M", "Jansen", 611992103, "6sNsu+pxGtzIoQmNHq2nX5KFbemuNM10tzdUuL5E8Zo=.xygrNhDB6A8KLH8QilMWkw==", "Kaas", "Putin.jpg", "Hoofdkade", "Test", "9503HH" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaPostId",
                table: "Medias",
                column: "MediaPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Posts_MediaPostId",
                table: "Medias",
                column: "MediaPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
