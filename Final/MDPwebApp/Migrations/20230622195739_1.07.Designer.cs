﻿// <auto-generated />
using MDPwebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MDPwebApp.Migrations
{
    [DbContext(typeof(RequestContext))]
    [Migration("20230622195739_1.07")]
    partial class _107
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MDPwebApp.Models.Requestor", b =>
                {
                    b.Property<int>("requestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("requestId"), 1L, 1);

                    b.Property<bool>("AOG")
                        .HasColumnType("bit");

                    b.Property<string>("CIVL_ITAR_radio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Create_Extend_radio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LeadTime")
                        .HasColumnType("bit");

                    b.Property<string>("Make_Buy_radio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OE_MRO_radio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PrimarySBU")
                        .HasColumnType("bit");

                    b.Property<string>("ProgramType_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("STO")
                        .HasColumnType("bit");

                    b.Property<string>("additional_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("authority_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("commentBox_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("component_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("materialPlantExtend_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("materialPlant_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("materialType_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mrp_cntrl_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("next_higher_assm_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("old_pn_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prod_sup_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productionSlocExtend_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productionSloc_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raw_mat_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salesOrgExtend_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salesOrg_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("scenarioType_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sloc_ep_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("requestId");

                    b.ToTable("Requests");

                    b.HasData(
                        new
                        {
                            requestId = 1,
                            AOG = false,
                            CIVL_ITAR_radio = "",
                            Create_Extend_radio = "Create",
                            LeadTime = false,
                            Make_Buy_radio = "Make",
                            MaterialDescription = "SEAL",
                            MaterialNumber = "59568",
                            OE_MRO_radio = "",
                            PrimarySBU = true,
                            ProgramType_id = "AE250",
                            STO = false,
                            additional_id = "TRUE",
                            authority_id = "AUTH",
                            commentBox_id = "Required by Monday",
                            component_id = "COM",
                            materialPlantExtend_id = "",
                            materialPlant_id = "2020",
                            materialType_id = "Z001",
                            mrp_cntrl_id = "EAJ",
                            next_higher_assm_id = "NEX",
                            old_pn_id = "59567",
                            prod_sup_id = "007",
                            productionSlocExtend_id = "",
                            productionSloc_id = "NEW1",
                            raw_mat_id = "RAW",
                            salesOrgExtend_id = "",
                            salesOrg_id = "4000",
                            scenarioType_id = "END ITEM",
                            sloc_ep_id = "REC1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
