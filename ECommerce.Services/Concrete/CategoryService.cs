using ECommerce.Data.Abstract;
using ECommerce.Entities.Catalog;
using ECommerce.Services.Abstract;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
       
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Create(Category category)
        {
            await _repository.Collection.InsertOneAsync(category);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Category>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _repository.Collection.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Category> GetCategory(string id)
        {
            return await _repository.Collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Category>> GetCategorys()
        {
            return await _repository.Collection.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Category category)
        {
            var updateResult = await _repository.Collection.ReplaceOneAsync(filter: g => g.Id == category.Id, replacement: category);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
