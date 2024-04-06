﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Travelagency.Infrastructure;

#nullable disable

namespace Travelagency.Infrastructure.Migrations
{
    [DbContext(typeof(GeneralDbContext))]
    partial class GeneralDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TravelAgency.Domain.Aggregates.CutomerAggregate.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CustomerType")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customer", "TravelAgency");
                });

            modelBuilder.Entity("TravelAgency.Domain.Aggregates.InvoiceAggregate.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Expenditures")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoice", "TravelAgency");
                });

            modelBuilder.Entity("TravelAgency.Domain.Aggregates.PayAggregate.Pay", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PayType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Pay", "TravelAgency");
                });

            modelBuilder.Entity("TravelAgency.Domain.Aggregates.Trip.Trip", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("CancelationType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DepartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<int>("IsCancelType")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TripType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Trip", "TravelAgency");
                });

            modelBuilder.Entity("TravelAgency.Domain.Aggregates.InvoiceAggregate.Invoice", b =>
                {
                    b.HasOne("TravelAgency.Domain.Aggregates.CutomerAggregate.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgency.Domain.Aggregates.PayAggregate.Pay", b =>
                {
                    b.HasOne("TravelAgency.Domain.Aggregates.InvoiceAggregate.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgency.Domain.Aggregates.Trip.Trip", b =>
                {
                    b.HasOne("TravelAgency.Domain.Aggregates.InvoiceAggregate.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
