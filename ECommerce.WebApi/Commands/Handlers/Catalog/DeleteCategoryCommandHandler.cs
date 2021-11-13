using AutoMapper;
using ECommerce.Services.Abstract;
using ECommerce.WebApi.Commands.Models.Catalog;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Commands.Handlers.Catalog
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public DeleteCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {       
            return  await _categoryService.Delete(request.CategoryId);     
        }
    }
}
