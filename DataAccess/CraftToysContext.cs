using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public partial class CraftToysContext : DbContext
{
    public CraftToysContext()
    {
    }

    public CraftToysContext(DbContextOptions<CraftToysContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370F37954867");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E61641466EDA2").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__users__F3DBC572176B2EA9").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("date_created");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
