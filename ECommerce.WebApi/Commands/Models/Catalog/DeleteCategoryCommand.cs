using ECommerce.WebApi.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Commands.Models.Catalog
{
    public class DeleteCategoryCommand :IRequest<bool> //Silindikten sonra true,false döndür
    {
        public string CategoryId { get; set; }  // Gelecek Parametre olarak CategoryId istiyorum
    }
}
