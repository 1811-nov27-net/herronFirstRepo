using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// namespace alias to get around same-name classes
using Data = MVCDemo.DataAccess;
using MVCDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCDemo.Repositories
{
    public class MovieRepoDB : IMovieRepo
    {
        private readonly Data.MovieDBContext _db;

        public MovieRepoDB(Data.MovieDBContext db)
        {
            _db = db ?? throw new ArgumentException(nameof(db));
        }

        public void CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public void EditMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _db.Movie.Include(m => m.CastMembers).Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                Cast = m.CastMembers.Select(c => c.Name).ToList()
            });

            // deferred - no network access yet.
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
