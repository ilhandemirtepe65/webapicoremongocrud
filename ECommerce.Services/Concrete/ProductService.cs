using ECommerce.Data.Abstract;
using ECommerce.Entities.Catalog;
using ECommerce.Services.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Concrete
{
    public class ProductService : IProductService
    {
       
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Create(Product product)
        {
            await _repository.Collection.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Product>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _repository.Collection.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _repository.Collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(string categoryId)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category.Id, categoryId);
            return await _repository.Collection.Find(filter).ToListAsync();
        }

       

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _repository.Collection.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _repository.Collection.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }

   
}
