﻿// <auto-generated />
using System;
using FlightBookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightBookingAPI.Migrations
{
    [DbContext(typeof(FlightBookingDbContext))]
    [Migration("20210614193826_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightBookingAPI.Models.Airline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AirlineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstrumentUsed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.AirlineSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AirlineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BusinessClassPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FlightNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstrumentUsed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NonBusinessClassPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SheduleDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TotalSeats")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AirlineId");

                    b.ToTable("AirlineSchedules");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AirlineScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BookedSeats")
                        .HasColumnType("int");

                    b.Property<decimal>("BookingAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ClassType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MealType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OrginalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AirlineScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.DiscountCoupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CouponCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DiscountCoupons");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.Passenger", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.ScheduleSeats", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("AirlineScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<string>("SeatName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AirlineScheduleId");

                    b.ToTable("ScheduleSeats");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.AirlineSchedule", b =>
                {
                    b.HasOne("FlightBookingAPI.Models.Airline", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineId");

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.Booking", b =>
                {
                    b.HasOne("FlightBookingAPI.Models.AirlineSchedule", "AirlineSchedule")
                        .WithMany()
                        .HasForeignKey("AirlineScheduleId");

                    b.HasOne("FlightBookingAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("AirlineSchedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.Passenger", b =>
                {
                    b.HasOne("FlightBookingAPI.Models.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("FlightBookingAPI.Models.ScheduleSeats", b =>
                {
                    b.HasOne("FlightBookingAPI.Models.AirlineSchedule", "AirlineSchedule")
                        .WithMany()
                        .HasForeignKey("AirlineScheduleId");

                    b.Navigation("AirlineSchedule");
                });
#pragma warning restore 612, 618
        }
    }
}
