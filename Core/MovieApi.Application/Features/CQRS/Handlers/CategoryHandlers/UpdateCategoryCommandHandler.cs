using MovieApi.Application.Features.CQRS.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRS.Commands.MovieCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _movieContext;

        public UpdateCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _movieContext.Categories.FindAsync(command.Id);
            value.Name = command.Name;
            await _movieContext.SaveChangesAsync();
        }
    }
}
