namespace ECommerce.WebApi.DataTransferObject
{

    public class ProductDto 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
    }
}
