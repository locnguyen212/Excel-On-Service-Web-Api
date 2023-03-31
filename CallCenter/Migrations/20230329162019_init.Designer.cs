﻿// <auto-generated />
using System;
using CallCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CallCenter.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230329162019_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CallCenter.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Email = "superadmin@gmail.com",
                            Password = "$2b$10$WdSJuVJt9HAPbapmoiNgf.TuDYeawnedE2o/vodTPCxnS0Dh.wPeq",
                            Phone = "123",
                            Role = "super admin",
                            Username = "Super admin"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 2,
                            Email = "admin11@gmail.com",
                            Password = "$2b$10$QjzVM9Pxb.GGCd.u9W3cOOeLNxRwrV0z8cgDbB62rNoxi2u4Z/E9O",
                            Phone = "123",
                            Role = "admin 1",
                            Username = "Admin1 1"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 3,
                            Email = "admin21@gmail.com",
                            Password = "$2b$10$iPCqcg7Pzes0Dz28tvsqq.ZGOS/Oy0jhSQVbBFNSTzhlmcQtwN6V.",
                            Phone = "123",
                            Role = "admin 2",
                            Username = "Admin2 1"
                        },
                        new
                        {
                            Id = 4,
                            Email = "customer1@gmail.com",
                            Password = "$2b$10$/Cjs5jSYkAklLCr6Of2CyeLek9FRXHLvgXfWFVEAzBcR5kF2RLqkG",
                            Phone = "123",
                            Role = "customer",
                            Username = "Customer 1"
                        });
                });

            modelBuilder.Entity("CallCenter.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 4,
                            Description = "Description",
                            Name = "Client 1"
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 4,
                            Description = "Description",
                            Name = "Client 2"
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 4,
                            Description = "Description",
                            Name = "Client 3"
                        });
                });

            modelBuilder.Entity("CallCenter.Models.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StaffId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("CallCenter.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Department 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Department 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Department 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Department 4"
                        });
                });

            modelBuilder.Entity("CallCenter.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Invoice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("StaffId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 4,
                            Duration = 20,
                            StaffId = 2,
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 4,
                            Duration = 30,
                            StaffId = 3,
                            Status = true
                        });
                });

            modelBuilder.Entity("CallCenter.Models.OrderClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StaffId");

                    b.ToTable("OrderClients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "abc",
                            OrderId = 2,
                            StaffId = 3
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 2,
                            StaffId = 3
                        });
                });

            modelBuilder.Entity("CallCenter.Models.OrderClientDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderClientId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderClientDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "abc",
                            OrderClientId = 2,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "abc",
                            OrderClientId = 2,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("CallCenter.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 4,
                            Name = "Product 1"
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 4,
                            Name = "Product 2"
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 4,
                            Name = "Product 3"
                        });
                });

            modelBuilder.Entity("CallCenter.Models.ProductClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductClients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            ClientId = 2,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 4,
                            ClientId = 2,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 5,
                            ClientId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 6,
                            ClientId = 3,
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("CallCenter.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Inbound",
                            Price = 4000.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Outbound",
                            Price = 5000.0
                        });
                });

            modelBuilder.Entity("CallCenter.Models.Account", b =>
                {
                    b.HasOne("CallCenter.Models.Department", "Department")
                        .WithMany("Accounts")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CallCenter.Models.Client", b =>
                {
                    b.HasOne("CallCenter.Models.Account", "Customer")
                        .WithMany("Clients")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CallCenter.Models.Complaint", b =>
                {
                    b.HasOne("CallCenter.Models.Order", "Order")
                        .WithMany("Complaints")
                        .HasForeignKey("OrderId");

                    b.HasOne("CallCenter.Models.Account", "Staff")
                        .WithMany("Complaints")
                        .HasForeignKey("StaffId");

                    b.Navigation("Order");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("CallCenter.Models.Order", b =>
                {
                    b.HasOne("CallCenter.Models.Account", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("CallCenter.Models.Service", "Service")
                        .WithMany("Orders")
                        .HasForeignKey("ServiceId");

                    b.HasOne("CallCenter.Models.Account", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("Customer");

                    b.Navigation("Service");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("CallCenter.Models.OrderClient", b =>
                {
                    b.HasOne("CallCenter.Models.Order", "Order")
                        .WithMany("OrderClients")
                        .HasForeignKey("OrderId");

                    b.HasOne("CallCenter.Models.Account", "Staff")
                        .WithMany("OrderClients")
                        .HasForeignKey("StaffId");

                    b.Navigation("Order");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("CallCenter.Models.OrderClientDetail", b =>
                {
                    b.HasOne("CallCenter.Models.OrderClient", "OrderClient")
                        .WithMany("OrderClientDetails")
                        .HasForeignKey("OrderClientId");

                    b.HasOne("CallCenter.Models.Product", "Product")
                        .WithMany("OrderClientDetails")
                        .HasForeignKey("ProductId");

                    b.Navigation("OrderClient");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CallCenter.Models.Product", b =>
                {
                    b.HasOne("CallCenter.Models.Account", "Customer")
                        .WithMany("Products")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CallCenter.Models.ProductClient", b =>
                {
                    b.HasOne("CallCenter.Models.Client", "Client")
                        .WithMany("ProductClients")
                        .HasForeignKey("ClientId");

                    b.HasOne("CallCenter.Models.Product", "Product")
                        .WithMany("ProductClients")
                        .HasForeignKey("ProductId");

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CallCenter.Models.Account", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Complaints");

                    b.Navigation("OrderClients");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("CallCenter.Models.Client", b =>
                {
                    b.Navigation("ProductClients");
                });

            modelBuilder.Entity("CallCenter.Models.Department", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("CallCenter.Models.Order", b =>
                {
                    b.Navigation("Complaints");

                    b.Navigation("OrderClients");
                });

            modelBuilder.Entity("CallCenter.Models.OrderClient", b =>
                {
                    b.Navigation("OrderClientDetails");
                });

            modelBuilder.Entity("CallCenter.Models.Product", b =>
                {
                    b.Navigation("OrderClientDetails");

                    b.Navigation("ProductClients");
                });

            modelBuilder.Entity("CallCenter.Models.Service", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}