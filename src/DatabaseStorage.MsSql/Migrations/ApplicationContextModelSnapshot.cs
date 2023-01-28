﻿// <auto-generated />
using System;
using DatabaseStorage.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseStorage.MsSql.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("int");

                    b.Property<byte>("QuestionType")
                        .HasColumnType("tinyint");

                    b.Property<int>("TestPassingId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("TestPassingId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Core.Entities.DetailedTestInfo", b =>
                {
                    b.Property<int>("DetailedTestInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttemptCount")
                        .HasColumnType("int");

                    b.Property<int>("AverageTestCompletionTime")
                        .HasColumnType("int");

                    b.HasKey("DetailedTestInfoId");

                    b.ToTable("DetailedTestInfo");
                });

            modelBuilder.Entity("Core.Entities.DetailedUserInfo", b =>
                {
                    b.Property<int>("DetailedUserInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedTestCount")
                        .HasColumnType("int");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<int>("PassedTestCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DetailedUserInfoId");

                    b.ToTable("DetailedUserInfo");
                });

            modelBuilder.Entity("Core.Entities.PassedTest", b =>
                {
                    b.Property<int>("TestPassingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TestPassingId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("PassedTest");
                });

            modelBuilder.Entity("Core.Entities.ReferalCode", b =>
                {
                    b.Property<int>("ReferalCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("ReferalCodeId");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("ReferalCode");
                });

            modelBuilder.Entity("Core.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagValue")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TagId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Core.Entities.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DetailedTestInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionCount")
                        .HasColumnType("int");

                    b.HasKey("TestId");

                    b.HasIndex("DetailedTestInfoId")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AccountMode")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DetailedUserInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReferalCodeId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("DetailedUserInfoId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("TagTest", b =>
                {
                    b.Property<int>("TagsTagId")
                        .HasColumnType("int");

                    b.Property<int>("TestsTestId")
                        .HasColumnType("int");

                    b.HasKey("TagsTagId", "TestsTestId");

                    b.HasIndex("TestsTestId");

                    b.ToTable("TestTag");
                });

            modelBuilder.Entity("TagUser", b =>
                {
                    b.Property<int>("TagsTagId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("TagsTagId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("UserTag");
                });

            modelBuilder.Entity("Core.Entities.Answer", b =>
                {
                    b.HasOne("Core.Entities.PassedTest", "TestPassing")
                        .WithMany("Answers")
                        .HasForeignKey("TestPassingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestPassing");
                });

            modelBuilder.Entity("Core.Entities.PassedTest", b =>
                {
                    b.HasOne("Core.Entities.Test", "Test")
                        .WithMany("Attempts")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("PassedTests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.ReferalCode", b =>
                {
                    b.HasOne("Core.Entities.User", "Owner")
                        .WithOne("ReferalCode")
                        .HasForeignKey("Core.Entities.ReferalCode", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Core.Entities.Test", b =>
                {
                    b.HasOne("Core.Entities.DetailedTestInfo", "DetailedTestInfo")
                        .WithOne("Test")
                        .HasForeignKey("Core.Entities.Test", "DetailedTestInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "Owner")
                        .WithMany("Tests")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetailedTestInfo");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasOne("Core.Entities.DetailedUserInfo", "DetailedUserInfo")
                        .WithOne("User")
                        .HasForeignKey("Core.Entities.User", "DetailedUserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetailedUserInfo");
                });

            modelBuilder.Entity("TagTest", b =>
                {
                    b.HasOne("Core.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Test", null)
                        .WithMany()
                        .HasForeignKey("TestsTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TagUser", b =>
                {
                    b.HasOne("Core.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.DetailedTestInfo", b =>
                {
                    b.Navigation("Test");
                });

            modelBuilder.Entity("Core.Entities.DetailedUserInfo", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.PassedTest", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Core.Entities.Test", b =>
                {
                    b.Navigation("Attempts");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("PassedTests");

                    b.Navigation("ReferalCode");

                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
