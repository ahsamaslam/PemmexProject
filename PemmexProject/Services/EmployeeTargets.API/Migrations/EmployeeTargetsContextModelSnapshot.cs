﻿// <auto-generated />
using System;
using EmployeeTargets.API.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeTargets.API.Migrations
{
    [DbContext(typeof(EmployeeTargetsContext))]
    partial class EmployeeTargetsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeTargets.API.Database.Entities.HardTargets", b =>
                {
                    b.Property<int>("HardTargetsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EvaluationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("HardTargetsDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HardTargetsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeasurementCriteria")
                        .HasColumnType("int");

                    b.Property<double>("MeasurementCriteriaResult")
                        .HasColumnType("float");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TargetType")
                        .HasColumnType("int");

                    b.Property<double>("Weightage")
                        .HasColumnType("float");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("HardTargetsId");

                    b.ToTable("HardTargets");
                });

            modelBuilder.Entity("EmployeeTargets.API.Database.Entities.HardTargetsDetail", b =>
                {
                    b.Property<int>("HardTargetsDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostCenterIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HardTargetsId")
                        .HasColumnType("int");

                    b.Property<string>("ManagerIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HardTargetsDetailId");

                    b.ToTable("HardTargetsDetail");
                });

            modelBuilder.Entity("EmployeeTargets.API.Database.Entities.PerformanceEvaluationSettings", b =>
                {
                    b.Property<int>("performanceEvaluationSettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<double>("maximumPercentage")
                        .HasColumnType("float");

                    b.Property<double>("minimumPercentage")
                        .HasColumnType("float");

                    b.Property<double>("organizationIdentifier")
                        .HasColumnType("float");

                    b.Property<double>("targetPercentage")
                        .HasColumnType("float");

                    b.HasKey("performanceEvaluationSettingsId");

                    b.ToTable("PerformanceEvaluationSettings");
                });

            modelBuilder.Entity("EmployeeTargets.API.Database.Entities.PerformanceEvaluationSummary", b =>
                {
                    b.Property<int>("performanceEvaluationSummaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("bonusAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("bonusPayoutDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("bonusPercentage")
                        .HasColumnType("float");

                    b.Property<string>("businessIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("companyProfitabilityMultiplier")
                        .HasColumnType("float");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeeIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("finalBonusAmount")
                        .HasColumnType("float");

                    b.Property<string>("grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jobFunction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("managerIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("performanceMultiplier")
                        .HasColumnType("float");

                    b.Property<double>("resultedBonusAmountAfterMultiplier")
                        .HasColumnType("float");

                    b.Property<double>("resultedBonusAmountBeforeMultiplier")
                        .HasColumnType("float");

                    b.Property<double>("resultedBonusPercentage")
                        .HasColumnType("float");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("totalSalary")
                        .HasColumnType("float");

                    b.HasKey("performanceEvaluationSummaryId");

                    b.ToTable("PerformanceEvaluationSummary");
                });

            modelBuilder.Entity("EmployeeTargets.API.Database.Entities.PerfromanceBudgetPlanning", b =>
                {
                    b.Property<int>("perfromanceBudgetPlanningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("bonusPayoutDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("companyProfitabilityMultiplier")
                        .HasColumnType("float");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("organizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("perfromanceBudgetPlanningId");

                    b.ToTable("PerfromanceBudgetPlanning");
                });

            modelBuilder.Entity("EmployeeTargets.API.Database.Entities.SoftTargets", b =>
                {
                    b.Property<int>("SoftTargetsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EvaluationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerformanceCriteria")
                        .HasColumnType("int");

                    b.Property<string>("SoftTargetsDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoftTargetsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TargetType")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("SoftTargetsId");

                    b.ToTable("SoftTargets");
                });

            modelBuilder.Entity("EmployeeTargets.API.Database.Entities.SoftTargetsDetail", b =>
                {
                    b.Property<int>("SoftTargetsDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostCenterIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoftTargetsId")
                        .HasColumnType("int");

                    b.HasKey("SoftTargetsDetailId");

                    b.ToTable("SoftTargetsDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
