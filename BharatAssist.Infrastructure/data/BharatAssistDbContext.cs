using BharatAssist.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BharatAssist.Infrastructure.Data;

public class BharatAssistDbContext : DbContext
{
    public BharatAssistDbContext(DbContextOptions<BharatAssistDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<ServiceGroup> ServiceGroups { get; set; }

    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ServiceGroup>()
            .HasOne(sg => sg.Category)
            .WithMany(c => c.ServiceGroups)
            .HasForeignKey(sg => sg.CategoryId);

        modelBuilder.Entity<Service>()
            .HasOne(s => s.ServiceGroup)
            .WithMany(g => g.Services)
            .HasForeignKey(s => s.ServiceGroupId);
    }
}