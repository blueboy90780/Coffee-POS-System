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
    [DbContext(typeof(MenuContext))]
    [Migration("20221020060150_ProductVariation_Patch#5")]
    partial class ProductVariation_Patch5
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

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductCatalogue", b =>
                {
                    b.Property<int>("ProductCatalogueId")
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
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("ProductCatalogueId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("ProductCatalogue");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductVariants", b =>
                {
                    b.Property<int>("ProductVariantsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductCatalogueId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductSize")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Volume")
                        .HasColumnType("REAL");

                    b.HasKey("ProductVariantsId");

                    b.HasIndex("ProductCatalogueId");

                    b.ToTable("ProductVariants");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductCatalogue", b =>
                {
                    b.HasOne("CoffeeShop_POS_Project_with_EF_Core.Domain.Categories", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoriesId");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductVariants", b =>
                {
                    b.HasOne("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductCatalogue", "ProductCatalogue")
                        .WithMany("ProductVariantsList")
                        .HasForeignKey("ProductCatalogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCatalogue");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductCatalogue", b =>
                {
                    b.Navigation("ProductVariantsList");
                });
#pragma warning restore 612, 618
        }
    }
}
