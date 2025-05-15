using MovieApi.Application.Features.CQRS.Commands.MovieCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.Id);
            value.Rating = command.Rating;
            value.Title = command.Title;
            value.Description = command.Description;
            value.Status = command.Status;
            value.CoverImageUrl = command.CoverImageUrl;
            value.CreatedYear = command.CreatedYear;
            value.Duration = command.Duration;
            value.ReleaseDate = command.ReleaseDate;
            await _context.SaveChangesAsync();
        }
    }
}
