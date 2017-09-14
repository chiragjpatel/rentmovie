using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Web.Http;
using System.Web.UI.WebControls;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private byte[] _buffer;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [System.Web.Mvc.HttpGet]
        // GET: Customers
        public ActionResult Index()
        {
            var customer = _context.Customers.Where(c=>c.IsDeleted==false).Include(c => c.MembershipType).ToList();
            return View(customer);
        }
        [System.Web.Mvc.HttpGet]

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=>c.Id == id);


            return View(customer);
        }
        [System.Web.Mvc.HttpPost]

        public ActionResult Create()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var vm = new CustomerVM
            {
                Customer = null,
                MembershipTypes = membershiptypes
            };

            return View(vm);

         }
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)

            {
                var vm = new CustomerVM
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
                return View("Create", vm);
            }



            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            var customerinDb = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            var vm = new CustomerVM
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = customerinDb
            };
            return View(vm);
        }
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var vm = new CustomerVM
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("Edit", vm);
            }
            var customerinDb = _context.Customers.SingleOrDefault(c =>c.Id == customer.Id);

            if (customerinDb == null)

                throw new NullReferenceException();

            customerinDb.Name = customer.Name;
            customerinDb.BirthDate = customer.BirthDate;
            customerinDb.MembershipType= customer.MembershipType;
            customerinDb.IsSubscribeToNewsletter= customer.IsSubscribeToNewsletter;


            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            var customerinDb = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c=>c.Id == id);
            if (customerinDb == null || customerinDb.IsDeleted == true)
            throw new Exception("Customer not found");
            return View(customerinDb);
        }
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customerinDb = _context.Customers.Find(id);
            if (customerinDb != null)
                customerinDb.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase uploadImage)
        {

            byte[] imgData = null;

            using (var BinaryReader =  new BinaryReader(uploadImage.InputStream) )
            {
                imgData = BinaryReader.ReadBytes(uploadImage.ContentLength);
            }

            return View();
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult ViewImage(int id)
        {
            var img = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (img != null)

                _buffer = img.Image;


            return File(_buffer, "image/jpg", $"{id}.jpg");
            }
    }
}