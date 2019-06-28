using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion0175 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Invitations_GuestInvitationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "InvitationId",
                table: "Guests");

            migrationBuilder.AlterColumn<int>(
                name: "GuestInvitationId",
                table: "Guests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 13, 22, 8, 574, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 13, 22, 8, 573, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 11, 22, 8, 580, DateTimeKind.Utc).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 28, 13, 22, 8, 571, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Invitations_GuestInvitationId",
                table: "Guests",
                column: "GuestInvitationId",
                principalTable: "Invitations",
                principalColumn: "InvitationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Invitations_GuestInvitationId",
                table: "Guests");

            migrationBuilder.AlterColumn<int>(
                name: "GuestInvitationId",
                table: "Guests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "InvitationId",
                table: "Guests",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Invitations_GuestInvitationId",
                table: "Guests",
                column: "GuestInvitationId",
                principalTable: "Invitations",
                principalColumn: "InvitationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
