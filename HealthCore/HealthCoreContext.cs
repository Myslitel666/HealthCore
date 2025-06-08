using System;
using System.Collections.Generic;
using HealthCore.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCore;

public partial class HealthCoreContext : DbContext
{
    public HealthCoreContext()
    {
    }

    public HealthCoreContext(DbContextOptions<HealthCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=HealthCore; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
