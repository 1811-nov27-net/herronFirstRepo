using EFDBFirstDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace EFDBFirstDemo.Testing.DataAccess
{
    public class MovieRepositoryTest
    {

        // we want to use a new database for each test
        // and a new dbcontext for each of the three steps.
        [Fact]
        public void SaveChangesWithNoChangesDoesntThrowException()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MoviesDBContext>().UseInMemoryDatabase("no_changes_test").Options;
            using (var db = new MoviesDBContext(options))
            {
                // do nothing
                // (just creating the DbContext class with in-memory options
                // automatically creates the in-memory DB too.)
            }


            // act
            using (var db = new MoviesDBContext(options))
            {
                var repo = new MovieRepository(db);
                repo.SaveChanges(); // assert
            }


        }

        [Fact]
        public void CreateMovieWorks()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MoviesDBContext>().UseInMemoryDatabase("createmovie_test").Options;
            using (var db = new MoviesDBContext(options))
            {
                db.Genre.Add(new Genre { Name = "Eyyy" });
                db.SaveChanges();
            }


            // act
            using (var db = new MoviesDBContext(options))
            {
                var repo = new MovieRepository(db);
                Movie movie = new Movie { Name = "Bea" };
                repo.CreateMovie(movie, "Eyyy");
                repo.SaveChanges();
            }

            // assert
            using (var db = new MoviesDBContext(options))
            {
                Movie movie = db.Movie.Include(m => m.Genre).First(m => m.Name == "Bea");
                Assert.Equal("Bea", movie.Name);
                Assert.NotNull(movie.Genre);
                Assert.Equal("Eyyy", movie.Genre.Name);
                Assert.NotEqual(0, movie.Id);

            }
        }

        [Fact]
        public void CreateMovieWithoutSaveChangesDoesntWork()
        {
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<MoviesDBContext>()
                .UseInMemoryDatabase("createmovienosavechanges_test").Options;
            using (var db = new MoviesDBContext(options))
            {
                db.Genre.Add(new Genre { Name = "a" });
                db.SaveChanges();
            }
            // act (for act, only use the repo, to test it)
            using (var db = new MoviesDBContext(options))
            {
                var repo = new MovieRepository(db);
                Movie movie = new Movie { Name = "b" };
                repo.CreateMovie(movie, "a");
                // not calling repo.SaveChanges
            }
            // assert (for assert, once again use the context directly for verify.)
            using (var db = new MoviesDBContext(options))
            {
                // FirstOrDefault returns null if not found.
                Movie movie = db.Movie.Include(m => m.Genre).FirstOrDefault(m => m.Name == "b");
                Assert.Null(movie);
            }
        }

        [Fact]
        public void DeleteMovieWorks()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MoviesDBContext>().UseInMemoryDatabase("deletemovie_test").Options;
            using (var db = new MoviesDBContext(options))
            {
                db.Genre.Add(new Genre { Name = "Eyyy" });
                var repo = new MovieRepository(db);
                Movie movie = new Movie { Name = "Bea" };
                repo.CreateMovie(movie, "Eyyy");
                repo.SaveChanges();
            }


            // act
            using (var db = new MoviesDBContext(options))
            {
                var repo = new MovieRepository(db);
                Movie movie = repo.GetMovieById(1);
                repo.DeleteMovie(movie);
                db.SaveChanges();
            }

            // assert
            using (var db = new MoviesDBContext(options))
            {
                // FirstOrDefault returns null if not found.
                Movie movie = db.Movie.Include(m => m.Genre).FirstOrDefault(m => m.Name == "Bea");
                Assert.Null(movie);
            }
        }

        [Fact]
        public void EditMovieWorks()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MoviesDBContext>().UseInMemoryDatabase("editmovie_test").Options;
            using (var db = new MoviesDBContext(options))
            {
                db.Genre.Add(new Genre { Name = "Eyyy" });
                var repo = new MovieRepository(db);
                Movie movie = new Movie { Name = "Bea" };
                repo.CreateMovie(movie, "Eyyy");
                repo.SaveChanges();
            }


            // act
            using (var db = new MoviesDBContext(options))
            {
                var repo = new MovieRepository(db);
                Movie movie = repo.GetMovieById(1);
                movie.Name = "Sea";
                repo.EditMovie(movie);
                db.SaveChanges();
            }
            // assert
            using (var db = new MoviesDBContext(options))
            {
                Movie movie = db.Movie.Include(m => m.Genre).First(m => m.Id == 1);
                Assert.Equal("Sea", movie.Name);
                Assert.NotNull(movie.Genre);
                Assert.Equal("Eyyy", movie.Genre.Name);
                Assert.NotEqual(0, movie.Id);

            }
        }


    }

}
