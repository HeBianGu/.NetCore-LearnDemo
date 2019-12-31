﻿// <auto-generated />
using HeBianGu.Demo.WebApi.RESTful;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HeBianGu.Demo.WebApi.RESTful.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    partial class SqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("HeBianGu.Demo.WebApi.RESTful.CustomEntity", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Age")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("CustomEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
