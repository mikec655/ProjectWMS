using Angular.Models;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
                new Post() { PostUserId = 1, Title = "Kaas", Message = "Vanavond zieke kaas maaltijd jo!", PostedAt = DateTime.UtcNow - TimeSpan.FromDays(2), PostId = 1, PostMediaId = 1 },
                new Post() { PostUserId = 1, Title = "Kaas", Message = "Kaas van gisteren was zo goed, k doe vanavond nog zo'n zieke kaas party", PostedAt = DateTime.UtcNow - -TimeSpan.FromDays(1), PostId = 2, PostMediaId = 1 },
                new Post() { PostUserId = 1, Title = "Kaas", Message = "Vanavond gewoon weer zieke kaas!!", PostedAt = DateTime.UtcNow, PostId = 3, PostMediaId = 1 });
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
            var hex = "FFD8FFE000104A46494600010101006000600000FFE100584578696600004D4D002A00000008000401310002000000110000003E5110000100000001010000005111000400000001000000005112000400000001000000000000000041646F626520496D61676552656164790000FFDB00430008060607060508070707090908";
            modelBuilder.Entity<Media>().HasData(
                new Media()
                {
                    MediaId = 1,
                    Type = "image/png",
                    ImageData = Enumerable.Range(0, hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                     .ToArray()
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