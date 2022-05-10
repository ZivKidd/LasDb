﻿// <auto-generated />
using LasDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LasDb.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("LasDb.LasPointDb", b =>
                {
                    b.Property<int>("Index")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Intensity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScanLineIndex")
                        .HasColumnType("INTEGER");

                    b.Property<double>("X")
                        .HasColumnType("REAL");

                    b.Property<double>("X2D")
                        .HasColumnType("REAL");

                    b.Property<double>("Y")
                        .HasColumnType("REAL");

                    b.Property<double>("Y2D")
                        .HasColumnType("REAL");

                    b.Property<double>("Z")
                        .HasColumnType("REAL");

                    b.HasKey("Index");

                    b.HasIndex("ScanLineIndex");

                    b.ToTable("LasPointDbs");
                });
#pragma warning restore 612, 618
        }
    }
}
