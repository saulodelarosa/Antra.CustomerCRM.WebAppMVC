﻿// <auto-generated />
using System;
using CustomerCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerCRM.Infrastructure.Migrations
{
    [DbContext(typeof(CustomerCrmDbContext))]
    [Migration("20220803125326_AddProductsTableUpdated")]
    partial class AddProductsTableUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerCRM.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("Varchar(80)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("Varchar(15)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("Varchar(200)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CustomerCRM.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("Varchar(80)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("Varchar(15)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("TitleOfCourtesy")
                        .IsRequired()
                        .HasColumnType("Varchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CustomerCRM.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<int>("QuantityPerUnit")
                        .HasColumnType("int");

                    b.Property<int>("ReorderLevel")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.Property<int>("UnitsOnOrder")
                        .HasColumnType("int");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CustomerCRM.Core.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("CustomerCRM.Core.Entities.Shipper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Shipper");
                });

            modelBuilder.Entity("CustomerCRM.Core.Entities.Customer", b =>
                {
                    b.HasOne("CustomerCRM.Core.Entities.Region", "Region")
                        .WithMany("Customers")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("CustomerCRM.Core.Entities.Region", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
