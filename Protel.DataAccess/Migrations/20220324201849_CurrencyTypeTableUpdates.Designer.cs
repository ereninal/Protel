﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Protel.DataAccess.Context;

namespace Protel.DataAccess.Migrations
{
    [DbContext(typeof(ProtelContext))]
    [Migration("20220324201849_CurrencyTypeTableUpdates")]
    partial class CurrencyTypeTableUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Protel.DataAccess.Entities.CurrencyChangeInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Change")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CurrencyTypeId")
                        .HasColumnType("integer");

                    b.Property<long?>("CurrencyTypeId1")
                        .HasColumnType("bigint");

                    b.Property<decimal>("CurrentRate")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyTypeId1");

                    b.ToTable("CurrencyChangeInfos");
                });

            modelBuilder.Entity("Protel.DataAccess.Entities.CurrencyInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CurrencyTypeId")
                        .HasColumnType("integer");

                    b.Property<long?>("CurrencyTypeId1")
                        .HasColumnType("bigint");

                    b.Property<decimal>("CurrentRate")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyTypeId1");

                    b.ToTable("CurrencyInfo");
                });

            modelBuilder.Entity("Protel.DataAccess.Entities.CurrencyType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("text");

                    b.Property<string>("EngName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("TrName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Protel.DataAccess.Entities.CurrencyChangeInfo", b =>
                {
                    b.HasOne("Protel.DataAccess.Entities.CurrencyType", "CurrencyType")
                        .WithMany("CurrencyChangeInfos")
                        .HasForeignKey("CurrencyTypeId1");

                    b.Navigation("CurrencyType");
                });

            modelBuilder.Entity("Protel.DataAccess.Entities.CurrencyInfo", b =>
                {
                    b.HasOne("Protel.DataAccess.Entities.CurrencyType", "CurrencyType")
                        .WithMany("CurrencyInfos")
                        .HasForeignKey("CurrencyTypeId1");

                    b.Navigation("CurrencyType");
                });

            modelBuilder.Entity("Protel.DataAccess.Entities.CurrencyType", b =>
                {
                    b.Navigation("CurrencyChangeInfos");

                    b.Navigation("CurrencyInfos");
                });
#pragma warning restore 612, 618
        }
    }
}