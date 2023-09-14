using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace BackPTecnica.Models;

public partial class TareasContext : DbContext
{
    public TareasContext()
    {
    }

    public TareasContext(DbContextOptions<TareasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__task__756A5402D9ED01C1");

            entity.ToTable("task");

            entity.Property(e => e.IdTarea).HasColumnName("idTarea");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prioridad");
            entity.Property(e => e.TaskComplete).HasColumnName("taskComplete");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
