using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Crm.Data.Models;

namespace Crm.Data.Context
{
    public partial class CrmDbContext : DbContext
    {
        public CrmDbContext()
        {
        }

        public CrmDbContext(DbContextOptions<CrmDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseNpgsql("Host=db-postgresql;Port=5432;Database=postgres;Username=postgres;Password=241990");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact", "contact");

                entity.HasIndex(e => e.Id)
                    .HasName("contact_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.ToTable("reservations", "contact");

                entity.HasIndex(e => e.Id)
                    .HasName("reservations_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckIn)
                    .HasColumnName("check_in")
                    .HasColumnType("date");

                entity.Property(e => e.CheckOut)
                    .HasColumnName("check_out")
                    .HasColumnType("date");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ResNumber)
                    .HasColumnName("res_number")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservations_contact_id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
