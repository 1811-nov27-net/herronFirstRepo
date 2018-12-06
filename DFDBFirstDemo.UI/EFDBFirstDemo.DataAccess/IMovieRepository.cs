using System;
using System.Collections.Generic;
using System.Text;

namespace EFDBFirstDemo.DataAccess
{
    public interface IMovieRepository
    {
        // repository pattern abstracts details of data access to consumers
        // it will provide CRUD type methods
        //  Create, Read, Update, Delete
        // and hide details of database

        IList<Movie> GetAllMovies();
        IList<Movie> GetALlMoviesWithGeneres();
        Movie GetMovieById(int id);
        Movie GetMovieByName(string name);
        void DeleteMovie(Movie movie);
        void EditMovie(Movie movie);
        void CreateMovie(Movie movie);

    }
}
