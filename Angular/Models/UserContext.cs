﻿using Angular.Models;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Angular.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        public UserContext() : base()
        { }

        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserFollowing> Followings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount() { UserId = 1, Username = "Test", Password = "6sNsu+pxGtzIoQmNHq2nX5KFbemuNM10tzdUuL5E8Zo=.xygrNhDB6A8KLH8QilMWkw==", Firstname = "Jans", Lastname = "Jansen", Gender = "M", BirthDate = DateTime.Now, Number = "155", City = "Stadskanaal", Street = "Hoofdkade", ZipCode = "9503HH", ProfileDescription = "Kaas", UserMediaId = 1 });
            modelBuilder.Entity<Post>().HasData(
                new Post() { PostUserId = 1, Message = "Kaas", PostedAt = DateTime.Now, PostId = 1 });
            modelBuilder.Entity<Comment>().HasData(
                new Comment() { CommentId = 1, CommentUserId = 1, CommentPostId = 1, Content = "Hippity hoppity", PostedAt = DateTime.Now });
            modelBuilder.Entity<Invitation>().HasData(
                new Invitation()
                {
                    InvitationId = 1,
                    NumberOfGuests = 1,
                    InvitationPostId = 1,
                    LocationPoint = new Point(52.9825827, 6.9540359) { SRID = 4326 }
                });
            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    LocationId = 1,
                    LocationInvitationId = 1,
                    LocationPoint = new Point(-122.333056, 47.609722) { SRID = 4326 }
                });
            modelBuilder.Entity<Review>().HasData(
                new Review()
                {
                    ReviewId = 1,
                    ReviewUserId = 1,
                    ReviewTargetId = 1,
                    Description = "Lekkere kaas wel.",
                    PostedAt = DateTime.UtcNow,
                    Rating = 5,
                });
            modelBuilder.Entity<Media>().HasData(
                new Media()
                {
                    MediaId = 1,
                    Type = "image/png",
                    ImageData = Encoding.UTF8.GetBytes("BLYAT")
                });
            _ = modelBuilder.Entity<UserFollowing>()
                .HasOne<UserAccount>(p => p.Target)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            _ = modelBuilder.Entity<UserFollowing>()
                .HasOne<UserAccount>(p => p.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            _ = modelBuilder.Entity<Review>()
                .HasOne(p => p.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            _ = modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            _ = modelBuilder.Entity<UserFollowing>()
                .HasOne(p => p.User)
                .WithMany(p => p.Following)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.FollowingUserAccountId);
            _ = modelBuilder.Entity<UserFollowing>()
                .HasOne(p => p.Target)
                .WithMany(p => p.Followers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.FollowingUserAccountTargetId);
        }
    }
}