using System.Collections.Generic;
namespace BharatAssist.Core.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }

        public string? Icon { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public List<ServiceGroup> ServiceGroups { get; set; } = new();
    }
}