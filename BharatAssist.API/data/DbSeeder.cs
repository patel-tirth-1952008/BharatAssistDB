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
               
                GovernmentFee = 0,
                
            },

            new Service
            {
                ServiceGroupId = aadhaar.ServiceGroupId,
                ServiceName = "Update Aadhaar",
               
                GovernmentFee = 50,
               
            },

            new Service
            {
                ServiceGroupId = pan.ServiceGroupId,
                ServiceName = "New PAN Card",
               
                GovernmentFee = 107,
                
            }

        );

        context.SaveChanges();
    }
}