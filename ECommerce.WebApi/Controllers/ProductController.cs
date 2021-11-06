using AutoMapper;
using ECommerce.Entities.Catalog;
using ECommerce.Services.Abstract;
using ECommerce.WebApi.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Variables

        private readonly IProductService _productRepository;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryRepository;
        #endregion

        #region Constructor

        public ProductController(IProductService productRepository, ILogger<ProductController> logger, IMapper mapper, ICategoryService categoryRepository)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Crud_Actions

        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                _logger.LogError($"Product with id : {id},hasn't been found in databasei");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDto productdto)
        {

            var productMapper = _mapper.Map<Product>(productdto);
            var category = _categoryRepository.GetCategory(productdto.CategoryId);
            productMapper.Category = category.Result;
            await _productRepository.Create(productMapper);
            return CreatedAtRoute("GetProduct", new { id = productMapper.Id }, productMapper);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productdto)
        {
            var productMapper = _mapper.Map<Product>(productdto);
            var category = _categoryRepository.GetCategory(productdto.CategoryId);
            productMapper.Category = category.Result;
            return Ok(await _productRepository.Update(productMapper));
        }


        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _productRepository.Delete(id));
        }

        #endregion
    }
}
