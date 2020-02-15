using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
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
    }
}