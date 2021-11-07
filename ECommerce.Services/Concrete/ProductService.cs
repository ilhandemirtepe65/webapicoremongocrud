using ECommerce.Data.Abstract;
using ECommerce.Entities.Catalog;
using ECommerce.Services.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ECommerce.Services.Concrete
{
    public class ProductService : IProductService
    {
       
        private readonly IRepository<Product> _repository;
        private readonly IDistributedCache _distributedCache;
        public ProductService(IRepository<Product> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
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
            var cacheKey = id;
            Product product = new Product();
            var cachedData = await _distributedCache.GetAsync(cacheKey); ///ilk başta cache bak eğer varsa ordan al 
            if (cachedData != null)
            {
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                product = JsonConvert.DeserializeObject<Product>(cachedDataString);
            }
            else  ///cachede yoksa git db den çek ve cache yaz
            {
                // If not found, then fetch data from database
                product = await _repository.Collection.Find(p => p.Id == id).FirstOrDefaultAsync();
                // serialize data
                var cachedDataString = JsonConvert.SerializeObject(product);
                var newDataToCache = Encoding.UTF8.GetBytes(cachedDataString);
                // set cache options 
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(5)).SetSlidingExpiration(TimeSpan.FromMinutes(1));
                // Add data in cache
                await _distributedCache.SetAsync(cacheKey, newDataToCache, options);
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(string categoryId)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category.Id, categoryId);
            return await _repository.Collection.Find(filter).ToListAsync();
        }

       

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var cacheKey = "GET_ALL_PRODUCTS";
            List<Product> products = new List<Product>();
            var cachedData = await _distributedCache.GetAsync(cacheKey); ///ilk başta cache bak eğer varsa ordan al 
            if (cachedData != null)
            {
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                products = JsonConvert.DeserializeObject<List<Product>>(cachedDataString);
            }
            else  ///cachede yoksa git db den çek ve cache yaz
            {
                // If not found, then fetch data from database
                products = await _repository.Collection.Find(p => true).ToListAsync();
                // serialize data
                var cachedDataString = JsonConvert.SerializeObject(products);
                var newDataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                // set cache options 
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(5)).SetSlidingExpiration(TimeSpan.FromMinutes(1));

                // Add data in cache
                await _distributedCache.SetAsync(cacheKey, newDataToCache, options);
            }
            return products;
        }

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _repository.Collection.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }

   
}
