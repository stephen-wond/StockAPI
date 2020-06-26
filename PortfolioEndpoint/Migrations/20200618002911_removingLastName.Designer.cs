﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioEndpoint.Data;

namespace PortfolioEndpoint.Migrations
{
    [DbContext(typeof(PortfolioEndpointContext))]
    [Migration("20200618002911_removingLastName")]
    partial class removingLastName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PortfolioEndpoint.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChangeAlert")
                        .HasColumnType("int");

                    b.Property<double>("InitialPrice")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("LastAlertPrice")
                        .HasColumnType("float");

                    b.Property<int>("SymbolId")
                        .HasColumnType("int");

                    b.Property<double?>("TargetPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StockId");

                    b.HasIndex("SymbolId");

                    b.HasIndex("UserId");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            StockId = 1,
                            ChangeAlert = 5,
                            InitialPrice = 1234.0,
                            IsActive = true,
                            LastAlertPrice = 1234.0,
                            SymbolId = 1,
                            TargetPrice = 1235.0,
                            UserId = 1
                        },
                        new
                        {
                            StockId = 2,
                            ChangeAlert = 5,
                            InitialPrice = 1234.0,
                            IsActive = true,
                            LastAlertPrice = 1234.0,
                            SymbolId = 2,
                            TargetPrice = 1235.0,
                            UserId = 1
                        },
                        new
                        {
                            StockId = 3,
                            ChangeAlert = 1,
                            InitialPrice = 4321.0,
                            IsActive = true,
                            LastAlertPrice = 4321.0,
                            SymbolId = 1,
                            TargetPrice = 4322.0,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("PortfolioEndpoint.Models.Symbol", b =>
                {
                    b.Property<int>("SymbolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ticker")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SymbolId");

                    b.ToTable("Symbols");

                    b.HasData(
                        new
                        {
                            SymbolId = 1,
                            Name = "Tesla",
                            Ticker = "TSLA"
                        },
                        new
                        {
                            SymbolId = 2,
                            Name = "PayPoint PLC",
                            Ticker = "PAY.L"
                        });
                });

            modelBuilder.Entity("PortfolioEndpoint.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastContact")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ExternalId = 0,
                            FirstName = "Carson",
                            LastContact = new DateTime(2020, 6, 18, 1, 29, 10, 226, DateTimeKind.Local).AddTicks(1982)
                        },
                        new
                        {
                            UserId = 2,
                            ExternalId = 0,
                            FirstName = "Meredith",
                            LastContact = new DateTime(2020, 6, 18, 1, 29, 10, 231, DateTimeKind.Local).AddTicks(311)
                        },
                        new
                        {
                            UserId = 3,
                            ExternalId = 0,
                            FirstName = "Arturo",
                            LastContact = new DateTime(2020, 6, 18, 1, 29, 10, 231, DateTimeKind.Local).AddTicks(492)
                        });
                });

            modelBuilder.Entity("PortfolioEndpoint.Models.Stock", b =>
                {
                    b.HasOne("PortfolioEndpoint.Models.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioEndpoint.Models.User", null)
                        .WithMany("Stocks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}