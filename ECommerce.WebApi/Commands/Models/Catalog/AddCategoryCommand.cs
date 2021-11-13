using ECommerce.WebApi.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Commands.Models.Catalog
{
    public class AddCategoryCommand : IRequest<CategoryDto> ///eklendikten sonra dönüş tipi  CategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
