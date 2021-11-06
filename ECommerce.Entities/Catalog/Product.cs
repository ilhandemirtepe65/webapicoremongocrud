using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Catalog
{
    public class Product : BaseEntity
    {
       
        public string Name { get; set; }
        //public string CategoryId { get; set; }    
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
