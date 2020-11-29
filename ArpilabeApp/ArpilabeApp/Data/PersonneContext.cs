using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ArpilabeApp.Models;

namespace ArpilabeApp.Data
{
    public partial class PersonneContext : DbContext
    {
        public PersonneContext()
        {
        }

        public PersonneContext(DbContextOptions<PersonneContext> options) : base(options)
        {
        }

        public virtual DbSet<Personne> Personne { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=BDARPILABE;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>(entity =>
            {
                entity.Property(e => e.DateNaissance)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Departement)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumTel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
