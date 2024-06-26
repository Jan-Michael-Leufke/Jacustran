﻿// <auto-generated />
using System;
using Jacustran.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jacustran.Persistence.Migrations
{
    [DbContext(typeof(JacustranDbContext))]
    [Migration("20240329153857_moreSeedData")]
    partial class moreSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jacustran.Domain.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Jacustran.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Jacustran.Domain.Shared.Town", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Town");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Town");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = new Guid("ffd3d609-d754-4feb-8acd-c4f9ff13adf4"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ojiro is mostly a mountainous area and prides itself as the homeland of Wagyu cattle.",
                            ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ojiro",
                            Population = 2200
                        });
                });

            modelBuilder.Entity("Jacustran.Domain.Spots.Spot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid?>("TownId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Spots");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af871625-d754-4feb-8acd-c4f9ff13ba96"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "An ancient Temple with a stunning View over Kyoto.",
                            ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kiyomizu",
                            Rating = 0,
                            TownId = new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            Id = new Guid("9384adfa-d754-4feb-8acd-c4f9ff13ba96"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A Neighbourhood with a certain melancholic feel.",
                            ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Oyamazaki",
                            Rating = 0,
                            TownId = new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            Id = new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Colorful and with antique wooden structures ",
                            ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kinkakuji Temple",
                            Rating = 0,
                            TownId = new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            Id = new Guid("8374adda-d754-4feb-8acd-c4f9ff13ba96"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "It´s a train station but also much more than that.",
                            ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Umeda",
                            Rating = 0,
                            TownId = new Guid("ac338e7a-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            Id = new Guid("8374a227-d754-4feb-8acd-c4f9ff13fa34"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A place to take a relaxing hot bath.",
                            ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ojiron-Onsen",
                            Rating = 0,
                            TownId = new Guid("ffd3d609-d754-4feb-8acd-c4f9ff13adf4")
                        });
                });

            modelBuilder.Entity("Jacustran.Domain.Cities.City", b =>
                {
                    b.HasBaseType("Jacustran.Domain.Shared.Town");

                    b.Property<bool>("IsImportantCity")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("City");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kyoto is the culural capital of japan",
                            ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kyoto",
                            Population = 1475000,
                            IsImportantCity = true
                        },
                        new
                        {
                            Id = new Guid("fdbead28-d754-4feb-8acd-c4f9ff13ba96"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Tokyo is a megacity",
                            ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tokyo",
                            Population = 13960000,
                            IsImportantCity = true
                        },
                        new
                        {
                            Id = new Guid("ac338e7a-d754-4feb-8acd-c4f9ff13ba96"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Osaka lies in the kanto area",
                            ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Osaka",
                            Population = 2691000,
                            IsImportantCity = true
                        });
                });

            modelBuilder.Entity("Jacustran.Domain.Products.Product", b =>
                {
                    b.HasOne("Jacustran.Domain.Categories.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Jacustran.Domain.Spots.Spot", b =>
                {
                    b.HasOne("Jacustran.Domain.Shared.Town", "Town")
                        .WithMany("Spots")
                        .HasForeignKey("TownId");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Jacustran.Domain.Categories.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Jacustran.Domain.Shared.Town", b =>
                {
                    b.Navigation("Spots");
                });
#pragma warning restore 612, 618
        }
    }
}
