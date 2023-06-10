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
    [Migration("20230507132805_added-category-pictures")]
    partial class addedcategorypictures
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

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.CategoryPictures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoryPictures");
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

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CanteenId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("DailyMenuId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponibility")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PortionId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CanteenId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DailyMenuId");

                    b.HasIndex("PortionId");

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

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OrderStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Portion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PortionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Portions");
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

                    b.Property<int?>("CanteenId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CanteenId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
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

                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.DailyMenu", null)
                        .WithMany("meals")
                        .HasForeignKey("DailyMenuId");

                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.Portion", "Portion")
                        .WithMany()
                        .HasForeignKey("PortionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Portion");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.Order", b =>
                {
                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.OrderStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.ToDoItem", b =>
                {
                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.Project", null)
                        .WithMany("Items")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("CantinaUPT_API.Core.ProjectAggregate.User", b =>
                {
                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.Canteen", "Canteen")
                        .WithMany()
                        .HasForeignKey("CanteenId");

                    b.HasOne("CantinaUPT_API.Core.ProjectAggregate.UserRoles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Canteen");

                    b.Navigation("Role");
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
