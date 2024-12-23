﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolDiarySystem.Domain;

#nullable disable

namespace SchoolDiarySystem.Domain.Migrations
{
    [DbContext(typeof(SchoolDiaryContext))]
    partial class SchoolDiaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SchoolDiarySystem.Domain.Model.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GradeId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Date");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentId");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("Subject_Id");

                    b.Property<int>("Value")
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasColumnName("Value");

                    b.HasKey("GradeId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("SchoolDiarySystem.Domain.Model.SchoolClass", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SchoolClassId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("Letter")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Letter");

                    b.Property<int>("Number")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("Number");

                    b.HasKey("ClassId");

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("SchoolDiarySystem.Domain.Model.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StudentId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<DateTime>("BirthDate")
                        .HasMaxLength(100)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("BirthDate");

                    b.Property<int>("ClassId")
                        .HasColumnType("int")
                        .HasColumnName("SchoolClassId");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("FullName");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Passport");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolDiarySystem.Domain.Model.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SubjectId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<int>("AcademicYear")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SchoolDiarySystem.Domain.Model.Grade", b =>
                {
                    b.HasOne("SchoolDiarySystem.Domain.Model.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDiarySystem.Domain.Model.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDiarySystem.Domain.Model.Student", b =>
                {
                    b.HasOne("SchoolDiarySystem.Domain.Model.SchoolClass", null)
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDiarySystem.Domain.Model.SchoolClass", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
