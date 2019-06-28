﻿// <auto-generated />
using System;
using Angular.Models;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Angular.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Angular.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentPostId");

                    b.Property<int>("CommentUserId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("PostedAt");

                    b.HasKey("CommentId");

                    b.HasIndex("CommentPostId");

                    b.HasIndex("CommentUserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            CommentPostId = 1,
                            CommentUserId = 1,
                            Content = "Hippity hoppity",
                            PostedAt = new DateTime(2019, 6, 28, 15, 57, 4, 515, DateTimeKind.Local).AddTicks(4224)
                        });
                });

            modelBuilder.Entity("Angular.Models.Following", b =>
                {
                    b.Property<int>("FollowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FollowingTargetUserId");

                    b.Property<int?>("FollowingUserId");

                    b.HasKey("FollowId");

                    b.HasIndex("FollowingTargetUserId");

                    b.HasIndex("FollowingUserId");

                    b.ToTable("Followings");
                });

            modelBuilder.Entity("Angular.Models.Guest", b =>
                {
                    b.Property<int>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GuestInvitationId");

                    b.Property<int>("GuestUserId");

                    b.HasKey("GuestId");

                    b.HasIndex("GuestInvitationId");

                    b.HasIndex("GuestUserId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Angular.Models.Invitation", b =>
                {
                    b.Property<int>("InvitationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("InvitationPostId");

                    b.Property<IPoint>("LocationPoint");

                    b.Property<string>("Number");

                    b.Property<int>("NumberOfGuests");

                    b.Property<DateTime>("PostedAt");

                    b.Property<string>("Type");

                    b.Property<string>("ZipCode");

                    b.HasKey("InvitationId");

                    b.HasIndex("InvitationPostId")
                        .IsUnique();

                    b.ToTable("Invitations");

                    b.HasData(
                        new
                        {
                            InvitationId = 1,
                            InvitationPostId = 1,
                            NumberOfGuests = 1,
                            PostedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Angular.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationInvitationId");

                    b.Property<IPoint>("LocationPoint");

                    b.HasKey("LocationId");

                    b.HasIndex("LocationInvitationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            LocationInvitationId = 1,
                            LocationPoint = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-122.333056 47.609722)")
                        });
                });

            modelBuilder.Entity("Angular.Models.Media", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageData");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MediaId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("Angular.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MediaId");

                    b.Property<string>("Message");

                    b.Property<int>("PostMediaId");

                    b.Property<int>("PostUserId");

                    b.Property<DateTime?>("PostedAt");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("MediaId");

                    b.HasIndex("PostUserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            Message = "Kaas",
                            PostMediaId = 0,
                            PostUserId = 1,
                            PostedAt = new DateTime(2019, 6, 28, 15, 57, 4, 515, DateTimeKind.Local).AddTicks(917)
                        });
                });

            modelBuilder.Entity("Angular.Models.Review", b =>
                {
                    b.Property<int?>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PostedAt");

                    b.Property<short>("Rating");

                    b.Property<int>("ReviewTargetId");

                    b.Property<int>("ReviewUserId");

                    b.HasKey("ReviewId");

                    b.HasIndex("ReviewTargetId");

                    b.HasIndex("ReviewUserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            Description = "Lekkere kaas wel.",
                            PostedAt = new DateTime(2019, 6, 28, 13, 57, 4, 521, DateTimeKind.Utc).AddTicks(6700),
                            Rating = (short)5,
                            ReviewTargetId = 1,
                            ReviewUserId = 1
                        });
                });

            modelBuilder.Entity("Angular.Models.UserAccount", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("City");

                    b.Property<string>("Firstname");

                    b.Property<string>("Gender");

                    b.Property<string>("Lastname");

                    b.Property<string>("Number");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProfileDescription");

                    b.Property<string>("Street");

                    b.Property<int?>("UserMediaId");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ZipCode");

                    b.HasKey("UserId");

                    b.HasIndex("UserMediaId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            BirthDate = new DateTime(2019, 6, 28, 15, 57, 4, 513, DateTimeKind.Local).AddTicks(2395),
                            City = "Stadskanaal",
                            Firstname = "Jans",
                            Gender = "M",
                            Lastname = "Jansen",
                            Number = "155",
                            Password = "6sNsu+pxGtzIoQmNHq2nX5KFbemuNM10tzdUuL5E8Zo=.xygrNhDB6A8KLH8QilMWkw==",
                            ProfileDescription = "Kaas",
                            Street = "Hoofdkade",
                            UserMediaId = 1,
                            Username = "Test",
                            ZipCode = "9503HH"
                        });
                });

            modelBuilder.Entity("Angular.Models.Comment", b =>
                {
                    b.HasOne("Angular.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("CommentPostId");

                    b.HasOne("Angular.Models.UserAccount", "User")
                        .WithMany()
                        .HasForeignKey("CommentUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Angular.Models.Following", b =>
                {
                    b.HasOne("Angular.Models.UserAccount", "Target")
                        .WithMany()
                        .HasForeignKey("FollowingTargetUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Angular.Models.UserAccount", "User")
                        .WithMany()
                        .HasForeignKey("FollowingUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Angular.Models.Guest", b =>
                {
                    b.HasOne("Angular.Models.Invitation", "Invitation")
                        .WithMany("Guests")
                        .HasForeignKey("GuestInvitationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Angular.Models.UserAccount", "User")
                        .WithMany()
                        .HasForeignKey("GuestUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Angular.Models.Invitation", b =>
                {
                    b.HasOne("Angular.Models.Post", "Post")
                        .WithOne("Invitation")
                        .HasForeignKey("Angular.Models.Invitation", "InvitationPostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Angular.Models.Location", b =>
                {
                    b.HasOne("Angular.Models.Invitation", "Invitation")
                        .WithMany()
                        .HasForeignKey("LocationInvitationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Angular.Models.Post", b =>
                {
                    b.HasOne("Angular.Models.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId");

                    b.HasOne("Angular.Models.UserAccount", "User")
                        .WithMany()
                        .HasForeignKey("PostUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Angular.Models.Review", b =>
                {
                    b.HasOne("Angular.Models.UserAccount", "Target")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewTargetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Angular.Models.UserAccount", "User")
                        .WithMany()
                        .HasForeignKey("ReviewUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Angular.Models.UserAccount", b =>
                {
                    b.HasOne("Angular.Models.Media", "ProfilePicture")
                        .WithMany()
                        .HasForeignKey("UserMediaId");
                });
#pragma warning restore 612, 618
        }
    }
}
