using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIOracle.DataAccess.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tblautor> Tblautors { get; set; } = null!;
        public virtual DbSet<Tbllibro> Tbllibros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseOracle("user id=pruebaTecnica;password=Camila1030;data source=localhost:1521/ORCL;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PRUEBATECNICA")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Tblautor>(entity =>
            {
                entity.HasKey(e => e.Idautor)
                    .HasName("TBLAUTOR_PK");

                entity.ToTable("TBLAUTOR");

                entity.Property(e => e.Idautor)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDAUTOR");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CIUDAD");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHANACIMIENTO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Tbllibro>(entity =>
            {
                entity.HasKey(e => e.Idlibro)
                    .HasName("TBLLIBRO_PK");

                entity.ToTable("TBLLIBRO");

                entity.Property(e => e.Idlibro)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDLIBRO");

                entity.Property(e => e.Anio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ANIO");

                entity.Property(e => e.Genero)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GENERO");

                entity.Property(e => e.Idautor)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDAUTOR");

                entity.Property(e => e.Nopaginas)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NOPAGINAS");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.Tbllibros)
                    .HasForeignKey(d => d.Idautor)
                    .HasConstraintName("FK_AUTOR_LIBRO");
            });

            modelBuilder.HasSequence("IDAUTOR_SEQ");

            modelBuilder.HasSequence("IDLIBRO_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
