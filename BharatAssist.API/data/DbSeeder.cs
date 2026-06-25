using BharatAssist.Core.Entities;
using BharatAssist.Infrastructure.Data;

namespace BharatAssist.API.Data;

public static class DbSeeder
{
    public static void Seed(BharatAssistDbContext context)
    {
        if (context.Categories.Any())
            return;

        var documents = new Category
        {
            CategoryName = "Documents",
            Icon = "badge",
            DisplayOrder = 1,
            IsActive = true
        };

        var transport = new Category
        {
            CategoryName = "Transport",
            Icon = "car",
            DisplayOrder = 2,
            IsActive = true
        };

        context.Categories.AddRange(documents, transport);
        context.SaveChanges();

        var aadhaar = new ServiceGroup
        {
            CategoryId = documents.CategoryId,
            GroupName = "Aadhaar Services",
            Icon = "badge",
            DisplayOrder = 1,
            IsActive = true
        };

        var pan = new ServiceGroup
        {
            CategoryId = documents.CategoryId,
            GroupName = "PAN Card",
            Icon = "credit_card",
            DisplayOrder = 2,
            IsActive = true
        };

        context.ServiceGroups.AddRange(aadhaar, pan);
        context.SaveChanges();

        context.Services.AddRange(

            new Service
            {
                ServiceGroupId = aadhaar.ServiceGroupId,
                ServiceName = "New Aadhaar Card",
                Description = "Apply for Aadhaar Card",
                GovernmentFee = 0,
                EstimatedMinutes = 20,
                Difficulty = "Easy"
            },

            new Service
            {
                ServiceGroupId = aadhaar.ServiceGroupId,
                ServiceName = "Update Aadhaar",
                Description = "Update Aadhaar Details",
                GovernmentFee = 50,
                EstimatedMinutes = 15,
                Difficulty = "Easy"
            },

            new Service
            {
                ServiceGroupId = pan.ServiceGroupId,
                ServiceName = "New PAN Card",
                Description = "Apply for PAN Card",
                GovernmentFee = 107,
                EstimatedMinutes = 25,
                Difficulty = "Easy"
            }

        );

        context.SaveChanges();
    }
}