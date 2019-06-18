using Angular.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        public UserContext() : base()
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, Username = "Test", Password = "6sNsu+pxGtzIoQmNHq2nX5KFbemuNM10tzdUuL5E8Zo=.xygrNhDB6A8KLH8QilMWkw==", Firstname = "Jans", Lastname = "Jansen", Gender = "M", BirthDate = DateTime.Now });
            modelBuilder.Entity<Post>().HasData(
                new Post() { PostUserId = 1, Message = "Kaas", PostedAt = DateTime.Now, PostId = 1 });
            _ = modelBuilder.Entity<Following>()
                .HasOne<User>(p => p.Target)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            _ = modelBuilder.Entity<Following>()
                .HasOne<User>(p => p.User)
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
        }
    }
}