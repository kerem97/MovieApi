using MovieApi.Application.Features.CQRS.Queries.MovieQueries;
using MovieApi.Application.Features.CQRS.Results.MovieResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var value = await _context.Movies.FindAsync(query.Id);
            return new GetMovieByIdQueryResult
            {
                CreatedYear = value.CreatedYear,
                CoverImageUrl = value.CoverImageUrl,
                Rating = value.Rating,
                Duration = value.Duration,
                Description = value.Description,
                ReleaseDate = value.ReleaseDate,
                Status = value.Status,
                Title = value.Title
            };
        }
    }
}
