using BharatAssist.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BharatAssist.Infrastructure.Data
{
    public class BharatAssistDbContext : DbContext
    {
        public BharatAssistDbContext(DbContextOptions<BharatAssistDbContext> options)
            : base(options)
        {
        }

        // Example table
        public DbSet<Category> Categories { get; set; }
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
    }
}