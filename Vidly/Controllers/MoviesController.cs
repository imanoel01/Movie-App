using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> movies() {


            List<Movie> movie = new List<Movie>
            {
                new Movie{Id=1,Title="Lord of the Rings",Description="Epic Movie"},
                new Movie{Id=2,Title="Hobbit",Description="Desolution of the Sumg"},
                new Movie{Id=3,Title="Count of Monte Cristo",Description="Love, Deceit,Conspiracy, Revenge"},
                new Movie{Id=4,Title="A Fall From Grace",Description="Love,Betrayal"},
                new Movie{Id=5,Title="Mary",Description="Gansgtar"}

            };
            return movie;
} 

        // GET: Movies
        public ActionResult Index()
        {
            return View( movies());
        }

        public ActionResult Detail( int? id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return RedirectToAction("Index");
            }
            var movie = (from m in movies() where m.Id == id select m).FirstOrDefault();
            return View(movie);
        }
    }
}