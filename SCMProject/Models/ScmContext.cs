using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SCMProject.Models;

public partial class ScmContext : DbContext
{
    public ScmContext()
    {
    }

    public ScmContext(DbContextOptions<ScmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Database\\scm.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("student");

            entity.Property(e => e.Age).HasColumnType("INT");
            entity.Property(e => e.BirthDate).HasColumnName("Birth Date");
            entity.Property(e => e.FirstName).HasColumnName("First Name");
            entity.Property(e => e.Gpa)
                .HasColumnType("decimal")
                .HasColumnName("GPA");
            entity.Property(e => e.Id)
                .HasColumnType("id")
                .HasColumnName("ID");
            entity.Property(e => e.IsActive).HasColumnName("Is Active");
            entity.Property(e => e.LastName).HasColumnName("Last Name");
            entity.Property(e => e.TuitionFee).HasColumnName("Tuition Fee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
