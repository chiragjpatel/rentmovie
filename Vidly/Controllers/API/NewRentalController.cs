using System;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult CreateNewRental(NewRentalDto newrentaldto)
        {
            var customer = _context.Customers.Single(c => c.Id == newrentaldto.CustomerId);
            var movies = _context.Movies.Where(m => newrentaldto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.AvailableStockQty <= 0)
                    BadRequest("Movie - " + movie.Name +" is not available");
                movie.AvailableStockQty--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);


            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
