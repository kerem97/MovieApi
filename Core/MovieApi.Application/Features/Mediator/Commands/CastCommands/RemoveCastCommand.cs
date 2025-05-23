using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Commands.CastCommands
{
    public class RemoveCastCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCastCommand(int id)
        {
            Id = id;
        }
    }
}
