using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Commands.Categories;
using NorthwindTraders.Data;
using NorthwindTraders.Domain;

namespace NorthwindTraders.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _mediator.Send(new GetCategoriesCommand());
        }


        [HttpPost]
        public async Task<Category> SaveCategory([FromBody] Category category)
        {
            return await _mediator.Send(new SaveCategoryCommand(category));
        }
        



    }
}