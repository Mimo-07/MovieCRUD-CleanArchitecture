using CleanMovie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.IServices
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        int CreateMovie(Movie movie);   //int return type given because to see whether records are updated or not
        int UpdateMovie(string movieName,Movie updatedMovie);  
        int DeleteMovie(string movieName);
    }
}
