﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.Mediator.Commands.TagCommands;
using MovieApi.Application.Features.Mediator.Handlers.TagHandlers;
using MovieApi.Application.Features.Mediator.Queries.TagQueries;

namespace MovieApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagList()
        {
            var values = await _mediator.Send(new GetTagQuery());
            return Ok(values);
        }
        [HttpPost]

        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpGet("GetTag")]

        public async Task<IActionResult> GetTag(int id)
        {
            var value = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok("Başarılı");
        }
        [HttpPut]

        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }


    }
}
