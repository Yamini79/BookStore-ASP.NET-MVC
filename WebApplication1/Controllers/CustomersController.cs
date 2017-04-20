using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using WebApplication1.Models;
using System.Data.Entity;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);
                customerInDb.name = customer.name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("CustList", "Customers");
        }
        // GET: Cutomers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustList()
        {
            var cust = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(cust);
        }
        /*public List<Customer> GetCustomers()
        {
            var li = new List<Customer>
            {
                new Customer {id=1, name="yamini" },
                new Customer {id=2, name="Praveena" }
            };
            return li;
        }**/
        public ActionResult Details(int id)
        {
            var det = _context.Customers.Include(c => c.MembershipType).ToList();
            foreach (var i in det)
            {
                if (i.id == id)
                {
                    return View(i);
                }
            }
            return Content("Customer Not found");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);

        }
    }
}