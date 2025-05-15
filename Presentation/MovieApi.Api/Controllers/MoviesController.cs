using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRS.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRS.Commands.MovieCommands;
using MovieApi.Application.Features.CQRS.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRS.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRS.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRS.Queries.MovieQueries;

namespace MovieApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;

        public MoviesController(GetMovieByIdQueryHandler getCategoryQueryHandler, GetMovieQueryHandler getMovieQueryHandler, RemoveMovieCommandHandler removeMovieCommandHandler, CreateMovieCommandHandler createMovieCommandHandler, GetMovieByIdQueryHandler getMovieByIdQueryHandler, UpdateMovieCommandHandler updateMovieCommandHandler)
        {
            _getMovieQueryHandler = getMovieQueryHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var values = await _getMovieQueryHandler.Handle();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Başarılı");
        }
        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Başarılı");
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Başarılı");
        }
    }
}
