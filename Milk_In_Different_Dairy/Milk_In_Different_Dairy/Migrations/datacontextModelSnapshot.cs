﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Milk_In_Different_Dairy.Database;

#nullable disable

namespace Milk_In_Different_Dairy.Migrations
{
    [DbContext(typeof(datacontext))]
    partial class datacontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Milk_In_Different_Dairy.Models.Daily_record", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Dairy_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<float>("liters")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Daily_records");
                });

            modelBuilder.Entity("Milk_In_Different_Dairy.Models.dairy", b =>
                {
                    b.Property<int>("Dairy_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dairy_id"), 1L, 1);

                    b.Property<string>("Dairy_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Dairy_id");

                    b.ToTable("Dairys");
                });
#pragma warning restore 612, 618
        }
    }
}