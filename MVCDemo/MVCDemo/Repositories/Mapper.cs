using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data = MVCDemo.DataAccess;
using MVCDemo.Models;


namespace MVCDemo.Repositories
{
    public class Mapper
    {

        //public static Movie Map(Data.Movie movie)
        //{
        //    return new Movie
        //    {
        //        Id = movie.Id,
        //        Title = movie.Title,
        //        ReleaseDate = movie.ReleaseDate,
        //        Cast = movie.CastMembers.Select(c => c.Name).ToList()

        //    };
        //}

        //public static Data.Movie Map(Movie movie)
        //{
        //    Data.Movie ret = new Data.Movie
        //    {
        //        Id = movie.Id,
        //        Title = movie.Title,
        //        ReleaseDate = movie.ReleaseDate,
        //    };
        //    foreach (var cast in movie.Cast)
        //    {
        //        ret.CastMembers.Add(new Data.CasteMember { Name = cast, Id = MovieRepoDB.GetCastID(cast) });
        //    }

        //    return ret;
        //}


    }
}
