﻿// <auto-generated />
using System;
using Angular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Angular.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20190617130306_FoodShareInitial")]
    partial class FoodShareInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Angular.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Rating");

                    b.Property<int>("ReviewTargetId");

                    b.Property<int>("ReviewUserId");

                    b.HasKey("ReviewId");

                    b.HasIndex("ReviewTargetId");

                    b.HasIndex("ReviewUserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Angular.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthData");

                    b.Property<string>("Firstname");

                    b.Property<string>("Gender");

                    b.Property<string>("Lastname");

                    b.Property<int>("More");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Angular.Models.Review", b =>
                {
                    b.HasOne("Angular.Models.User", "Target")
                        .WithMany()
                        .HasForeignKey("ReviewTargetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Angular.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
