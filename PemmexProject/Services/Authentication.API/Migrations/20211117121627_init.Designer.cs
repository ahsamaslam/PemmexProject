﻿// <auto-generated />
using System;
using Authentication.API.Database.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Authentication.API.Migrations
{
    [DbContext(typeof(AuthenticationContext))]
    [Migration("20211117121627_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Authentication.API.Database.Entities.Roles", b =>
                {
                    b.Property<int>("roleId")
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

                    b.Property<string>("OrganizationIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Authentication.API.Database.Entities.Screens", b =>
                {
                    b.Property<int>("screenId")
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

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("screenName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("screenId");

                    b.HasIndex("roleId");

                    b.ToTable("Screens");
                });

            modelBuilder.Entity("Authentication.API.Database.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BusinessIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostCenterIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPasswordReset")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTwoStepAuthEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("JobFunction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordResetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PasswordResetCodeTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Authentication.API.Database.Entities.Screens", b =>
                {
                    b.HasOne("Authentication.API.Database.Entities.Roles", "Roles")
                        .WithMany("Screens")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Authentication.API.Database.Entities.Roles", b =>
                {
                    b.Navigation("Screens");
                });
#pragma warning restore 612, 618
        }
    }
}
