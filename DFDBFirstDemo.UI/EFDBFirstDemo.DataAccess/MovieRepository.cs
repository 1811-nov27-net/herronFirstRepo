using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFDBFirstDemo.DataAccess
{
    public class MovieRepository : IMovieRepository
    {
        public MoviesDBContext Db { get; }

        public MovieRepository(MoviesDBContext db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // id should be left at default 0
        public void CreateMovie(Movie movie, string withGenre)
        {
            Genre trackedGenre = Db.Genre.First(g => g.Name == withGenre);
            movie.Genre = trackedGenre;
            Db.Add(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            Movie trackedMovie = Db.Movie.Find(movie.Id);
            if(trackedMovie == null)
            {
                throw new ArgumentException("no such movie id", nameof(movie.Id));
            }
            Db.Remove(trackedMovie);
        }

        public void EditMovie(Movie movie)
        {
            Db.Update(movie);

            // var oldMovie = Db.Movie.Single(m => m.Id == movie.Id);
            // oldMovie = movie;

            Movie trackedMovie = Db.Movie.Find(movie.Id);
            Db.Entry(trackedMovie).CurrentValues.SetValues(movie);
        }

        public IList<Movie> GetAllMovies()
        {


            return Db.Movie.AsNoTracking().ToList();
        }

        public IList<Movie> GetALlMoviesWithGeneres()
        {
            return Db.Movie.Include(m => m.Genre).AsNoTracking().ToList();
        }

        public Movie GetMovieById(int id)
        {
            return Db.Movie.Single(m => m.Id == id);
        }

        public Movie GetMovieByName(string name)
        {
            return Db.Movie.Single(m => m.Name == name);

        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }
    }
}
