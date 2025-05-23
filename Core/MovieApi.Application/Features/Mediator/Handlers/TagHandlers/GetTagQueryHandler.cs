using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly MovieContext _context;

        public GetTagQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Tags.ToListAsync();
            return values.Select(t => new GetTagQueryResult
            {
                Id = t.Id,
                Title = t.Title
            }).ToList();
        }
    }
}
