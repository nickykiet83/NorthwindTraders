using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NorthwindTraders.Data;
using NorthwindTraders.Domain;

namespace NorthwindTraders.Commands.Categories
{
    public class SaveCategoryCommand : IRequest<Category>
    {
        public SaveCategoryCommand(Category category)
        {
            this.Category = category;
        }
        public Category Category { get; private set; }
    }


    public class SaveCategoryHandler : IAsyncRequestHandler<SaveCategoryCommand, Category>
    {
        private readonly NorthwindContext _dataCtx;

        public SaveCategoryHandler(NorthwindContext dataCtx)
        {
            _dataCtx = dataCtx;
        }


        public async Task<Category> Handle(SaveCategoryCommand message)
        {
            var model = message.Category;
            var entity = _dataCtx.Categories.FirstOrDefault(c => c.CategoryId == model.CategoryId) ?? new Category();

            entity.CategoryName = model.CategoryName;
            entity.Description = model.Description;

            if (entity.CategoryId == 0)
            {
                await _dataCtx.Categories.AddAsync(entity);
            }
            await _dataCtx.SaveChangesAsync();

            return entity;
        }
    }
}
