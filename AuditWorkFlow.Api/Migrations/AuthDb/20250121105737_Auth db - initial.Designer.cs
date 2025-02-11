﻿// <auto-generated />
using AuditWorkFlow.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuditWorkFlow.Api.Migrations.AuthDb
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20250121105737_Auth db - initial")]
    partial class Authdbinitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");

                    b.HasData(
                        new
                        {
                            Id = "397c575a-dad5-4f83-99e5-77e0d0fc3115",
                            ConcurrencyStamp = "397c575a-dad5-4f83-99e5-77e0d0fc3115",
                            Name = "Reader",
                            NormalizedName = "READER"
                        },
                        new
                        {
                            Id = "d08840db-d4ea-43de-bbb0-e52495c47a72",
                            ConcurrencyStamp = "d08840db-d4ea-43de-bbb0-e52495c47a72",
                            Name = "Writer",
                            NormalizedName = "WRITER"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
