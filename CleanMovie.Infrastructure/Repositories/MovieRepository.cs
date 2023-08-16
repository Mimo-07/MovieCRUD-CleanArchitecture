using CleanMovie.Domain.Entities;
using CleanMovie.Domain.Interfaces;
using CleanMovie.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure.Repositories
{
    internal class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext context;
        public MovieRepository(MovieDbContext _context)
        {
            context = _context;
        }

        public int CreateMovie(Movie movie)  //int return type given because to see whether records are updated or not
        {
            var movies = context.Movies.ToList();
            if(movies.Any(m => m.MovieName.Trim().Equals(movie.MovieName.Trim(),StringComparison.OrdinalIgnoreCase)))
            {
                return 0;
            }
            context.Movies.Add(movie);
            var result = context.SaveChanges();
            return result;
        }

        public List<Movie> GetAllMovies()
        {
            return context.Movies.ToList();
        }

        public int UpdateMovie(string movieName,Movie updatedMovie)
        {
            var oldMovie = context.Movies.FirstOrDefault<Movie>(m => String.Equals(movieName.ToLower().Trim(),m.MovieName.ToLower().Trim()));
            if(oldMovie != null)
            {
                oldMovie.MovieName = updatedMovie.MovieName;
                oldMovie.MovieCost = updatedMovie.MovieCost;
            }    
            return context.SaveChanges();
        }

        public int DeleteMovie(string movieName)
        {
            var existingMovie = context.Movies.FirstOrDefault<Movie>(m => String.Equals(movieName.ToLower().Trim(),m.MovieName.ToLower().Trim()));
            if(existingMovie != null)
            {
                context.Movies.Remove(existingMovie);
            }
            return context.SaveChanges();   
        }

        
    }
}
