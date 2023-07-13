using System;
using System.Collections.Generic;

namespace DadtApi.Models
{
    public partial class Item
    {
        public Item()
        {
            ItemAttributes = new HashSet<ItemAttribute>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int SubCategoryId { get; set; }
        public string ItemImageLink { get; set; }
        public string ItemCode { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<ItemAttribute> ItemAttributes { get; set; }
    }
}
