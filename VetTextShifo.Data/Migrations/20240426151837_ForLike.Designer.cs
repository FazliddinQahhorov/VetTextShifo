﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VetTextShifo.Data.DbContexts;

#nullable disable

namespace VetTextShifo.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240426151837_ForLike")]
    partial class ForLike
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VetTextShifo.Domain.Entities.Admin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.Attachments.AttachmentModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductEngId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductRusId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductUzbId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("ProductEngId");

                    b.HasIndex("ProductRusId");

                    b.HasIndex("ProductUzbId");

                    b.ToTable("AttachmentProducts");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Catigories");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProductEngid")
                        .HasColumnType("integer");

                    b.Property<string>("ProductModel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProductRusid")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductUzbid")
                        .HasColumnType("integer");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("ProductEngid");

                    b.HasIndex("ProductRusid");

                    b.HasIndex("ProductUzbid");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Likes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("CustomerIP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Customerid")
                        .HasColumnType("integer");

                    b.Property<string>("ProductModelName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("Customerid");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Location", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Postcode")
                        .HasColumnType("bigint");

                    b.Property<string>("Sity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.NewsModel.NewsModelRus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("NewsRus");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.NewsModelEng", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("NewsEng");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.NewsModelUzb", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("NewsUzb");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductEng", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExtraDevices")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GuaranteePeriod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LikeCount")
                        .HasColumnType("integer");

                    b.Property<string>("MadeIn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("PaymentContract")
                        .HasColumnType("boolean");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Produced")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Service")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.HasIndex("ModelName")
                        .IsUnique();

                    b.ToTable("ProductsEng");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductRus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExtraDevices")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GuaranteePeriod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LikeCount")
                        .HasColumnType("integer");

                    b.Property<string>("MadeIn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("PaymentContract")
                        .HasColumnType("boolean");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Produced")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Service")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.HasIndex("ModelName")
                        .IsUnique();

                    b.ToTable("ProductsRus");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductUzb", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExtraDevices")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GuaranteePeriod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LikeCount")
                        .HasColumnType("integer");

                    b.Property<string>("MadeIn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("PaymentContract")
                        .HasColumnType("boolean");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Produced")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Service")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.HasIndex("ModelName")
                        .IsUnique();

                    b.ToTable("ProductsUzb");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.Users.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomerIp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.Users.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.Attachments.AttachmentModel", b =>
                {
                    b.HasOne("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductEng", null)
                        .WithMany("attachments")
                        .HasForeignKey("ProductEngId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductRus", null)
                        .WithMany("attachments")
                        .HasForeignKey("ProductRusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductUzb", null)
                        .WithMany("attachments")
                        .HasForeignKey("ProductUzbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Comment", b =>
                {
                    b.HasOne("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductEng", null)
                        .WithMany("comments")
                        .HasForeignKey("ProductEngid");

                    b.HasOne("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductRus", null)
                        .WithMany("comments")
                        .HasForeignKey("ProductRusid");

                    b.HasOne("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductUzb", null)
                        .WithMany("comments")
                        .HasForeignKey("ProductUzbid");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Likes", b =>
                {
                    b.HasOne("VetTextShifo.Domain.Entities.Users.Customer", null)
                        .WithMany("Likes")
                        .HasForeignKey("Customerid");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.Users.Order", b =>
                {
                    b.HasOne("VetTextShifo.Domain.Entities.Users.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductEng", b =>
                {
                    b.Navigation("attachments");

                    b.Navigation("comments");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductRus", b =>
                {
                    b.Navigation("attachments");

                    b.Navigation("comments");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.ProductDetails.Products.ProductUzb", b =>
                {
                    b.Navigation("attachments");

                    b.Navigation("comments");
                });

            modelBuilder.Entity("VetTextShifo.Domain.Entities.Users.Customer", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
