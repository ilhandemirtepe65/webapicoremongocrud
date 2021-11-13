using AutoMapper;
using ECommerce.Services.Abstract;
using ECommerce.WebApi.DataTransferObject;
using ECommerce.WebApi.Queries.Models.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Queries.Handlers.Catalog
{
    public class GetCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public GetCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CategoryDto>>(await _categoryService.GetCategorys());
        }
    }
}
