using MovieApi.Application.Features.CQRS.Commands.MovieCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public RemoveMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task Handle(RemoveMovieCommand command)
        {
            var value = await _movieContext.Movies.FindAsync(command.Id);
            _movieContext.Movies.Remove(value);
            await _movieContext.SaveChangesAsync();
        }
    }
}
