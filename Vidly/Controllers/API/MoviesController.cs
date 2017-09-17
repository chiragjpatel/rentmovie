using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        [HttpGet]
        public IHttpActionResult Movies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Where(m=>m.IsDeleted==false && m.AvailableStockQty>0 && m.Name.Contains(query))
                ;

            if (!string.IsNullOrEmpty(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

           var movieDto = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDtos>);

            return Ok(movieDto);
        }
        //GET /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            if (!ModelState.IsValid)

                return BadRequest();

            var movie = _context.Movies
                .SingleOrDefault(m => m.Id == id);

            if (movie != null && movie.IsDeleted)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDtos>(movie));
        }

        //POST /api/movies

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDtos moviedto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDtos, Movie>(moviedto);

            _context.Movies.Add(movie);

            _context.SaveChanges();

            moviedto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id),movie );
        }

        //PUT /api/movies/1

        [HttpPut]

        public IHttpActionResult EditMovie(int id, MovieDtos moviedto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieinDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieinDb == null)
                return NotFound();

           Mapper.Map(moviedto, movieinDb);
                _context.SaveChanges();


            return Ok();
        }
        //DELETE /api/movies/1

        [HttpDelete]

        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)

                return NotFound();
            movie.IsDeleted = true;

            var moviemapper = Mapper.Map<Movie, MovieDtos>(movie);


            _context.SaveChanges();
            return Ok(movie.Name + " has been deleted");
        }
    }
}
