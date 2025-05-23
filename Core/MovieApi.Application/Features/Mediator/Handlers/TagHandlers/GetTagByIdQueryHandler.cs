using MediatR;
using MovieApi.Application.Features.Mediator.Queries.TagQueries;
using MovieApi.Application.Features.Mediator.Results.TagResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetTagByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Tags.FindAsync(request.Id);
            return new GetTagByIdQueryResult
            {
                Title = value.Title
            };
        }
    }
}
