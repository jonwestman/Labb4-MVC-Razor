﻿// <auto-generated />
using System;
using Labb4_MVC_Razor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb4_MVC_Razor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230616110751_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb4_MVC_Razor.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Miguel Cervantes",
                            Description = "The journey of a madman",
                            Title = "Don Quijote"
                        },
                        new
                        {
                            BookId = 2,
                            Author = "Daniel Defoe",
                            Description = "The tale of a shipwrecked man",
                            Title = "Robinson Crusoe"
                        },
                        new
                        {
                            BookId = 3,
                            Author = "J.K Rowling",
                            Description = "The tale of young wizard",
                            Title = "Harry Potter"
                        },
                        new
                        {
                            BookId = 4,
                            Author = "J.R.R Tolkien",
                            Description = "Charachters come together to fight evil",
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            BookId = 5,
                            Author = "Leo Tolstoy",
                            Description = "We follow aristocratic families in Russia during the Napoleonic wars",
                            Title = "War and Peace"
                        });
                });

            modelBuilder.Entity("Labb4_MVC_Razor.Models.BookList", b =>
                {
                    b.Property<int>("BookListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookListId"));

                    b.Property<int>("FK_BookId")
                        .HasColumnType("int");

                    b.Property<int>("FK_CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookListId");

                    b.HasIndex("FK_BookId");

                    b.HasIndex("FK_CustomerId");

                    b.ToTable("BookLists");
                });

            modelBuilder.Entity("Labb4_MVC_Razor.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "Kyrklägdan 18",
                            Email = "jon@mail.com",
                            Firstname = "Jon",
                            Lastname = "Westman",
                            Phone = "0701234567"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "Kyrklägdan 18",
                            Email = "malin@mail.com",
                            Firstname = "Malin",
                            Lastname = "Eriksson",
                            Phone = "0701234568"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "Svenssonvägen 1",
                            Email = "sven@mail.com",
                            Firstname = "Sven",
                            Lastname = "Svensson",
                            Phone = "0701234569"
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "Perssongatan 1",
                            Email = "ake@mail.com",
                            Firstname = "Åke",
                            Lastname = "Persson",
                            Phone = "0701234560"
                        },
                        new
                        {
                            CustomerId = 5,
                            Address = "Kyrkogatan 1",
                            Email = "lisa@mail.com",
                            Firstname = "Lisa",
                            Lastname = "Nilsson",
                            Phone = "0701234561"
                        });
                });

            modelBuilder.Entity("Labb4_MVC_Razor.Models.BookList", b =>
                {
                    b.HasOne("Labb4_MVC_Razor.Models.Book", "book")
                        .WithMany()
                        .HasForeignKey("FK_BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb4_MVC_Razor.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("FK_CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("customer");
                });
#pragma warning restore 612, 618
        }
    }
}
