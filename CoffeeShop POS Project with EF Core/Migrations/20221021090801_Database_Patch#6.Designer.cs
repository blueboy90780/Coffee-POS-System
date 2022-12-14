// <auto-generated />
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
    [Migration("20221021090801_Database_Patch#6")]
    partial class Database_Patch6
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

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.CustomerOrder", b =>
                {
                    b.Property<int>("CustomerOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductPropertiesId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerOrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductPropertiesId");

                    b.ToTable("Customer Order Menu");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
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

                    b.HasIndex("CategoryId");

                    b.ToTable("Product Catalogue");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductProperties", b =>
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

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.CustomerOrder", b =>
                {
                    b.HasOne("CoffeeShop_POS_Project_with_EF_Core.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductProperties", "ProductProperties")
                        .WithMany()
                        .HasForeignKey("ProductPropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductProperties");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.Product", b =>
                {
                    b.HasOne("CoffeeShop_POS_Project_with_EF_Core.Domain.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CoffeeShop_POS_Project_with_EF_Core.Domain.ProductProperties", b =>
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
