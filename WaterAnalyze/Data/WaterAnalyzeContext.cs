using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WaterAnalyze.Data;

public partial class WaterAnalyzeContext : DbContext
{
    public WaterAnalyzeContext()
    {
    }

    public WaterAnalyzeContext(DbContextOptions<WaterAnalyzeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Analyze> Analyzes { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sample> Samples { get; set; }

    public virtual DbSet<SamplingFrequency> SamplingFrequencies { get; set; }

    public virtual DbSet<Source> Sources { get; set; }

    public virtual DbSet<SourceType> SourceTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=WaterAnalyze;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Account_User");
        });

        modelBuilder.Entity<Analyze>(entity =>
        {
            entity.ToTable("Analyze");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.DateOfSelection).HasColumnType("date");

            entity.HasOne(d => d.Sample).WithMany(p => p.Analyzes)
                .HasForeignKey(d => d.SampleId)
                .HasConstraintName("FK_Analyze_Sample");

            entity.HasOne(d => d.Source).WithMany(p => p.Analyzes)
                .HasForeignKey(d => d.SourceId)
                .HasConstraintName("FK_Analyze_Source");

            entity.HasOne(d => d.User).WithMany(p => p.Analyzes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Analyze_User");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.ToTable("Direction");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sample>(entity =>
        {
            entity.ToTable("Sample");

            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SamplingFrequency>(entity =>
        {
            entity.ToTable("SamplingFrequency");

            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Source>(entity =>
        {
            entity.ToTable("Source");

            entity.Property(e => e.CoordinatesX)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CoordinatesY)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Direction).WithMany(p => p.Sources)
                .HasForeignKey(d => d.DirectionId)
                .HasConstraintName("FK_Source_Direction");

            entity.HasOne(d => d.SamplingFrequency).WithMany(p => p.Sources)
                .HasForeignKey(d => d.SamplingFrequencyId)
                .HasConstraintName("FK_Source_SamplingFrequency");

            entity.HasOne(d => d.SourceType).WithMany(p => p.Sources)
                .HasForeignKey(d => d.SourceTypeId)
                .HasConstraintName("FK_Source_SourceType");
        });

        modelBuilder.Entity<SourceType>(entity =>
        {
            entity.ToTable("SourceType");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
