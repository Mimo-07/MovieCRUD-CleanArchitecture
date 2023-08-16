using CleanMovie.Application.IServices;
using CleanMovie.Domain.Entities;
using CleanMovie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        //Constructor Dependency Injection from Movie Repository
        public MovieService(IMovieRepository _movieRepository)
        {
            movieRepository = _movieRepository;
        }

        public int CreateMovie(Movie movie)  //int return type given because to see whether records are updated or not
        {
            return movieRepository.CreateMovie(movie);
        }

        public int DeleteMovie(string movieName)
        {
            return movieRepository.DeleteMovie(movieName);
        }

        public List<Movie> GetAllMovies()
        {
            return movieRepository.GetAllMovies();
        }

        public int UpdateMovie(string movieName, Movie updatedMovie)
        {
            return movieRepository.UpdateMovie(movieName,updatedMovie);
        }
    }
}
