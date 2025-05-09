using MovieApi.Application.Features.CQRS.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category
            {
                Name = command.Name,
            });
            await _context.SaveChangesAsync();
        }
    }
}
