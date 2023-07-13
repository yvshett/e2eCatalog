using System;
using System.Collections.Generic;

namespace DadtApi.Models
{
    public partial class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
