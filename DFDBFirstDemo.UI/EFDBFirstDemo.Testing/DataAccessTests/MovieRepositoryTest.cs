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
                repo.CreateMovie( movie, "Eyyy");
                repo.SaveChanges();
            }

            // assert
            using (var db = new MoviesDBContext(options))
            {
                Movie movie = db.Movie.First(m => m.Name == "Bea");
                Assert.Equal("Bea", movie.Name);
                Assert.NotNull(movie.Genre);
                Assert.Equal("Eyyy", movie.Genre.Name);
                Assert.NotEqual(0, movie.Id);

            }


        }

    }
}
