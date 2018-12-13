using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Repositories;

namespace MVCDemo.Controllers
{
    public class CastController : Controller
    {
        public IMovieRepo Repo { get; set; }

        public CastController(IMovieRepo repo)
        {
            Repo = repo;
        }
        // (1) convention routing - defined globally in Startup.cs

        //route parameter name defined in route
        public IActionResult Index(string name)
        {
            var movies = Repo.GetAll(name).ToList();
            return View(movies);
        }
    }
}