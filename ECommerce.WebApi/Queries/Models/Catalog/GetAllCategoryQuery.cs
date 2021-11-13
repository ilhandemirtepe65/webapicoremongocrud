using ECommerce.WebApi.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Queries.Models.Catalog
{
    public class GetAllCategoryQuery:IRequest<List<CategoryDto>>
    {

    }
}
