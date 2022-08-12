﻿// <auto-generated />
using System;
using EfProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfProject.Migrations
{
    [DbContext(typeof(EfProjectContext))]
    [Migration("20220812014310_Seeding Initial Data")]
    partial class SeedingInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.7.22376.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfProject.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb2abee8-4434-4880-8d1a-90e3256df891"),
                            Name = "To-Do"
                        },
                        new
                        {
                            Id = new Guid("34171682-a1aa-4677-8bb9-1c8fc391d324"),
                            Name = "Personal"
                        });
                });

            modelBuilder.Entity("EfProject.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5d2ac5a7-067b-46c0-9ae3-970da83eb9cb"),
                            CategoryId = new Guid("fb2abee8-4434-4880-8d1a-90e3256df891"),
                            CreatedAt = new DateTime(2022, 8, 11, 19, 43, 9, 974, DateTimeKind.Local).AddTicks(3951),
                            Priority = 2,
                            Title = "Bills"
                        },
                        new
                        {
                            Id = new Guid("4ec00255-a535-4681-a3a2-6b531d7dfeaa"),
                            CategoryId = new Guid("34171682-a1aa-4677-8bb9-1c8fc391d324"),
                            CreatedAt = new DateTime(2022, 8, 11, 19, 43, 9, 974, DateTimeKind.Local).AddTicks(3966),
                            Priority = 0,
                            Title = "See Movie"
                        });
                });

            modelBuilder.Entity("EfProject.Models.Task", b =>
                {
                    b.HasOne("EfProject.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EfProject.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
