using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Peli.Domain.entities;
using Peli.Infraestructure.Repositories;
using Peli.Infraestructure.Data;

#nullable disable

namespace Peli.Infraestructure.Data
{
    public partial class PeliculasContext : DbContext
    {
        public PeliculasContext()
        {
        }

        public PeliculasContext(DbContextOptions<PeliculasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Peliculas.mssql.somee.com;Initial Catalog=Peliculas;Persist Security Info=False;User ID=Javi11x_SQLLogin_1;Password=zm2cjcucdj");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPeli);

                entity.ToTable("Pelicula");

                entity.Property(e => e.IdPeli).HasColumnName("idPeli");

                entity.Property(e => e.AñopPeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("añopPeli");

                entity.Property(e => e.DirectorPeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("directorPeli");

                entity.Property(e => e.GeneroPeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("generoPeli");

                entity.Property(e => e.PuntuacionPeli).HasColumnName("puntuacionPeli");

                entity.Property(e => e.RatingPeli).HasColumnName("ratingPeli");

                entity.Property(e => e.TituloPeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tituloPeli");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
