﻿// <auto-generated />
using System;
using AuthorizationApp.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuthorizationApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorizationApp.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Class", (string)null);
                });

            modelBuilder.Entity("AuthorizationApp.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Grade", (string)null);
                });

            modelBuilder.Entity("AuthorizationApp.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Role");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("AuthorizationApp.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("AuthorizationApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("AuthorizationApp.Models.Grade", b =>
                {
                    b.HasOne("AuthorizationApp.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Grade_Student");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AuthorizationApp.Models.Student", b =>
                {
                    b.HasOne("AuthorizationApp.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .IsRequired()
                        .HasConstraintName("FK_Student_Class");

                    b.HasOne("AuthorizationApp.Models.User", "UserData")
                        .WithOne("Student")
                        .HasForeignKey("AuthorizationApp.Models.Student", "Id")
                        .IsRequired()
                        .HasConstraintName("FK_Student_User");

                    b.Navigation("Class");

                    b.Navigation("UserData");
                });

            modelBuilder.Entity("AuthorizationApp.Models.User", b =>
                {
                    b.HasOne("AuthorizationApp.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_User_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AuthorizationApp.Models.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("AuthorizationApp.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AuthorizationApp.Models.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("AuthorizationApp.Models.User", b =>
                {
                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
