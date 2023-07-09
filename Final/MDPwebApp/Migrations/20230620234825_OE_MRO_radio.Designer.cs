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
    [Migration("20230620234825_OE_MRO_radio")]
    partial class OE_MRO_radio
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

                    b.Property<string>("Military_three_radio_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OE_MRO_radio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramType_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("additional_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aog_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("authority_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buy_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("civil_four_radio_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("civil_one_radio_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("commentBox_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("component_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("create_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("extend_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("leadTime_checkbox_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("make_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("materialDescription_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("materialNumber_id")
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

                    b.Property<string>("option_EPP_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("option_MRO_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("option_OE_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primary_sbu_id")
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

                    b.Property<string>("sto_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("requestId");

                    b.ToTable("Requests");

                    b.HasData(
                        new
                        {
                            requestId = 1,
                            Military_three_radio_id = "FALSE",
                            OE_MRO_radio = "FALSE",
                            ProgramType_id = "AE250",
                            additional_id = "TRUE",
                            aog_id = "FALSE",
                            authority_id = "AUTH",
                            buy_id = "FALSE",
                            civil_four_radio_id = "FALSE",
                            civil_one_radio_id = "TRUE",
                            commentBox_id = "Required by Monday",
                            component_id = "COM",
                            create_id = "TRUE",
                            extend_id = "FALSE",
                            leadTime_checkbox_id = "FALSE",
                            make_id = "TRUE",
                            materialDescription_id = "SEAL",
                            materialNumber_id = "",
                            materialPlantExtend_id = "",
                            materialPlant_id = "2020",
                            materialType_id = "Z001",
                            mrp_cntrl_id = "EAJ",
                            next_higher_assm_id = "NEX",
                            old_pn_id = "59567",
                            option_EPP_id = "FALSE",
                            option_MRO_id = "FALSE",
                            option_OE_id = "TRUE",
                            primary_sbu_id = "TRUE",
                            prod_sup_id = "007",
                            productionSlocExtend_id = "",
                            productionSloc_id = "NEW1",
                            raw_mat_id = "RAW",
                            salesOrgExtend_id = "",
                            salesOrg_id = "4000",
                            scenarioType_id = "END ITEM",
                            sloc_ep_id = "REC1",
                            sto_id = "FALSE"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}