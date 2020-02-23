﻿// <auto-generated />
using System;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyEmployees.Migrations
{
    [DbContext(typeof(RepositryContext))]
    partial class RepositryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CompanyId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Country");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7ab9dba8-32ba-4f79-90fd-fccb7465a0eb"),
                            Address = "Nasr City",
                            Country = "Egypt",
                            Name = "ITShare"
                        },
                        new
                        {
                            Id = new Guid("0bf027a2-9a38-41fd-b389-b73ab290d29b"),
                            Address = "AY Haga",
                            Country = "USA",
                            Name = "ABC"
                        });
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeId");

                    b.Property<int>("Age");

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("290603c0-d0dd-4559-ba34-7579ca3da866"),
                            Age = 36,
                            CompanyId = new Guid("7ab9dba8-32ba-4f79-90fd-fccb7465a0eb"),
                            Name = "Ahmed rabea",
                            Position = "Manager"
                        },
                        new
                        {
                            Id = new Guid("0bf027a2-9a38-41fd-b389-b73ab290d29b"),
                            Age = 36,
                            CompanyId = new Guid("7ab9dba8-32ba-4f79-90fd-fccb7465a0eb"),
                            Name = "Mohamed rabea",
                            Position = "Manager"
                        });
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.HasOne("Entities.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}