﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Commands.MovieCommands
{
    public class RemoveMovieCommand
    {
        public int Id { get; set; }

        public RemoveMovieCommand(int id)
        {
            Id = id;
        }
    }
}
