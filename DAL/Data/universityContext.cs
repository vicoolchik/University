using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DAL.Models;

#nullable disable

namespace DAL.Data
{
    public partial class universityContext : DbContext
    {
        public universityContext()
        {
        }

        public universityContext(DbContextOptions<universityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassHour> ClassHours { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<ProfessorsSubject> ProfessorsSubjects { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsClass> StudentsClasses { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=university;Username=postgres;Password=qaz16073011");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_Ukraine.1251");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("classes");

                entity.HasIndex(e => e.ProfessorId, "fki_ProfessorID_classes_fk");

                entity.HasIndex(e => e.SubjectId, "fki_SubjectID_classes_fk");

                entity.Property(e => e.ClassId)
                    .ValueGeneratedNever()
                    .HasColumnName("class_id");

                entity.Property(e => e.ProfessorId).HasColumnName("professor_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.ProfessorId)
                    .HasConstraintName("ProfessorID_classes_fk");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("SubjectID_classes_fk");
            });

            modelBuilder.Entity<ClassHour>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("class_hours");

                entity.HasIndex(e => e.ClassId, "fki_ClassID_ClassHours_fk");

                entity.Property(e => e.ClassEnd)
                    .HasColumnType("time without time zone")
                    .HasColumnName("class_end");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassStart)
                    .HasColumnType("time without time zone")
                    .HasColumnName("class_start");

                entity.HasOne(d => d.Class)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("ClassID_ClassHours_fk");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("professors");

                entity.Property(e => e.ProfessorId)
                    .ValueGeneratedNever()
                    .HasColumnName("professor_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<ProfessorsSubject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("professors_subjects");

                entity.HasIndex(e => e.ProfessorId, "fki_ProfessorID_Professors_Subjects_fk");

                entity.HasIndex(e => e.SubjectId, "fki_SubjectID_Professors_Subjects_fk");

                entity.Property(e => e.ProfessorId).HasColumnName("professor_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(d => d.Professor)
                    .WithMany()
                    .HasForeignKey(d => d.ProfessorId)
                    .HasConstraintName("ProfessorID_Professors_Subjects_fk");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("SubjectID_Professors_Subjects_fk");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("student_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<StudentsClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("students_classes");

                entity.HasIndex(e => e.ClassId, "fki_ClassID_fk");

                entity.HasIndex(e => e.StudentId, "fki_StudentID_fk");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Class)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("ClassID_fk");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("StudentID_fk");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subjects");

                entity.Property(e => e.SubjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("subject_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.OffsetOrExam)
                    .HasMaxLength(50)
                    .HasColumnName("offset_or_exam");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
