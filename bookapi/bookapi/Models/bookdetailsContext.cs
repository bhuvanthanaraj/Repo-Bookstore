using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bookapi.Models
{
    public partial class bookdetailsContext : DbContext
    {
        public bookdetailsContext()
        {
        }

        public bookdetailsContext(DbContextOptions<bookdetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addtocart> Addtocarts { get; set; } = null!;
        public virtual DbSet<Booklist> Booklists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=bookdetails;User ID=B-DESKTOP\\admin;Password=;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addtocart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("addtocart");

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.Bookprice).HasColumnName("bookprice");

                entity.Property(e => e.Booktitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("booktitle");
            });

            modelBuilder.Entity<Booklist>(entity =>
            {
                entity.HasKey(e => e.Bookid)
                    .HasName("PK__booklist__8BEA95C5D939A72E");

                entity.ToTable("booklist");

                entity.Property(e => e.Bookid)
                    .ValueGeneratedNever()
                    .HasColumnName("bookid");

                entity.Property(e => e.Bookdescription)
                    .HasColumnType("text")
                    .HasColumnName("bookdescription");

                entity.Property(e => e.Bookprice).HasColumnName("bookprice");

                entity.Property(e => e.Booktitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("booktitle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
