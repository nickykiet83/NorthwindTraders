using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Data;
using NorthwindTraders.Domain;

namespace NorthwindTraders.Commands.Categories
{
    public class GetCategoriesCommand : IRequest<IEnumerable<Category>>
    {
    }



    public class GetCategoriesHandler : IAsyncRequestHandler<GetCategoriesCommand, IEnumerable<Category>>
    {

        private readonly NorthwindContext _dataCtx;

        public GetCategoriesHandler(NorthwindContext dataCtx)
        {
            _dataCtx = dataCtx;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoriesCommand message)
        {
            return await _dataCtx.Categories.Select(c => new Category()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description
            })
            .ToListAsync();
        }
    }
}
