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
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:ssoUMDBConnection__PG");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<App>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("app_pk");

            entity.Property(e => e.AppName).IsFixedLength();

            entity.HasOne(d => d.JidNavigation).WithMany(p => p.Apps)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("app_fk");
        });

        modelBuilder.Entity<Jwt>(entity =>
        {
            entity.HasKey(e => e.Jid).HasName("jwt_pk");

            entity.HasOne(d => d.KidNavigation).WithMany(p => p.Jwts)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("jwt_fk");
        });

        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasKey(e => e.Kid).HasName("keys_pk");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("role_pk");

            entity.HasOne(d => d.AidNavigation).WithMany(p => p.Roles)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("role_t_app_fk");

            entity.HasOne(d => d.RP).WithMany(p => p.InverseRP).HasConstraintName("role_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("user_pk");

            entity.HasOne(d => d.AidNavigation).WithMany(p => p.Users).HasConstraintName("user_fk");

            entity.HasOne(d => d.RidNavigation).WithMany(p => p.Users).HasConstraintName("user_t_role_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
