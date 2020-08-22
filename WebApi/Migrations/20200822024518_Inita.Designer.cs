﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200822024518_Inita")]
    partial class Inita
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Models.Expense", b =>
                {
                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PaidOut")
                        .HasColumnType("bit");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("decimal");

                    b.HasKey("Description");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("WebApi.Models.Recipe", b =>
                {
                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PaidIn")
                        .HasColumnType("bit");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Description");

                    b.ToTable("Recipe");
                });
#pragma warning restore 612, 618
        }
    }
}
