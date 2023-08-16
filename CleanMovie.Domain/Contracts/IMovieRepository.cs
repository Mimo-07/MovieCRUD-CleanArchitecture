using CleanMovie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain.Interfaces
{
    public interface IMovieRepository
    {
        int CreateMovie(Movie movie);
        List<Movie> GetAllMovies();
        int UpdateMovie(string movieName,Movie updatedMovie);
        int DeleteMovie(string movieName);
    }
}
