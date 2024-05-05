using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace systemdesignProject.Models;

public partial class GymdatabaseContext : DbContext
{
    public GymdatabaseContext()
    {
    }

    public GymdatabaseContext(DbContextOptions<GymdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Contactu> Contactus { get; set; }

    public virtual DbSet<Ourteam> Ourteams { get; set; }

    public virtual DbSet<Planstable> Planstable { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Userstable> Userstables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LNNV0M1;Database=Gymdatabase;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("classes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.day).HasColumnName("day");
            entity.Property(e => e.Img)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Planid).HasColumnName("planid");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Trainerid).HasColumnName("trainerid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Plan).WithMany(p => p.Classes)
                .HasForeignKey(d => d.Planid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_classes_planstable");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Classes)
                .HasForeignKey(d => d.Trainerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_classes_Ourteam");

            entity.HasOne(d => d.User).WithMany(p => p.Classes)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_classes_Userstable");
        });

        modelBuilder.Entity<Contactu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_cidontactus");

            entity.ToTable("contactus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ourteam>(entity =>
        {
            entity.ToTable("Ourteam");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Img)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Job)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Planstable>(entity =>
        {
            entity.ToTable("planstable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Img)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Userstable>(entity =>
        {
            entity.ToTable("Userstable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
