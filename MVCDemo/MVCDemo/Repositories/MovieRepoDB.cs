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
            _db.Add(Map(movie));
            _db.SaveChanges();

        }

        public bool DeleteMovie(int id)
        {
            try
            {
                _db.Remove(_db.Movie.Find(id));
                _db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public void EditMovie(Movie movie)
        {
            _db.Entry(_db.Movie.Find(movie.Id)).CurrentValues.SetValues(Map(movie));
            _db.SaveChanges();

        }

        public int GetCastID(string name)
        {
            return _db.CastMember.Where(c => c.Name == name).First().Id;
        }

        public ICollection<Data.CasteMember> GetCasteMembers(Movie movie)
        {
            return  _db.CastMember.Include(c => c.Movie.Id == movie.Id).ToList();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _db.Movie.Include(m => m.CastMembers).Select(Map);

            // deferred - no network access yet.
        }

        public IEnumerable<Movie> GetAll(string cast)
        {
            return _db.CastMember.Include(c => c.Movie).ThenInclude(m => m.CastMembers).Where(c => c.Name == cast).Select(c => Map(c.Movie));

            //return _db.Movie.Include(m => m.CastMembers).Select(m => Map(m));

            // deferred - no network access yet.
        }

        public Movie GetById(int id)
        {
            return _db.Movie.Where(m => m.Id == id).Include(m => m.CastMembers).Select(m => Map(m)).First();

        }

        private Movie Map(Data.Movie movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Cast = movie.CastMembers.Select(c => c.Name).ToList()

            };
        }

        private Data.Movie Map(Movie movie)
        {
            Data.Movie ret = new Data.Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
            };
            foreach (var cast in movie.Cast)
            {
                ret.CastMembers.Add(new Data.CasteMember { Name = cast, Id = GetCastID(cast) });
            }

            return ret;
        }

    }
}
