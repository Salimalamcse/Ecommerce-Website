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
    [Migration("20250206222456_updated-category")]
    partial class updatedcategory
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

            modelBuilder.Entity("Ecommerce_Website.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cart_id")
                        .HasColumnType("int");

                    b.Property<int>("cart_status")
                        .HasColumnType("int");

                    b.Property<int>("cus_id")
                        .HasColumnType("int");

                    b.Property<int>("cust_id")
                        .HasColumnType("int");

                    b.Property<int>("prod_id")
                        .HasColumnType("int");

                    b.Property<int>("product_quntity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_cart");
                });

            modelBuilder.Entity("Ecommerce_Website.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"));

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("tbl_category");
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

            modelBuilder.Entity("Ecommerce_Website.Models.Faqs", b =>
                {
                    b.Property<int>("faq_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("faq_Id"));

                    b.Property<string>("fqs_answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fqs_question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("faq_Id");

                    b.ToTable("tbl_faqs");
                });

            modelBuilder.Entity("Ecommerce_Website.Models.Feedback", b =>
                {
                    b.Property<int>("feedback_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("feedback_id"));

                    b.Property<string>("user_message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("feedback_id");

                    b.ToTable("tbl_feedback");
                });

            modelBuilder.Entity("Ecommerce_Website.Models.Product", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("product_id"));

                    b.Property<int>("cat_id")
                        .HasColumnType("int");

                    b.Property<string>("product_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("product_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("product_image")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("product_id");

                    b.HasIndex("cat_id");

                    b.ToTable("tbl_product");
                });

            modelBuilder.Entity("Ecommerce_Website.Models.Product", b =>
                {
                    b.HasOne("Ecommerce_Website.Models.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("cat_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ecommerce_Website.Models.Category", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
