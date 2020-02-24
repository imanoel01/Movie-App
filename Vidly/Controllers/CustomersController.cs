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
    public class CustomersController : Controller
    {
        private VidlyDbContext _context;

        public CustomersController()
        {
            _context = new VidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
       

        // GET: Customers
        public ActionResult Index()
        {
            var customer = _context.Customer.Include(c => c.MembershipType).ToList();
            return View(customer);
        }
        public ActionResult Detail(int? id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return RedirectToAction("Index");
            }
            //var c = customers();
            var customer = _context.Customer.Include(x=>x.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null) ;
            RedirectToAction("Index");

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipType = _context.MembershipType.ToList();
            var gender = _context.Gender.ToList();
            var viewModel = new CustomerFormViewModel() 
            {
            MembershipType=membershipType,
            Gender=gender
            
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                
            }
            if (customer.Id==0)
            _context.Customer.Add(customer);
            else
            {
                var CustomerInDb = _context.Customer.Single(c => c.Id == customer.Id);
                CustomerInDb.FirstName = customer.FirstName;
                CustomerInDb.MiddleName = customer.MiddleName;
                CustomerInDb.LastName = customer.LastName;
                CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDb.DOB = customer.DOB;
                CustomerInDb.GenderId = customer.GenderId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
        var customer=    _context.Customer.Single(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList(),
                Gender = _context.Gender.ToList()
            };

            return View("CustomerForm",viewModel);
        }
    }
}