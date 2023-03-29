using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Application.Movies;

namespace API.Controllers
{
    public class MoviesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<MovieDTO>>> GetMovies()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(string id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
    }
}