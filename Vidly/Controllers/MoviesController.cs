using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //public List<Movie> movies()
        //{


        //    List<Movie> movie = new List<Movie>
        //    {
        //        new Movie{Id=1,Title="Lord of the Rings",Description="Epic Movie"},
        //        new Movie{Id=2,Title="Hobbit",Description="Desolution of the Sumg"},
        //        new Movie{Id=3,Title="Count of Monte Cristo",Description="Love, Deceit,Conspiracy, Revenge"},
        //        new Movie{Id=4,Title="A Fall From Grace",Description="Love,Betrayal"},
        //        new Movie{Id=5,Title="Mary",Description="Gansgtar"}

        //    };
        //    return movie;
        //}

        private VidlyDbContext _context;
        public MoviesController()
        {
            _context = new VidlyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }


        // GET: Movies
        public ActionResult Index()
        {
           var m= _context.Movie.Include(x=>x.Genre).ToList();
            
            return View(m);
        }

        public ActionResult Detail(int? id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return RedirectToAction("Index");
            }
            //var movie = (from m in movies() where m.Id == id select m).FirstOrDefault();
          var movieDetail=  _context.Movie.Include(x=>x.Genre).Where(c => c.Id == id).SingleOrDefault();

            return View(movieDetail);         
        }

        public ActionResult New()
        {

           var genre= _context.Genre.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genre
            };

            return View("MovieForm",viewModel);
        }
        public ActionResult Save(Movie movie )
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movie.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movie.Single(m => m.Id == movie.Id);

                movieInDb.Title = movie.Title;
                movieInDb.Description = movie.Description;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Stock = movie.Stock;
                movieInDb.GenreId = movie.GenreId;

            }

            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.Single(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}