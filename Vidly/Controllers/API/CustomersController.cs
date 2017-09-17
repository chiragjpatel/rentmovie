using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/<controller>
        public IHttpActionResult GetGustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType)
                .Where(c => c.IsDeleted == false);

            if (!String.IsNullOrEmpty(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDtos>);


            return Ok(customerDtos);

        }

        // GET api/<controller>/5
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)

              return  NotFound();
            return Ok(Mapper.Map<Customer, CustomerDtos>(customer));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDtos customerdto)
        {

            if (!ModelState.IsValid)

               return BadRequest();

            var customer = Mapper.Map<CustomerDtos, Customer>(customerdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerdto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerdto);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult EditCustomer(int id, CustomerDtos customerdto)
        {


            if (!ModelState.IsValid)

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerinDb == null)

                NotFound();

            Mapper.Map(customerdto, customerinDb);
            _context.SaveChanges();

            return Ok(customerdto);

        }
        [HttpDelete]
        // DELETE api/<controller>/5
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)

                NotFound();

            if (customer != null) _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok(customer.Name + " : Has been deleted");
        }

    }
}
