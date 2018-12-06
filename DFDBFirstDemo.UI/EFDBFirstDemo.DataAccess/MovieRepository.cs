using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFDBFirstDemo.DataAccess
{
    class MovieRepository : IMovieRepository
    {
        public MoviesDBContext Db { get; }

        public MovieRepository(MoviesDBContext db)
        {
            Db = db;
        }

        public void CreateMovie(Movie movie)
        {
            Db.Add(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            Db.Remove(movie);
        }

        public void EditMovie(Movie movie)
        {
            var oldMovie = Db.Movie.Single(m => m.Id == movie.Id);
            oldMovie = movie;
        }

        public IList<Movie> GetAllMovies()
        {
            IList<Movie> movies = new List<Movie>();

            movies = Db.Movie.Include(m => m.Genre).ToList();

            return movies;
        }

        public IList<Movie> GetALlMoviesWithGeneres()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            return Db.Movie.Single(m => m.Id == id);
        }

        public Movie GetMovieByName(string name)
        {
            return Db.Movie.Single(m => m.Name == name);

        }
    }
}
