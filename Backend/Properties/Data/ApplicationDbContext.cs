using AchiHunter.Backend.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AchiHunter.Backend.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUserModel>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUserModel>(entity =>
        {
            entity.HasMany(u => u.PlatformAccounts)
                  .WithOne(p => p.User)
                  .HasForeignKey(p => p.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<PlatformAccount>(entity =>
        {
            entity.Property(p => p.Platform).HasConversion<string>();
            entity.Property(p => p.PlatformUserId).HasMaxLength(64);
            entity.Property(p => p.DisplayName).HasMaxLength(64);

            // One account per platform per user
            entity.HasIndex(p => new { p.UserId, p.Platform }).IsUnique();
            // A platform account can't be linked to two users
            entity.HasIndex(p => new { p.Platform, p.PlatformUserId }).IsUnique();
        });
    }
   
}