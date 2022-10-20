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
    [Migration("20221020033017_ProductVariation_Patch#4")]
    partial class ProductVariation_Patch4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.Categories", b =>
                {
                    b.Property<int>("CategoriesId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IceAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoriesId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoriesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ENname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Recommended")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VNname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductVariants", b =>
                {
                    b.Property<int>("ProductVariantsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductSize")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Volume")
                        .HasColumnType("REAL");

                    b.HasKey("ProductVariantsId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVariants");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.Product", b =>
                {
                    b.HasOne("CoffeeShop_POS_Project_with_EF_Core.Domain.Categories", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoriesId");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductVariants", b =>
                {
                    b.HasOne("CoffeeShop_POS_Project_with_EF_Core.Domain.Product", "Product")
                        .WithMany("ProductVariantsList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.Product", b =>
                {
                    b.Navigation("ProductVariantsList");
                });
#pragma warning restore 612, 618
        }
    }
}
