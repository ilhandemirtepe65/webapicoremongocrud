using AutoMapper;
using ECommerce.Entities.Catalog;
using ECommerce.Services.Abstract;
using ECommerce.WebApi.Commands.Models.Catalog;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace ECommerce.WebApi.Commands.Handlers.Catalog
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryMapper = _mapper.Map<Category>(request);
          return   await _categoryService.Update(categoryMapper);
           
        }
    }
}
