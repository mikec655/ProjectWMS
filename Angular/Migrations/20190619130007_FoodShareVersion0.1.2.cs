using System;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Angular.Migrations
{
    public partial class FoodShareVersion012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<IPoint>(
                name: "LocationPoint",
                table: "Locations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 19, 15, 0, 7, 101, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.InsertData(
                table: "Invitations",
                columns: new[] { "InvitationId", "InvitationPostId", "NumberOfGuest", "Time", "Type" },
                values: new object[] { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

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
                column: "BirthDate",
                value: new DateTime(2019, 6, 19, 15, 0, 7, 99, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "LocationInvitationId", "LocationPoint" },
                values: new object[] { 1, 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-122.333056 47.609722)") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invitations",
                keyColumn: "InvitationId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "LocationPoint",
                table: "Locations");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 19, 13, 33, 10, 967, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedAt",
                value: new DateTime(2019, 6, 19, 13, 33, 10, 967, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 6, 19, 13, 33, 10, 965, DateTimeKind.Local).AddTicks(8494));
        }
    }
}
