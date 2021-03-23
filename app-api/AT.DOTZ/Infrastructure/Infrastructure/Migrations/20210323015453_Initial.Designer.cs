﻿// <auto-generated />
using System;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20210323015453_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Dotz")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"),
                            Active = true,
                            Balance = 10000m,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 709, DateTimeKind.Local).AddTicks(4920),
                            Dotz = 1000,
                            Mail = "ordep@hotmail.com",
                            Name = "Ordep",
                            Number = "1679951256"
                        },
                        new
                        {
                            Id = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f20"),
                            Active = true,
                            Balance = 20000m,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 713, DateTimeKind.Local).AddTicks(427),
                            Dotz = 2000,
                            Mail = "Atram@hotmail.com",
                            Name = "Atram",
                            Number = "902183848"
                        });
                });

            modelBuilder.Entity("Entities.Entities.AccountCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountCard");

                    b.HasData(
                        new
                        {
                            Id = new Guid("31e74709-ab02-424c-a189-10521e936de3"),
                            AccountId = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"),
                            Active = true,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 715, DateTimeKind.Local).AddTicks(9483),
                            Number = "5555-6666-7777-8888",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("fcea9cec-489b-46cd-94ad-c8050c993872"),
                            AccountId = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"),
                            Active = true,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 716, DateTimeKind.Local).AddTicks(3332),
                            Number = "6666-7777-8888-5555",
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("a0a1478f-0931-4c03-a210-1ac9c1680df9"),
                            AccountId = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"),
                            Active = true,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 716, DateTimeKind.Local).AddTicks(3472),
                            Number = "7777-8888-5555-6666",
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("467acd0b-23d7-421d-9d18-a81aa856b77b"),
                            AccountId = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f20"),
                            Active = true,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 716, DateTimeKind.Local).AddTicks(3485),
                            Number = "1111-2222-3333-4444",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Entities.Entities.AccountExtract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DocumentCode")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Dotz")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountExtract");

                    b.HasData(
                        new
                        {
                            Id = new Guid("08f988e7-e0c3-46d5-8b84-5f1329b5bf77"),
                            AccountId = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"),
                            Amount = 1000m,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 716, DateTimeKind.Local).AddTicks(5494),
                            DocumentCode = "123456789",
                            Dotz = 100,
                            Observation = "",
                            Peso = 10,
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("330952e4-bfd2-476b-8621-a5a435cfc14b"),
                            AccountId = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"),
                            Amount = 2000m,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(2990),
                            DocumentCode = "234567891",
                            Dotz = 200,
                            Observation = "Depositao A",
                            Peso = 10,
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("02fcb756-3413-4f28-b863-6d5de9231117"),
                            AccountId = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"),
                            Amount = 1500m,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(3182),
                            DocumentCode = "345678912",
                            Dotz = 150,
                            Observation = "Deposito B",
                            Peso = 10,
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("cb0ffde5-4bcd-4509-95e7-ff002407f678"),
                            AccountId = new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"),
                            Amount = 100m,
                            Data = new DateTime(2021, 3, 22, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(3197),
                            DocumentCode = "987654321",
                            Dotz = 10,
                            Observation = "Pagamento B",
                            Peso = 10,
                            Type = 2
                        });
                });

            modelBuilder.Entity("Entities.Entities.AccountCard", b =>
                {
                    b.HasOne("Entities.Entities.Account", "Account")
                        .WithMany("AccountCard")
                        .HasForeignKey("AccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Entities.AccountExtract", b =>
                {
                    b.HasOne("Entities.Entities.Account", "Account")
                        .WithMany("AccountExtract")
                        .HasForeignKey("AccountId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}