using AutoMapper;
using ECommerce.Entities.Catalog;
using ECommerce.WebApi.DataTransferObject;
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
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();


        }
    }
}
