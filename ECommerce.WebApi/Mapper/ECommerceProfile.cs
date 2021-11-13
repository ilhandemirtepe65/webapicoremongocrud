using AutoMapper;
using ECommerce.Entities.Catalog;
using ECommerce.WebApi.Commands.Models.Catalog;
using ECommerce.WebApi.DataTransferObject;
using ECommerce.WebApi.Queries.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Mapper
{
   
    public class ECommerceProfile : Profile
    {
        public ECommerceProfile()
        {
           

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();


        }
    }
}
