using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreBookStore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly BookStoreDbContext _context;

        public CustomersController(BookStoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cust = _context.Customers.ToList();
            return View(cust);
        }

        public IActionResult Details(int id)
        {
            Customer cust = _context.Customers.Where(x => x.CustomerId == id).SingleOrDefault();
            _context.SaveChanges();
            return View(cust);
        }

        public object Details()
        {
            throw new NotImplementedException();
        }
    }
}