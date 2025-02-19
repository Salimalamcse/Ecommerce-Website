﻿// <auto-generated />
using Ecommerce_Website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce_Website.Migrations
{
    [DbContext(typeof(myContext))]
    [Migration("20250203145342_customerMigration")]
    partial class customerMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce_Website.Models.Admin", b =>
                {
                    b.Property<int>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("admin_id"));

                    b.Property<string>("admin_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_id");

                    b.ToTable("tbl_admin");
                });

            modelBuilder.Entity("Ecommerce_Website.Models.Customer", b =>
                {
                    b.Property<int>("customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customer_Id"));

                    b.Property<string>("customer_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_coutory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customer_Id");

                    b.ToTable("tbl_customer");
                });
#pragma warning restore 612, 618
        }
    }
}
