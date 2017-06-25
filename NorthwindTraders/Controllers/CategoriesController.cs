using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Data;
using NorthwindTraders.Domain;

namespace NorthwindTraders.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {

        private readonly NorthwindContext _context;

        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.Select(c =>
                new Category
                {
                   CategoryId = c.CategoryId,
                   CategoryName = c.CategoryName,
                   Description = c.Description
                });
        }



    }
}