﻿// <auto-generated />
using System;
using Coffee_Shop_POS_System___EF_Core_6._0;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coffee_Shop_POS_System___EF_Core_6._0.Migrations
{
    [DbContext(typeof(DatabaseModel))]
    [Migration("20221022081820_Patch#2")]
    partial class Patch2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Coffee_Shop_POS_System___EF_Core_6._0.Domain.Categories", b =>
                {
                    b.Property<int>("CategoriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IceAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoriesId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Coffee_Shop_POS_System___EF_Core_6._0.Domain.CustomerOrder", b =>
                {
                    b.Property<int>("CustomerOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductPropertiesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerOrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductPropertiesId");

                    b.ToTable("Customer Order Menu");
                });

            modelBuilder.Entity("Coffee_Shop_POS_System___EF_Core_6._0.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriesId")
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

                    b.HasKey("ProductId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("Product Catalogue");
                });

            modelBuilder.Entity("Coffee_Shop_POS_System___EF_Core_6._0.Domain.ProductProperties", b =>
                {
                    b.Property<int>("ProductPropertiesId")
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

                    b.HasKey("ProductPropertiesId");

                    b.HasIndex("ProductId");

                    b.ToTable("Product Properties");
                });

            modelBuilder.Entity("Coffee_Shop_POS_System___EF_Core_6._0.Domain.CustomerOrder", b =>
                {
                    b.HasOne("Coffee_Shop_POS_System___EF_Core_6._0.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Coffee_Shop_POS_System___EF_Core_6._0.Domain.ProductProperties", "ProductProperties")
                        .WithMany()
                        .HasForeignKey("ProductPropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductProperties");
                });

            modelBuilder.Entity("Coffee_Shop_POS_System___EF_Core_6._0.Domain.Product", b =>
                {
                    b.HasOne("Coffee_Shop_POS_System___EF_Core_6._0.Domain.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Coffee_Shop_POS_System___EF_Core_6._0.Domain.ProductProperties", b =>
                {
                    b.HasOne("Coffee_Shop_POS_System___EF_Core_6._0.Domain.Product", "Product")
                        .WithMany("ProductVariantsList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Coffee_Shop_POS_System___EF_Core_6._0.Domain.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Coffee_Shop_POS_System___EF_Core_6._0.Domain.Product", b =>
                {
                    b.Navigation("ProductVariantsList");
                });
#pragma warning restore 612, 618
        }
    }
}
