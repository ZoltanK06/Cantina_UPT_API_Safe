﻿// <auto-generated />
using System;
using CantinaUPT_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CantinaUPT_API.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230406163246_user-modified")]
    partial class usermodified
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Canteen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Canteens");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("OrderId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.DailyMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CanteenId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CanteenId");

                    b.ToTable("DailyMenus");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Disponibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CanteenId")
                        .HasColumnType("int");

                    b.Property<bool>("Disposable")
                        .HasColumnType("bit");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Disponibilities");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CanteenId")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int?>("DailyMenuId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Portion")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CanteenId");

                    b.HasIndex("DailyMenuId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.CartItem", b =>
                {
                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.Order", null)
                        .WithMany("CartItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.DailyMenu", b =>
                {
                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.Canteen", null)
                        .WithMany("Menus")
                        .HasForeignKey("CanteenId");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Meal", b =>
                {
                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.Canteen", null)
                        .WithMany("Meals")
                        .HasForeignKey("CanteenId");

                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.DailyMenu", null)
                        .WithMany("meals")
                        .HasForeignKey("DailyMenuId");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.ToDoItem", b =>
                {
                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.Project", null)
                        .WithMany("Items")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Canteen", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("Menus");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.DailyMenu", b =>
                {
                    b.Navigation("meals");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Order", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Project", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
