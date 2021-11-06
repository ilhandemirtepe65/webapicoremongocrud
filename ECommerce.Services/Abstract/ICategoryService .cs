using ECommerce.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategorys();
        Task<Category> GetCategory(string id);
        Task Create(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(string id);
    }
}
