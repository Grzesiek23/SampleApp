using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Models;

namespace SampleApp.Infrastructure.Contexts;

public partial class SampleDbContext : DbContext
{
    public SampleDbContext()
    {
    }

    public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; } = null!;
  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Nip)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("NIP");

            entity.Property(e => e.PostalCode)
                .HasMaxLength(6)
                .IsUnicode(false);
        });
    }
}
