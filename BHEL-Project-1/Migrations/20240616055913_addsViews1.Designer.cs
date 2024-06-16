﻿// <auto-generated />
using System;
using BHEL_Project_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BHEL_Project_1.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240616055913_addsViews1")]
    partial class addsViews1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication7.Models.ComponentMaster", b =>
                {
                    b.Property<int>("ComponentMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComponentMasterId"));

                    b.Property<string>("Component_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Component_Ref_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Item_Type_Id")
                        .HasColumnType("int");

                    b.Property<string>("Updated_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Updated_On")
                        .HasColumnType("date");

                    b.HasKey("ComponentMasterId");

                    b.ToTable("ComponentMaster");
                });

            modelBuilder.Entity("WebApplication7.Models.ComponentTypeMaster", b =>
                {
                    b.Property<int>("ComponentTypeMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComponentTypeMasterId"));

                    b.Property<int>("Applicable_Item_Id")
                        .HasColumnType("int");

                    b.Property<int>("ComponentMasterId")
                        .HasColumnType("int");

                    b.Property<string>("Identity_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_BOI")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_Ind")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference_Doc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComponentTypeMasterId");

                    b.HasIndex("ComponentMasterId");

                    b.ToTable("ComponentTypeMaster");
                });

            modelBuilder.Entity("WebApplication7.Models.ComponentTypeMaster", b =>
                {
                    b.HasOne("WebApplication7.Models.ComponentMaster", "ComponentMaster")
                        .WithMany("ComponentTypeMasters")
                        .HasForeignKey("ComponentMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComponentMaster");
                });

            modelBuilder.Entity("WebApplication7.Models.ComponentMaster", b =>
                {
                    b.Navigation("ComponentTypeMasters");
                });
#pragma warning restore 612, 618
        }
    }
}
