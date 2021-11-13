using ECommerce.WebApi.DataTransferObject;
using MediatR;

namespace ECommerce.WebApi.Queries.Models.Catalog
{
    public class GetByIdCategoryQuery : IRequest<CategoryDto>
    {
        public string Id { get; set; }
    }
}
