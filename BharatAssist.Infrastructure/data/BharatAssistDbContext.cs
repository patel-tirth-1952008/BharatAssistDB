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
    public DbSet<Faq> Faqs { get; set; }

    public DbSet<RequiredDocument> RequiredDocuments { get; set; }

    public DbSet<CommunityTip> CommunityTips { get; set; }
    public DbSet<User> Users { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Faq>()
            .HasOne(x => x.Service)
            .WithMany()
            .HasForeignKey(x => x.ServiceId);

        modelBuilder.Entity<RequiredDocument>()
            .HasOne(x => x.Service)
            .WithMany()
            .HasForeignKey(x => x.ServiceId);

        modelBuilder.Entity<CommunityTip>()
            .HasOne(x => x.Service)
            .WithMany()
            .HasForeignKey(x => x.ServiceId);
        modelBuilder.Entity<ServiceGroup>()
            .HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);

        modelBuilder.Entity<ServiceGroup>()
            .HasOne(sg => sg.Category)
            .WithMany(c => c.ServiceGroups)
            .HasForeignKey(sg => sg.CategoryId);

        
    }
}