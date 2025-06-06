﻿using MediatR;
using MovieApi.Application.Features.Mediator.Results.TagResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Queries.TagQueries
{
    public class GetTagByIdQuery : IRequest<GetTagByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTagByIdQuery(int id)
        {
            Id = id;
        }
    }
}
