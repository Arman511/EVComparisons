﻿// <auto-generated />
using EVComparisons.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EVComparisons.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EVComparisons.Models.Cars", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("BatteryCapacity")
                        .HasColumnType("float");

                    b.Property<int>("CargoVolume")
                        .HasColumnType("int");

                    b.Property<int>("Drive")
                        .HasColumnType("int");

                    b.Property<int>("Efficiency")
                        .HasColumnType("int");

                    b.Property<int>("FastChargePort")
                        .HasColumnType("int");

                    b.Property<int>("FastChargePower")
                        .HasColumnType("int");

                    b.Property<int>("FastChargeTime")
                        .HasColumnType("int");

                    b.Property<int>("FastPortLocation")
                        .HasColumnType("int");

                    b.Property<int>("FullPrice")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Made")
                        .HasColumnType("int");

                    b.Property<string>("Maker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxPayload")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NaughtTo60")
                        .HasColumnType("float");

                    b.Property<int>("NormalChargePort")
                        .HasColumnType("int");

                    b.Property<int>("NormalChargePower")
                        .HasColumnType("int");

                    b.Property<int>("NormalChargeTime")
                        .HasColumnType("int");

                    b.Property<int>("NormalPortLocation")
                        .HasColumnType("int");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<bool>("RoofRails")
                        .HasColumnType("bit");

                    b.Property<int>("Safety")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("TopSpeed")
                        .HasColumnType("int");

                    b.Property<int>("TotalPower")
                        .HasColumnType("int");

                    b.Property<int>("TotalTorque")
                        .HasColumnType("int");

                    b.Property<bool>("TowHitch")
                        .HasColumnType("bit");

                    b.Property<int>("TowWeight")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
