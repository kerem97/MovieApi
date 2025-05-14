﻿using MovieApi.Application.Features.CQRS.Commands.CategoryCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _movieContext;

        public RemoveCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async void Handle(RemoveCategoryCommand command)
        {
            var value = await _movieContext.Categories.FindAsync(command.Id);
            _movieContext.Categories.Remove(value);
            await _movieContext.SaveChangesAsync();
        }
    }
}
