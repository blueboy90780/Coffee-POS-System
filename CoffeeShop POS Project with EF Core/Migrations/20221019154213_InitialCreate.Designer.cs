﻿// <auto-generated />
using System;
using CoffeeShop_POS_Project_with_EF_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    [DbContext(typeof(DatabaseModel))]
    [Migration("20221019154213_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IceAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ENname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductSize")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Recommended")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VNname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<float?>("Volume")
                        .HasColumnType("REAL");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Product", b =>
                {
                    b.HasOne("CoffeeShop_POS_Project_with_EF_Core.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
