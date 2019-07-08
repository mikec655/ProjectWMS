using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class MediaV02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Medias");

            migrationBuilder.AlterColumn<int>(
                name: "PostMediaId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MediaUserAccountId",
                table: "Medias",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 2, 30, 45, 187, DateTimeKind.Local).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 6, 0, 30, 45, 187, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PostedAt",
                value: new DateTime(2019, 7, 9, 0, 30, 45, 187, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 0, 30, 45, 187, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 8, 0, 30, 45, 194, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 7, 8, 2, 30, 45, 185, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaUserAccountId",
                table: "Medias",
                column: "MediaUserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Users_MediaUserAccountId",
                table: "Medias",
                column: "MediaUserAccountId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Users_MediaUserAccountId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_MediaUserAccountId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "MediaUserAccountId",
                table: "Medias");

            migrationBuilder.AlterColumn<int>(
                name: "PostMediaId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 4, 23, 47, 55, 883, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 7, 2, 21, 47, 55, 883, DateTimeKind.Utc).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PostedAt",
                value: new DateTime(2019, 7, 5, 21, 47, 55, 883, DateTimeKind.Utc).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PostedAt",
                value: new DateTime(2019, 7, 4, 21, 47, 55, 883, DateTimeKind.Utc).AddTicks(2221));

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
    }
}
