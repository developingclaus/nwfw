using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using nwfw.Models;

namespace nwfw.Migrations
{
    [DbContext(typeof(NwfwContext))]
    partial class NwfwContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("nwfw.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CustomerCompanyName");

                    b.Property<string>("CustomerFirstName");

                    b.Property<string>("CustomerLastName");

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("nwfw.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("FulfillDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("NwfwOrderId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int?>("OrderStatusId");

                    b.Property<int?>("OrderTypeId");

                    b.Property<int?>("VendorId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("nwfw.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<double>("DiscountPercent");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("nwfw.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("OrderStatusName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("nwfw.Models.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("OrderTypeName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("nwfw.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<double>("ProductBasePrice");

                    b.Property<string>("ProductName");

                    b.Property<int?>("ProductTypeId");

                    b.Property<int?>("WoodId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("nwfw.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ProductTypeName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("nwfw.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("VendorCompanyName");

                    b.Property<string>("VendorFirstName");

                    b.Property<string>("VendorLastName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("nwfw.Models.Wood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("WoodName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("nwfw.Models.Order", b =>
                {
                    b.HasOne("nwfw.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("nwfw.Models.OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId");

                    b.HasOne("nwfw.Models.OrderType")
                        .WithMany()
                        .HasForeignKey("OrderTypeId");

                    b.HasOne("nwfw.Models.Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId");
                });

            modelBuilder.Entity("nwfw.Models.OrderItem", b =>
                {
                    b.HasOne("nwfw.Models.Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("nwfw.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("nwfw.Models.Product", b =>
                {
                    b.HasOne("nwfw.Models.ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId");

                    b.HasOne("nwfw.Models.Wood")
                        .WithMany()
                        .HasForeignKey("WoodId");
                });
        }
    }
}
