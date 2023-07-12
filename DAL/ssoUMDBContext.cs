using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ssoUM.DAL.Entities;

namespace ssoUM.DAL;

public partial class ssoUMDBContext : DbContext
{
    public ssoUMDBContext()
    {
    }

    public ssoUMDBContext(DbContextOptions<ssoUMDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<App> Apps { get; set; }

    public virtual DbSet<Jwt> Jwts { get; set; }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ssoUMDBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<App>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("App_PK");

            entity.HasOne(d => d.JidNavigation).WithMany(p => p.Apps)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("App_FK");
        });

        modelBuilder.Entity<Jwt>(entity =>
        {
            entity.HasKey(e => e.Jid).HasName("jwt_PK");

            entity.HasOne(d => d.KidNavigation).WithMany(p => p.Jwts)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("jwt_FK");
        });

        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasKey(e => e.Kid).HasName("keys_PK");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("role_PK");

            entity.HasOne(d => d.AidNavigation).WithMany(p => p.Roles)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("role_t_app_FK");

            entity.HasOne(d => d.RP).WithMany(p => p.InverseRP).HasConstraintName("role_FK");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("user_PK");

            entity.HasOne(d => d.AidNavigation).WithMany(p => p.Users).HasConstraintName("user_FK");

            entity.HasOne(d => d.RidNavigation).WithMany(p => p.Users).HasConstraintName("user_t_role_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
