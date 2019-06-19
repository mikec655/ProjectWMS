using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Invitations_GuestInvitationId",
                table: "Guests");

            migrationBuilder.AlterColumn<int>(
                name: "GuestInvitationId",
                table: "Guests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Message", "PostUserId", "PostedAt" },
                values: new object[] { 1, "Kaas", 1, new DateTime(2019, 6, 19, 13, 17, 48, 595, DateTimeKind.Local).AddTicks(6858) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 19, 13, 17, 48, 593, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentPostId", "CommentUserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Invitations_GuestInvitationId",
                table: "Guests",
                column: "GuestInvitationId",
                principalTable: "Invitations",
                principalColumn: "InvitationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Invitations_GuestInvitationId",
                table: "Guests");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "GuestInvitationId",
                table: "Guests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 17, 15, 48, 34, 553, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Invitations_GuestInvitationId",
                table: "Guests",
                column: "GuestInvitationId",
                principalTable: "Invitations",
                principalColumn: "InvitationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
