using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using System.Web.Security;
using System.Web.UI.WebControls;
using Vidly.ViewModel;
using Microsoft.AspNet.Identity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).Where(m => m.IsDeleted == false).ToList();
            if (User.IsInRole("CanManageMovies"))

                return View("List",movies);


            return View("ListReadOnly", movies);
        }

        [System.Web.Mvc.Authorize(Roles = "CanManageMovies")]
        // GET: Create Movie
        [System.Web.Mvc.HttpGet]
        public ActionResult Create()
        {
            if (!ModelState.IsValid)

                throw new HttpResponseException(HttpStatusCode.NotFound);

            var vm = new MovieVM
            {
                Movie = null,
                Genres = _context.Genres.ToList()
            };
            return View(vm);
        }


        // POST: Create Movie
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(Movie movie)
        {

            if (!ModelState.IsValid)
            {

                var vm = new MovieVM
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("Create", vm);

            }

            _context.Movies.Add(movie);

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");

        }

        // GET: Edit Movie
        [System.Web.Mvc.Authorize(Roles = "CanManageMovies")]

        public ActionResult Edit(int id)
        {
            if (!ModelState.IsValid)

                throw new HttpResponseException(HttpStatusCode.NotFound);

            var movieinDb = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            var vm = new MovieVM
            {
                Movie = movieinDb,
                Genres = _context.Genres.ToList()
            };
            return View(vm);
        }

        // POST: Edit Movie
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)

                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieinDb = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == movie.Id);

            if (movieinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            {
                movieinDb.Name = movie.Name;
                movieinDb.ReleaseDate = movie.ReleaseDate;
                movieinDb.StockQty = movie.StockQty;
                movieinDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        // GET: Delete Movie
        [System.Web.Mvc.Authorize(Roles = "CanManageMovies")]
        [System.Web.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }
        // POST: Delete Movie
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.HttpPost]
        public ActionResult DeleteRecord(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                movie.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


    }
}