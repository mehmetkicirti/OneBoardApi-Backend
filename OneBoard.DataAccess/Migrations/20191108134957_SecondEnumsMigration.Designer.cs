﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneBoard.DataAccess.EF._DatabaseContext;

namespace OneBoard.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191108134957_SecondEnumsMigration")]
    partial class SecondEnumsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OneBoard.Entities.Concrete.ChartType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharTypeName")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ChartTypes");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.Dashboard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<int>("FirmID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CreatorID");

                    b.HasIndex("FirmID");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.DataSource", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConnString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DataSourceTypeID")
                        .HasColumnType("int");

                    b.Property<string>("DataValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirmID")
                        .HasColumnType("int");

                    b.Property<string>("QueryString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DataSourceTypeID");

                    b.HasIndex("FirmID");

                    b.ToTable("DataSources");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.DataSourceType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DataSourceTypeName")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("DataSourceTypes");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.Firm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Firms");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirmID")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FirmID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.Serie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChartTypeID")
                        .HasColumnType("int");

                    b.Property<int>("DataSourceID")
                        .HasColumnType("int");

                    b.Property<int?>("WidgetID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ChartTypeID");

                    b.HasIndex("DataSourceID");

                    b.HasIndex("WidgetID");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoginName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.UserFirm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirmID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirmID");

                    b.HasIndex("UserID");

                    b.ToTable("UserFirms");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.UserGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserID");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.Widget", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DashboardID")
                        .HasColumnType("int");

                    b.Property<int>("DataSourceID")
                        .HasColumnType("int");

                    b.Property<int?>("GoalValue")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("PositionX")
                        .HasColumnType("int");

                    b.Property<int>("PositionY")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WidgetTypeID")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DashboardID");

                    b.HasIndex("DataSourceID");

                    b.HasIndex("WidgetTypeID");

                    b.ToTable("Widgets");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.WidgetType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("WidgetTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("WidgetTypes");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.Dashboard", b =>
                {
                    b.HasOne("OneBoard.Entities.Concrete.User", "User")
                        .WithMany("Dashboards")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneBoard.Entities.Concrete.Firm", "Firm")
                        .WithMany("Dashboards")
                        .HasForeignKey("FirmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.DataSource", b =>
                {
                    b.HasOne("OneBoard.Entities.Concrete.DataSourceType", "DataSourceType")
                        .WithMany("DataSources")
                        .HasForeignKey("DataSourceTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneBoard.Entities.Concrete.Firm", "Firm")
                        .WithMany()
                        .HasForeignKey("FirmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.Group", b =>
                {
                    b.HasOne("OneBoard.Entities.Concrete.Firm", "Firm")
                        .WithMany("Groups")
                        .HasForeignKey("FirmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.Serie", b =>
                {
                    b.HasOne("OneBoard.Entities.Concrete.ChartType", "ChartType")
                        .WithMany("Series")
                        .HasForeignKey("ChartTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneBoard.Entities.Concrete.DataSource", "DataSource")
                        .WithMany("Series")
                        .HasForeignKey("DataSourceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneBoard.Entities.Concrete.Widget", "Widget")
                        .WithMany("Series")
                        .HasForeignKey("WidgetID");
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.UserFirm", b =>
                {
                    b.HasOne("OneBoard.Entities.Concrete.Firm", "Firm")
                        .WithMany("UserFirms")
                        .HasForeignKey("FirmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneBoard.Entities.Concrete.User", "User")
                        .WithMany("UserFirms")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.UserGroup", b =>
                {
                    b.HasOne("OneBoard.Entities.Concrete.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneBoard.Entities.Concrete.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OneBoard.Entities.Concrete.Widget", b =>
                {
                    b.HasOne("OneBoard.Entities.Concrete.Dashboard", "Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardID");

                    b.HasOne("OneBoard.Entities.Concrete.DataSource", "DataSource")
                        .WithMany("Widgets")
                        .HasForeignKey("DataSourceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneBoard.Entities.Concrete.WidgetType", "WidgetType")
                        .WithMany("Widgets")
                        .HasForeignKey("WidgetTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}