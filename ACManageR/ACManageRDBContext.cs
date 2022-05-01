using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ACManageR.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ACManageR
{
    public partial class ACManageRDBContext : DbContext
    {
        public ACManageRDBContext()
        {
        }

        public ACManageRDBContext(DbContextOptions<ACManageRDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ACManageRDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requests>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TechVisitDate).HasColumnType("datetime");

                entity.Property(e => e.TechnicianId).HasColumnName("TechnicianID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requests__Status__30F848ED");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.RequestsTechnician)
                    .HasForeignKey(d => d.TechnicianId)
                    .HasConstraintName("FK__Requests__Techni__31EC6D26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RequestsUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requests__UserID__34C8D9D1");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StatusType).HasMaxLength(80);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleID__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
