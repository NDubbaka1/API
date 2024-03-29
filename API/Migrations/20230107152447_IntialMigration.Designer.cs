﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [Migration("20230107152447_IntialMigration")]
    partial class IntialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Model.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Long")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Pop")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("API.Model.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WalkdiffcultyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("lenght")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RegionID");

                    b.HasIndex("WalkdiffcultyID");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("API.Model.Domain.WalkDiffculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WalkDiffculty");
                });

            modelBuilder.Entity("API.Model.Domain.Walk", b =>
                {
                    b.HasOne("API.Model.Domain.Region", "Region")
                        .WithMany("Walks")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Domain.WalkDiffculty", "WalkDiffculty")
                        .WithMany()
                        .HasForeignKey("WalkdiffcultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("WalkDiffculty");
                });

            modelBuilder.Entity("API.Model.Domain.Region", b =>
                {
                    b.Navigation("Walks");
                });
#pragma warning restore 612, 618
        }
    }
}
