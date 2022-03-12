﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransactionAPI.Models.Data;

namespace TransactionAPI.Migrations
{
    [DbContext(typeof(TransactionDbContext))]
    [Migration("20210416054448_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransactionAPI.Models.Counterparties", b =>
                {
                    b.Property<int>("Counterparty_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Other_Details")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Counterparty_ID");

                    b.ToTable("Counterparties");

                    b.HasData(
                        new
                        {
                            Counterparty_ID = 1,
                            Other_Details = "Other Details 1"
                        },
                        new
                        {
                            Counterparty_ID = 2,
                            Other_Details = "Other Details 2"
                        },
                        new
                        {
                            Counterparty_ID = 3,
                            Other_Details = "Other Details 3"
                        });
                });

            modelBuilder.Entity("TransactionAPI.Models.Financial_Transaction", b =>
                {
                    b.Property<int>("Transaction_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Account_ID")
                        .HasColumnType("int");

                    b.Property<double>("Amount_of_Transaction")
                        .HasColumnType("float");

                    b.Property<int>("Counterparty_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_of_Transaction")
                        .HasColumnType("datetime2");

                    b.Property<string>("Other_Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Payment_Method_Code")
                        .HasColumnType("int");

                    b.Property<int>("Service_ID")
                        .HasColumnType("int");

                    b.Property<int>("Trans_Status_Code")
                        .HasColumnType("int");

                    b.Property<int>("Trans_Type_Code")
                        .HasColumnType("int");

                    b.HasKey("Transaction_ID");

                    b.HasIndex("Counterparty_ID");

                    b.HasIndex("Payment_Method_Code");

                    b.HasIndex("Service_ID");

                    b.HasIndex("Trans_Status_Code");

                    b.HasIndex("Trans_Type_Code");

                    b.ToTable("Financial_Transactions");
                });

            modelBuilder.Entity("TransactionAPI.Models.Ref_Payment_Methods", b =>
                {
                    b.Property<int>("Payment_Method_Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Payment_Method_Name")
                        .HasColumnType("int");

                    b.HasKey("Payment_Method_Code");

                    b.ToTable("Ref_Payment_Methods");

                    b.HasData(
                        new
                        {
                            Payment_Method_Code = 1,
                            Payment_Method_Name = 0
                        },
                        new
                        {
                            Payment_Method_Code = 2,
                            Payment_Method_Name = 1
                        },
                        new
                        {
                            Payment_Method_Code = 3,
                            Payment_Method_Name = 2
                        },
                        new
                        {
                            Payment_Method_Code = 4,
                            Payment_Method_Name = 3
                        },
                        new
                        {
                            Payment_Method_Code = 5,
                            Payment_Method_Name = 4
                        },
                        new
                        {
                            Payment_Method_Code = 6,
                            Payment_Method_Name = 5
                        });
                });

            modelBuilder.Entity("TransactionAPI.Models.Ref_Transaction_Status", b =>
                {
                    b.Property<int>("Trans_Status_Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Trans_Status_Description")
                        .HasColumnType("int");

                    b.HasKey("Trans_Status_Code");

                    b.ToTable("Ref_Transaction_Status");

                    b.HasData(
                        new
                        {
                            Trans_Status_Code = 1,
                            Trans_Status_Description = 1
                        },
                        new
                        {
                            Trans_Status_Code = 2,
                            Trans_Status_Description = 0
                        },
                        new
                        {
                            Trans_Status_Code = 3,
                            Trans_Status_Description = 2
                        });
                });

            modelBuilder.Entity("TransactionAPI.Models.Ref_Transaction_Types", b =>
                {
                    b.Property<int>("Trans_Type_Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Trans_Type_Description")
                        .HasColumnType("int");

                    b.HasKey("Trans_Type_Code");

                    b.ToTable("Ref_Transaction_Types");

                    b.HasData(
                        new
                        {
                            Trans_Type_Code = 1,
                            Trans_Type_Description = 0
                        },
                        new
                        {
                            Trans_Type_Code = 2,
                            Trans_Type_Description = 1
                        },
                        new
                        {
                            Trans_Type_Code = 3,
                            Trans_Type_Description = 2
                        });
                });

            modelBuilder.Entity("TransactionAPI.Models.Services", b =>
                {
                    b.Property<int>("Service_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Service_Provided")
                        .HasColumnType("datetime2");

                    b.Property<string>("Other_Details")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Service_ID");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Service_ID = 1,
                            Date_Service_Provided = new DateTime(2021, 4, 16, 11, 14, 48, 361, DateTimeKind.Local).AddTicks(103),
                            Other_Details = "Other Details 1"
                        },
                        new
                        {
                            Service_ID = 2,
                            Date_Service_Provided = new DateTime(2021, 4, 16, 11, 14, 48, 361, DateTimeKind.Local).AddTicks(1388),
                            Other_Details = "Other Details 1"
                        },
                        new
                        {
                            Service_ID = 3,
                            Date_Service_Provided = new DateTime(2021, 4, 16, 11, 14, 48, 361, DateTimeKind.Local).AddTicks(1414),
                            Other_Details = "Other Details 1"
                        });
                });

            modelBuilder.Entity("TransactionAPI.Models.Financial_Transaction", b =>
                {
                    b.HasOne("TransactionAPI.Models.Counterparties", "Counterparties")
                        .WithMany()
                        .HasForeignKey("Counterparty_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransactionAPI.Models.Ref_Payment_Methods", "Ref_Payment_Methods")
                        .WithMany()
                        .HasForeignKey("Payment_Method_Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransactionAPI.Models.Services", "Services")
                        .WithMany()
                        .HasForeignKey("Service_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransactionAPI.Models.Ref_Transaction_Status", "Ref_Transaction_Status")
                        .WithMany()
                        .HasForeignKey("Trans_Status_Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransactionAPI.Models.Ref_Transaction_Types", "Ref_Transaction_Types")
                        .WithMany()
                        .HasForeignKey("Trans_Type_Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
