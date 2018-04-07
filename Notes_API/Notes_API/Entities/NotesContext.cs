using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes_API.Entities
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "Notes");

                entity.Property(c => c.Name)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.ToTable("Notes", "Notes");

                entity.Property(n => n.CreatedOn)
                    .HasColumnType("datetime");

                entity.Property(n => n.Note)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(n => n.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(c => c.Category)
                    .WithMany(n => n.Notes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notes_CategoryId");

                entity.HasOne(u => u.User)
                    .WithMany(n => n.Notes)
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notes_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Notes");

                entity.Property(u => u.CreatedOn)
                    .HasColumnType("datetime");

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }

        public  DbSet<User> User { get; set; }
        public  DbSet<Notes> Notes { get; set; }
        public  DbSet<Category> Category { get; set; }
    }
}
