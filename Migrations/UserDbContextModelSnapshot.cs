﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Users;

#nullable disable

namespace WebApi.Users.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Users.Data.Models.UserModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone_number");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_status");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedAt = new DateTime(2023, 1, 29, 10, 20, 28, 857, DateTimeKind.Local).AddTicks(4340),
                            FirstName = "John",
                            LastName = "Doe",
                            Password = "Password123",
                            Phone = "+123 456 789",
                            UserName = "JohnDoe123",
                            status = "user"
                        },
                        new
                        {
                            id = 2,
                            CreatedAt = new DateTime(2023, 1, 27, 10, 20, 28, 857, DateTimeKind.Local).AddTicks(4400),
                            FirstName = "Test",
                            LastName = "Testson",
                            Password = "223456",
                            Phone = "+123 456 ",
                            UserName = "User1234",
                            status = "user"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
