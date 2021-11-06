using ECommerce.WebApi.DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Validator
{
    public class ProductValidator :AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Product Name Alanı Boş Geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Product Price Alanı Boş Geçilemez");
            RuleFor(x => x.Currency).NotEmpty().WithMessage("Product Currency Alanı Boş Geçilemez");
        }
    }
}
