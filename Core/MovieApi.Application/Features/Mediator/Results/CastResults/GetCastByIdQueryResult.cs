using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Results.CastResults
{
    public class GetCastByIdQueryResult 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? Overview { get; set; }
        public string? Biography { get; set; }
    }
}
