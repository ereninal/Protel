// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Protel.DataAccess.Context;

namespace Protel.DataAccess.Migrations
{
    [DbContext(typeof(ProtelContext))]
    partial class ProtelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Change")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CurrencyTypeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("CurrentRate")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyTypeId");

                    b.ToTable("CurrencyChangeInfos");
                });

            modelBuilder.Entity("Protel.DataAccess.Entities.CurrencyInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("BanknoteBuying")
                        .HasColumnType("numeric");

                    b.Property<decimal>("BanknoteSelling")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CurrencyTypeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("ForexBuying")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ForexSelling")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyTypeId");

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

            modelBuilder.Entity("Protel.DataAccess.Entities.WorkWithCurrency", b =>
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

                    b.ToTable("WorkWithCurrencies");
                });

            modelBuilder.Entity("Protel.DataAccess.Entities.CurrencyChangeInfo", b =>
                {
                    b.HasOne("Protel.DataAccess.Entities.CurrencyType", "CurrencyType")
                        .WithMany("CurrencyChangeInfos")
                        .HasForeignKey("CurrencyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrencyType");
                });

            modelBuilder.Entity("Protel.DataAccess.Entities.CurrencyInfo", b =>
                {
                    b.HasOne("Protel.DataAccess.Entities.CurrencyType", "CurrencyType")
                        .WithMany("CurrencyInfos")
                        .HasForeignKey("CurrencyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
