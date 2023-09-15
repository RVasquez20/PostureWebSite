using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PostureWebSite.Models.Request;

namespace PostureWebSite.Models;

public partial class PostureBaseContext : DbContext
{
    public PostureBaseContext()
    {
    }

    public PostureBaseContext(DbContextOptions<PostureBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autorizacion> Autorizacions { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<RegistroBotone> RegistroBotones { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<UserRequest> UserRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRequest>(e=>e.HasNoKey());
        modelBuilder.Entity<Autorizacion>(entity =>
        {
            entity.HasKey(e => e.IdAutorizacion);

            entity.ToTable("Autorizacion");

            entity.Property(e => e.IdAutorizacion).HasColumnName("idAutorizacion");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Opcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("URL");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Autorizacions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Autorizacion_Roles");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Clientes_Usuarios");
        });

        modelBuilder.Entity<RegistroBotone>(entity =>
        {
            entity.HasKey(e => e.IdRegistroBotones).HasName("PK__Registro__359639C02461BF2F");

            entity.Property(e => e.IdRegistroBotones).HasColumnName("idRegistroBotones");
            entity.Property(e => e.Boton1).HasDefaultValueSql("((0))");
            entity.Property(e => e.Boton2).HasDefaultValueSql("((0))");
            entity.Property(e => e.Boton3).HasDefaultValueSql("((0))");
            entity.Property(e => e.Boton4).HasDefaultValueSql("((0))");
            entity.Property(e => e.Boton5).HasDefaultValueSql("((0))");
            entity.Property(e => e.Boton6).HasDefaultValueSql("((0))");
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.RegistroBotones)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_RegistroBotones_Usuarios");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
