using AutoMapper;
using ECommerce.Entities.Catalog;
using ECommerce.Services.Abstract;
using ECommerce.WebApi.Commands.Models.Catalog;
using ECommerce.WebApi.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Commands.Handlers.Catalog
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CategoryDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public AddCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryMapper = _mapper.Map<Category>(request);
             await _categoryService.Create(categoryMapper);
            return _mapper.Map<CategoryDto>(categoryMapper);
        }
    }
}
