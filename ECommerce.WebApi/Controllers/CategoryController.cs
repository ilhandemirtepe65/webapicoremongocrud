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
    public class CategoryController : ControllerBase
    {
        #region Variables

        private readonly ICategoryService _categoryRepository;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor

        public CategoryController(ICategoryService categoryRepository, ILogger<CategoryController> logger, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion

        #region Crud_Actions

        [HttpGet]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategorys()
        {
            var categories = await _categoryRepository.GetCategorys();
            return Ok(categories);
        }

        [HttpGet("{id:length(24)}", Name = "GetCategory")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> GetCategory(string id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
            {
                _logger.LogError($"category with id : {id},hasn't been found in databasei");
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] CategoryDto categorydto)
        {
            var categoryMapper = _mapper.Map<Category>(categorydto);
            await _categoryRepository.Create(categoryMapper);
            
            return CreatedAtRoute("GetCategory", new { id = categoryMapper.Id }, categoryMapper);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {   
            return Ok(await _categoryRepository.Update(category));
        }
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCategoryById(string id)
        {
            return Ok(await _categoryRepository.Delete(id));
        }

        #endregion
    }
}

