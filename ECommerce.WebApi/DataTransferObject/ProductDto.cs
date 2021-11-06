using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebApi.DataTransferObject
{
  
    public class ProductDto 
    {

        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
    }
}
