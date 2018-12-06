using EFDBFirstDemo.DataAccess;
using EFDBFirstDemo.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DFDBFirstDemo.UI
{
    class Program
    {

        static DbContextOptions<MoviesDBContext> options = null;

        static void Main(string[] args)
        {
            var connectionString = SecretConfiguration.ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<MoviesDBContext>();

            optionsBuilder.UseSqlServer(connectionString);
            options = optionsBuilder.Options;

            PrintMovies();
            AddAMovie();
            Console.WriteLine();

        }

        static void PrintMovies()
        { 
            var movies = new List<Movie>();
            
            using (var db = new MoviesDBContext(options))
            {
                // at this point, haven't actually connected yet

                // this winds up as a "Select * from movies.movie" somewhere
                // movies = db.Movie.ToList();

                // does not fetch the full "entity graph" of the movie-
                // "navigation properties" like genra are null.

                movies = db.Movie.Include(m => m.Genre).ToList();

            }

            foreach (var item in movies)
            {
                Console.WriteLine($"movie ID{item.Id}, name {item.Name}, {item.Genre.Name}");
            }
            
        }

        static void AddAMovie()
        {
            using (var db = new MoviesDBContext(options))
            {
                var firstMovieQuery = db.Movie.Include(m=> m.Genre).OrderBy(m => m.Name);

                Movie movie = firstMovieQuery.First();


                Movie newMovie = new Movie { Name = movie.Name + " 2", Genre = movie.Genre };

                // a few ways to add
                db.Add(newMovie); // guesses which DbSet based on type

                // or
                // db.Movie.Add(newMovie);
                // or
                // movie.Genre.Movie.Add(newMovie);

                db.SaveChanges();

                // now extra properties on the new movie that we didn't set have been filled in by DB context.
                // can continue working and saveChanges multiple times on one dbcontext
            }
        }

        static void EditSomething()
        {
            using (var db = new MoviesDBContext(options))
            {
                var actionGenre = db.Genre.FirstOrDefault(g => g.Name == "Action");

                actionGenre.Name = "Action/Adventure";

                db.SaveChanges();
            }
        }

        static void AccessWithRepo()
        {
            using (var db = new MoviesDBContext(options))
            {
                IMovieRepository movieRepo = new MovieRepository(db);

                movieRepo.CreateMovie(new Movie { Name = "Harry Potter" }, "Action/Adventure");


            }
        }

    }
}
