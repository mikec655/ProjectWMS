using System;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class FoodShareVersion0176 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Invitations",
                nullable: true);

            migrationBuilder.AddColumn<IPoint>(
                name: "LocationPoint",
                table: "Invitations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Invitations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Invitations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 15, 50, 2, 25, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 15, 50, 2, 24, DateTimeKind.Local).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 28, 13, 50, 2, 32, DateTimeKind.Utc).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 28, 15, 50, 2, 22, DateTimeKind.Local).AddTicks(3029));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "LocationPoint",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Invitations");

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
        }
    }
}
