﻿using MediatR;
using MovieApi.Application.Features.Mediator.Results.CastResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Queries.CastQueries
{
    public class GetCastByIdQuery : IRequest<GetCastByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCastByIdQuery(int id)
        {
            Id = id;
        }
    }
}
