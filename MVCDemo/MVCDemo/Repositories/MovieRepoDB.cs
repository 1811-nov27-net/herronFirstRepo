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

            db.Database.EnsureCreated();
        }

        public void CreateMovie(Movie movie)
        {
            _db.Add(Mapper.Map(movie, GetCasteMembers(movie)));
        }

        public bool DeleteMovie(int id)
        {
            try
            {
                _db.Remove(_db.Movie.Include(m => m.Id == id));
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public void EditMovie(Movie movie)
        {
            _db.Entry(_db.Movie.Find(movie.Id)).CurrentValues.SetValues(Mapper.Map(movie, GetCasteMembers(movie)));
        }

        public ICollection<Data.CasteMember> GetCasteMembers(Movie movie)
        {
            return (ICollection<Data.CasteMember>) _db.CastMember.Include(c => c.Movie.Id == movie.Id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _db.Movie.Include(m => m.CastMembers).Select(m => Mapper.Map(m));

            // deferred - no network access yet.
        }

        public Movie GetById(int id)
        {
            return Mapper.Map(_db.Movie.Include(m => m.Id == id).First());

        }
    }
}
