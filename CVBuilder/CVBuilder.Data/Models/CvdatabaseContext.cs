using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Models;

public partial class CvdatabaseContext : DbContext
{
    public CvdatabaseContext()
    {
    }

    public CvdatabaseContext(DbContextOptions<CvdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CVDatabase;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Certific__3214EC07D1BBFC6C");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ExpirationDate).HasColumnType("date");
            entity.Property(e => e.IssueDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Organization).HasMaxLength(100);
            entity.Property(e => e.ResumeId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Resume).WithMany(p => p.Certificates)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__Resum__4AB81AF0");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC073F15430C");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Degree).HasMaxLength(100);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.FieldOfStudy).HasMaxLength(100);
            entity.Property(e => e.Institute).HasMaxLength(100);
            entity.Property(e => e.ResumeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Resume).WithMany(p => p.Educations)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Education__Resum__4F7CD00D");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3214EC072FBFB9C7");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ResumeId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Resume).WithMany(p => p.Languages)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Languages__Resum__60A75C0F");
        });

        modelBuilder.Entity<PersonalInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personal__3214EC076EB67CDA");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.User).WithMany(p => p.PersonalInfos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PersonalI__UserI__5441852A");
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resumes__3214EC0751764A2C");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.User).WithMany(p => p.Resumes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resumes__UserId__403A8C7D");

            entity.HasMany(d => d.Skills).WithMany(p => p.Resumes)
                .UsingEntity<Dictionary<string, object>>(
                    "ResumesSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ResumesSk__Skill__45F365D3"),
                    l => l.HasOne<Resume>().WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ResumesSk__Resum__44FF419A"),
                    j =>
                    {
                        j.HasKey("ResumeId", "SkillId").HasName("PK__ResumesS__BA2DA9EF2A7F3BB9");
                        j.ToTable("ResumesSkills");
                        j.IndexerProperty<Guid>("ResumeId").HasDefaultValueSql("(newid())");
                        j.IndexerProperty<Guid>("SkillId").HasDefaultValueSql("(newid())");
                    });
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC07D7F048E3");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Template__3214EC07F449AA10");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Path).HasMaxLength(200);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F8E99345");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E48AB690D2").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053422B04F30").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Salt).HasMaxLength(32);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkExpe__3214EC07FC4AF2C1");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Company).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.ResumeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Resume).WithMany(p => p.WorkExperiences)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkExper__Resum__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
