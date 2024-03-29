﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Organization.API;

namespace Organization.API.Migrations
{
    [DbContext(typeof(PemmexOrganizationContext))]
    [Migration("20211109064941_sp_GetEmployeeTreeForManager")]
    partial class sp_GetEmployeeTreeForManager
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Organization.API.Dtos.spGetEmployeeTreeForManagerDto", b =>
                {
                    b.Property<string>("BusinessIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractualOrganization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostCenterIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostCenterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCellNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Emp_Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EmployeeDob")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstLanguageSkills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Muncipality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentCostCenterIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondLanguageSkills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Shift")
                        .HasColumnType("int");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdLanguageSkills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SpGetEmployeeTreeForManagerDtos");
                });

            modelBuilder.Entity("Organization.API.Entities.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("OrganizationCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentBusinessId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("Organization.API.Entities.Compensation", b =>
                {
                    b.Property<int>("CompensationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AdditionalAgreedPart")
                        .HasColumnType("float");

                    b.Property<double>("BaseSalary")
                        .HasColumnType("float");

                    b.Property<double>("CarBenefit")
                        .HasColumnType("float");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("EmissionBenefit")
                        .HasColumnType("float");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<double>("HomeInternetBenefit")
                        .HasColumnType("float");

                    b.Property<double>("InsuranceBenefit")
                        .HasColumnType("float");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PhoneBenefit")
                        .HasColumnType("float");

                    b.Property<double>("TotalMonthlyPay")
                        .HasColumnType("float");

                    b.HasKey("CompensationId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Compensations");
                });

            modelBuilder.Entity("Organization.API.Entities.CostCenter", b =>
                {
                    b.Property<int>("CostCenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CostCenterIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostCenterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentCostCenterIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CostCenterId");

                    b.ToTable("CostCenters");
                });

            modelBuilder.Entity("Organization.API.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<int>("CostCenterId")
                        .HasColumnType("int");

                    b.Property<string>("CountryCellNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Emp_Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EmployeeDob")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstLanguageSkills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Muncipality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondLanguageSkills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Shift")
                        .HasColumnType("int");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdLanguageSkills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("BusinessId");

                    b.HasIndex("CostCenterId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Organization.API.Entities.EmployeeContacts", b =>
                {
                    b.Property<int>("EmployeeContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeContactId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeContacts");
                });

            modelBuilder.Entity("Organization.API.Entities.Compensation", b =>
                {
                    b.HasOne("Organization.API.Entities.Employee", "Employee")
                        .WithOne("Compensation")
                        .HasForeignKey("Organization.API.Entities.Compensation", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Organization.API.Entities.Employee", b =>
                {
                    b.HasOne("Organization.API.Entities.Business", "Businesses")
                        .WithMany("Employees")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Organization.API.Entities.CostCenter", "CostCenter")
                        .WithMany()
                        .HasForeignKey("CostCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Businesses");

                    b.Navigation("CostCenter");
                });

            modelBuilder.Entity("Organization.API.Entities.EmployeeContacts", b =>
                {
                    b.HasOne("Organization.API.Entities.Employee", "Employee")
                        .WithMany("employeeContacts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Organization.API.Entities.Business", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Organization.API.Entities.Employee", b =>
                {
                    b.Navigation("Compensation");

                    b.Navigation("employeeContacts");
                });
#pragma warning restore 612, 618
        }
    }
}
