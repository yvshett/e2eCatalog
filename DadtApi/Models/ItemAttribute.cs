using System;
using System.Collections.Generic;

namespace DadtApi.Models
{
    public partial class ItemAttribute
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public int ItemId { get; set; }
        public string AttributeValue { get; set; }

        public virtual Item Item { get; set; }
    }
}
