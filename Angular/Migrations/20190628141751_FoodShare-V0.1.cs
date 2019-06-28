using System;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Angular.Migrations
{
    public partial class FoodShareV01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    MediaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.MediaId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    UserMediaId = table.Column<int>(nullable: true),
                    ProfileDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Medias_UserMediaId",
                        column: x => x.UserMediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Followings",
                columns: table => new
                {
                    FollowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FollowingUserId = table.Column<int>(nullable: true),
                    FollowingTargetUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followings", x => x.FollowId);
                    table.ForeignKey(
                        name: "FK_Followings_Users_FollowingTargetUserId",
                        column: x => x.FollowingTargetUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Followings_Users_FollowingUserId",
                        column: x => x.FollowingUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostUserId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PostedAt = table.Column<DateTime>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    PostMediaId = table.Column<int>(nullable: false),
                    MediaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_PostUserId",
                        column: x => x.PostUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<short>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewTargetId = table.Column<int>(nullable: false),
                    PostedAt = table.Column<DateTime>(nullable: true),
                    ReviewUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReviewTargetId",
                        column: x => x.ReviewTargetId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReviewUserId",
                        column: x => x.ReviewUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentPostId = table.Column<int>(nullable: true),
                    CommentUserId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    PostedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_CommentPostId",
                        column: x => x.CommentPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_CommentUserId",
                        column: x => x.CommentUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    InvitationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvitationPostId = table.Column<int>(nullable: false),
                    PostedAt = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    NumberOfGuests = table.Column<int>(nullable: false),
                    LocationPoint = table.Column<IPoint>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.InvitationId);
                    table.ForeignKey(
                        name: "FK_Invitations_Posts_InvitationPostId",
                        column: x => x.InvitationPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuestUserId = table.Column<int>(nullable: false),
                    GuestInvitationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_Guests_Invitations_GuestInvitationId",
                        column: x => x.GuestInvitationId,
                        principalTable: "Invitations",
                        principalColumn: "InvitationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guests_Users_GuestUserId",
                        column: x => x.GuestUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationInvitationId = table.Column<int>(nullable: false),
                    LocationPoint = table.Column<IPoint>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Invitations_LocationInvitationId",
                        column: x => x.LocationInvitationId,
                        principalTable: "Invitations",
                        principalColumn: "InvitationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "MediaId", "ImageData", "Source", "Type" },
                values: new object[] { 1, new byte[] { 66, 76, 89, 65, 84 }, null, "image/png" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "City", "Firstname", "Gender", "Lastname", "Number", "Password", "ProfileDescription", "Street", "UserMediaId", "Username", "ZipCode" },
                values: new object[] { 1, new DateTime(2019, 6, 28, 16, 17, 50, 870, DateTimeKind.Local).AddTicks(5607), "Stadskanaal", "Jans", "M", "Jansen", "155", "6sNsu+pxGtzIoQmNHq2nX5KFbemuNM10tzdUuL5E8Zo=.xygrNhDB6A8KLH8QilMWkw==", "Kaas", "Hoofdkade", 1, "Test", "9503HH" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "MediaId", "Message", "PostMediaId", "PostUserId", "PostedAt", "Title" },
                values: new object[] { 1, null, "Kaas", 0, 1, new DateTime(2019, 6, 28, 16, 17, 50, 872, DateTimeKind.Local).AddTicks(3829), null });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "PostedAt", "Rating", "ReviewTargetId", "ReviewUserId" },
                values: new object[] { 1, "Lekkere kaas wel.", new DateTime(2019, 6, 28, 14, 17, 50, 878, DateTimeKind.Utc).AddTicks(9551), (short)5, 1, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentPostId", "CommentUserId", "Content", "PostedAt" },
                values: new object[] { 1, 1, 1, "Hippity hoppity", new DateTime(2019, 6, 28, 16, 17, 50, 872, DateTimeKind.Local).AddTicks(7004) });

            migrationBuilder.InsertData(
                table: "Invitations",
                columns: new[] { "InvitationId", "Address", "InvitationPostId", "LocationPoint", "Number", "NumberOfGuests", "PostedAt", "Type", "ZipCode" },
                values: new object[] { 1, null, 1, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "LocationInvitationId", "LocationPoint" },
                values: new object[] { 1, 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-122.333056 47.609722)") });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentPostId",
                table: "Comments",
                column: "CommentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentUserId",
                table: "Comments",
                column: "CommentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowingTargetUserId",
                table: "Followings",
                column: "FollowingTargetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowingUserId",
                table: "Followings",
                column: "FollowingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_GuestInvitationId",
                table: "Guests",
                column: "GuestInvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_GuestUserId",
                table: "Guests",
                column: "GuestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_InvitationPostId",
                table: "Invitations",
                column: "InvitationPostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationInvitationId",
                table: "Locations",
                column: "LocationInvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MediaId",
                table: "Posts",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostUserId",
                table: "Posts",
                column: "PostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewTargetId",
                table: "Reviews",
                column: "ReviewTargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewUserId",
                table: "Reviews",
                column: "ReviewUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserMediaId",
                table: "Users",
                column: "UserMediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Followings");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Medias");
        }
    }
}
