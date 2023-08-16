using CleanMovie.Application.IServices;
using CleanMovie.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;
        public MoviesController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            Response.StatusCode = 200;
            return movieService.GetAllMovies();
        }

        [HttpPost]
        public ActionResult<int> PostMovie([FromBody] Movie movie)
        {
            if (movieService.CreateMovie(movie) == 0)
            {
                Response.StatusCode = 404;
                return Content($"{movie.MovieName} already added in database");
            }
            Response.StatusCode = 201;
            Content("Added Successfully");
            return movieService.CreateMovie(movie);
        }

        [HttpPut("{movieName}")]
        public ActionResult<int> UpdateMovie(string movieName, [FromBody]Movie updatedMovie)
        {
            if(movieService.UpdateMovie(movieName, updatedMovie) == 0) 
            {
                Response.StatusCode = 404;
                return Content("Movie not found");
            }
            Response.StatusCode = 200;
            Content("Updated successfully");
            return movieService.UpdateMovie(movieName, updatedMovie);
        }

        [HttpDelete("{movieName}")]
        public ActionResult<int> DeleteMovie(string movieName)
        {
            if (movieService.DeleteMovie(movieName) == 0)
            {
                Response.StatusCode = 404;
                return Content($"{movieName} not found ");
            }
            Response.StatusCode = 200;
            Content("Deleted successfully");
            return movieService.DeleteMovie(movieName);
        }

    }
}
