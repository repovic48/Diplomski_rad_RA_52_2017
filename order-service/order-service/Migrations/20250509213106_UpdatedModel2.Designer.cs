﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using order_service.DBContext;

#nullable disable

namespace order_service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250509213106_UpdatedModel2")]
    partial class UpdatedModel2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("order_service.Model.Item", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("Orderid")
                        .HasColumnType("text");

                    b.Property<string>("food")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("order_id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Orderid");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("order_service.Model.Order", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("customer_id")
                        .HasColumnType("text");

                    b.Property<DateTime>("date_of_creation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("total_price")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("order_service.Model.Item", b =>
                {
                    b.HasOne("order_service.Model.Order", null)
                        .WithMany("items")
                        .HasForeignKey("Orderid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("order_service.Model.Order", b =>
                {
                    b.Navigation("items");
                });
#pragma warning restore 612, 618
        }
    }
}
