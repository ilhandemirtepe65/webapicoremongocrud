using AutoMapper;
using ECommerce.Services.Abstract;
using ECommerce.WebApi.DataTransferObject;
using ECommerce.WebApi.Queries.Models.Catalog;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Queries.Handlers.Catalog
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryDto>
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CategoryDto>(await _categoryService.GetCategory(request.Id));
        }

      
    }
}
