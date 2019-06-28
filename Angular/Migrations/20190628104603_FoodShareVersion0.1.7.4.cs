using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion0174 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invitations_InvitationPostId",
                table: "Invitations");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 12, 46, 3, 56, DateTimeKind.Local).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 12, 46, 3, 56, DateTimeKind.Local).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 10, 46, 3, 62, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 28, 12, 46, 3, 54, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_InvitationPostId",
                table: "Invitations",
                column: "InvitationPostId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invitations_InvitationPostId",
                table: "Invitations");

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

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_InvitationPostId",
                table: "Invitations",
                column: "InvitationPostId");
        }
    }
}
