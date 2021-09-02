using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RastreadorDeProblemasAPI.Models.dbModels
{
    public partial class RastreadorProblemasContext : DbContext
    {
        public RastreadorProblemasContext()
        {
        }

        public RastreadorProblemasContext(DbContextOptions<RastreadorProblemasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Problema> Problemas { get; set; }
        public virtual DbSet<ProblemaEstatus> ProblemaEstatuses { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Problema>(entity =>
            {
                entity.HasOne(d => d.IdProblemaEstatusNavigation)
                    .WithMany(p => p.Problemas)
                    .HasForeignKey(d => d.IdProblemaEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Problema_ProblemaEstatus");

                entity.HasOne(d => d.IdUsuarioAsignadoNavigation)
                    .WithMany(p => p.Problemas)
                    .HasForeignKey(d => d.IdUsuarioAsignado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Problema_Usuario");
            });

            modelBuilder.Entity<ProblemaEstatus>(entity =>
            {
                entity.Property(e => e.IdProblemaEstatus).ValueGeneratedNever();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
