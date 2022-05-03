﻿// <auto-generated />
using System;
using Automated.Course.System.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Automated.Course.System.DAL.Migrations
{
    [DbContext(typeof(CourseContext))]
    partial class CourseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityAlwaysColumn();

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("answer_text");

                    b.Property<int?>("TaskId")
                        .HasColumnType("integer")
                        .HasColumnName("task_id");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("answers");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityAlwaysColumn();

                    b.Property<int?>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<string>("Discription")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("discription");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("chapters");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityAlwaysColumn();

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("create_user_id");

                    b.Property<string>("Discription")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("discription");

                    b.Property<int>("LanguageId")
                        .HasColumnType("integer")
                        .HasColumnName("language_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.CourseUserReference", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("course_user_reference");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityAlwaysColumn();

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("language_name");

                    b.HasKey("Id");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityAlwaysColumn();

                    b.Property<int>("ChapterId")
                        .HasColumnType("integer")
                        .HasColumnName("chapter_id");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<string>("TaskText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("task_text");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.HasIndex("CourseId");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean")
                        .HasColumnName("is_admin");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.HasIndex(new[] { "LastName", "FirstName" }, "user_name_idx");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Answer", b =>
                {
                    b.HasOne("Automated.Course.System.DAL.Entities.Task", "Task")
                        .WithMany("Answers")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("fk_answers_task");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Chapter", b =>
                {
                    b.HasOne("Automated.Course.System.DAL.Entities.Course", "Course")
                        .WithMany("Chapters")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("fk_course_chapters");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Course", b =>
                {
                    b.HasOne("Automated.Course.System.DAL.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.CourseUserReference", b =>
                {
                    b.HasOne("Automated.Course.System.DAL.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .HasConstraintName("fk_courseuserreference_courses")
                        .IsRequired();

                    b.HasOne("Automated.Course.System.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_courseuserreference_users");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Task", b =>
                {
                    b.HasOne("Automated.Course.System.DAL.Entities.Chapter", "Chapter")
                        .WithMany("Tasks")
                        .HasForeignKey("ChapterId")
                        .HasConstraintName("fk_tasks_chapter")
                        .IsRequired();

                    b.HasOne("Automated.Course.System.DAL.Entities.Course", "Course")
                        .WithMany("Tasks")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("fk_tasks_course")
                        .IsRequired();

                    b.Navigation("Chapter");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.User", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithOne()
                        .HasForeignKey("Automated.Course.System.DAL.Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Chapter", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Course", b =>
                {
                    b.Navigation("Chapters");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Automated.Course.System.DAL.Entities.Task", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
