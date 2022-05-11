using System;
using Automated.Course.System.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Automated.Course.System.DAL.EF
{
    public partial class CourseContext : IdentityDbContext
    {
        public CourseContext()
        {
        }

        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
     //   public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Entities.Course> Courses { get; set; }
        public virtual DbSet<CourseUserReference> CourseUserReferences { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Course2;Username=postgres;Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("answers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("value");

                entity.Property(e => e.IsRight)
                  .IsRequired()
                  .HasColumnName("isright");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("fk_answers_task").OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity<Chapter>(entity =>
            //{
            //    entity.ToTable("chapters");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .UseIdentityAlwaysColumn();

            //    entity.Property(e => e.CourseId).HasColumnName("course_id");

            //    entity.Property(e => e.Discription)
            //        .HasMaxLength(500)
            //        .HasColumnName("discription");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .HasColumnName("name");

            //    entity.HasOne(d => d.Course)
            //        .WithMany(p => p.Chapters)
            //        .HasForeignKey(d => d.CourseId)
            //        .HasConstraintName("fk_course_chapters");
            //});

            modelBuilder.Entity<Entities.Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("discription");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.CreateUserId)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("create_user_id");

                //entity.HasOne(d => d.Language)
                //    .HasForeignKey(d => d.LanguageId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("fk_course_language");
            });

            modelBuilder.Entity<CourseUserReference>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("course_user_reference");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_courseuserreference_courses");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_courseuserreference_users");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("languages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("tasks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CourseId).HasColumnName("course_id");


                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("text");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tasks_course").OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => new { e.LastName, e.FirstName }, "user_name_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.IsAdmin)
                .HasColumnName("is_admin");
            });

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
