using AutoMapper;
using ECommerce.Entities.Catalog;
using ECommerce.Services.Abstract;
using ECommerce.WebApi.Commands.Models.Catalog;
using ECommerce.WebApi.DataTransferObject;
using ECommerce.WebApi.Queries.Handlers.Catalog;
using ECommerce.WebApi.Queries.Models.Catalog;
using MediatR;
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
        private readonly ILogger<CategoryController> _logger;
        private readonly IMediator _mediator;
        #endregion

        #region Constructor

        public CategoryController(ILogger<CategoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #endregion

        #region Crud_Actions

        [HttpGet]
        [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetCategorys()
        {
            var query = new GetAllCategoryQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id:length(24)}", Name = "GetCategory")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetCategory(string id)
        {

            var category = await _mediator.Send(new GetByIdCategoryQuery { Id=id});      
            if (category == null)
            {
                _logger.LogError($"category with id : {id},hasn't been found in databasei");
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] AddCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));      
        }

        [HttpPut]
        [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCategoryById(string id)
        {
            return Ok(await _mediator.Send(new DeleteCategoryCommand {CategoryId=id }));
        }

        #endregion
    }
}

