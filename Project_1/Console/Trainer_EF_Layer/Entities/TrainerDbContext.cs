using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trainer_EF_Layer.Entities;

public partial class TrainerDbContext : DbContext
{
    static string connectionString = File.ReadAllText("../../../../Trainer_EF_Layer/ConnectionString.txt");
    public TrainerDbContext()
    {
    }

    public TrainerDbContext(DbContextOptions<TrainerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<TrainerDetail> TrainerDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Company");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("User_ID");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Company_Name");
            entity.Property(e => e.Field)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OverallExperience)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Overall_Experience");

            entity.HasOne(d => d.User).WithOne(p => p.Company)
                .HasForeignKey<Company>(d => d.UserId)
                .HasConstraintName("FK_Company");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Education");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("User_ID");
            entity.Property(e => e.PgCollage)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Pg_collage");
            entity.Property(e => e.PgPercentage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pg_Percentage");
            entity.Property(e => e.PgStream)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Pg_stream");
            entity.Property(e => e.PgYear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pg_year");
            entity.Property(e => e.UgCollage)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Ug_collage");
            entity.Property(e => e.UgPercentage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ug_Percentage");
            entity.Property(e => e.UgStream)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Ug_stream");
            entity.Property(e => e.UgYear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ug_year");

            entity.HasOne(d => d.User).WithOne(p => p.Education)
                .HasForeignKey<Education>(d => d.UserId)
                .HasConstraintName("FK_Education");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Skill");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("User_ID");
            entity.Property(e => e.Skill1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Skill_1");
            entity.Property(e => e.Skill2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Skill_2");
            entity.Property(e => e.Skill3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Skill_3");

            entity.HasOne(d => d.User).WithOne(p => p.Skill)
                .HasForeignKey<Skill>(d => d.UserId)
                .HasConstraintName("FK_Skill");
        });

        modelBuilder.Entity<TrainerDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("User_ID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Email_ID");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
