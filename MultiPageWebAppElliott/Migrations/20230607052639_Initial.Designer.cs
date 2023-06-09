﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiPageWebAppElliott.Models;

#nullable disable

namespace MultiPageWebAppElliott.Migrations
{
    [DbContext(typeof(ContactContext))]
    [Migration("20230607052639_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MultiPageWebAppElliott.Models.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"), 1L, 1);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactID = 2,
                            ContactName = "Tony Robinson",
                            Notes = "D&D DM",
                            PhoneNumber = "5552783000"
                        },
                        new
                        {
                            ContactID = 3,
                            ContactName = "Derek Ebel",
                            Notes = "Team Leader",
                            PhoneNumber = "5558675309"
                        },
                        new
                        {
                            ContactID = 4,
                            ContactName = "Timothy Cross",
                            Notes = "Brother-in-arms",
                            PhoneNumber = "5551234567"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
