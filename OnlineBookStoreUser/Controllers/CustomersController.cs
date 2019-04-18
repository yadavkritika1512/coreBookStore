using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Helper;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class CustomersController : Controller
    {
        private readonly Book_Store_DbContext _context;

        public CustomersController(Book_Store_DbContext context)
        {
            _context = context;
        }




        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customers cust)
        {
            _context.Customers.Add(cust);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        public ActionResult Login(int id, Customers cust)
        {

            var user = _context.Customers.Where(x => x.UserName == cust.UserName && x.NewPassword.Equals(cust.NewPassword)).SingleOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Invalid Credential";
                return View("Login");
            }
            else
            {
                int custId = user.CustomerId;
                ViewBag.custName = cust.UserName;

                if (user != null)
                {

                    HttpContext.Session.SetString("uname", cust.UserName);
                    HttpContext.Session.SetString("id", user.CustomerId.ToString());

                    HttpContext.Session.SetString("cid", custId.ToString());
                    if (ViewBag.cart != null)
                        return RedirectToAction("CheckOut", "Cart", new { @id = custId });

                    else
                        return RedirectToAction("Profile", "Customers", new { @id = custId });



                }
                else
                {
                    ViewBag.Error = "Invalid Credential";
                    return View("Index");
                }

            }



        }
        public ActionResult Details(int id)
        {
            Customers cust = _context.Customers.Where(x => x.CustomerId == id).SingleOrDefault();
            //Books bk = context.Books.Where(x => x.BookId == id).SingleOrDefault();
            _context.SaveChanges();
            return View(cust);
        }
        [HttpGet]
        public ActionResult Logout()
        {

            return View();
            //HttpContext.Session.Remove("uname");
            //HttpContext.Session.Remove("id");
            //return RedirectToAction("Index", "Home");
        }

        [Route("profile")]
        public ActionResult Profile()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = _context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(cust);

        }
        [Route("edit")]
        [HttpGet]
        public ActionResult Edit()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = _context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(cust);
        }
        [Route("edit")]
        [HttpPost]
        public ActionResult Edit(int id, Customers a1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = _context.Customers.Where
                (x => x.CustomerId == custId).SingleOrDefault();
            _context.Entry(cust).CurrentValues.SetValues(a1);
            _context.SaveChanges();
            return RedirectToAction("Profile", new { @id = custId });
        }

        [Route("resetpassword")]
        [HttpGet]
        public ActionResult ResetPassword()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = _context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(cust);
        }
        [Route("resetpassword")]
        [HttpPost]
        public ActionResult ResetPassword(int id, Customers a1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = _context.Customers.Where
                (x => x.CustomerId == custId).SingleOrDefault();
            cust.NewPassword = a1.NewPassword;
            _context.SaveChanges();
            return RedirectToAction("Profile", new { @id = custId });
        }

        [Route("resetaddress")]
        [HttpGet]
        public ActionResult ResetAddress()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = _context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(cust);
        }
        [Route("resetpassword")]
        [HttpPost]
        public ActionResult ResetAddress(int id, Customers a1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = _context.Customers.Where
                (x => x.CustomerId == custId).SingleOrDefault();
            cust.Address = a1.Address;
            _context.SaveChanges();
            return RedirectToAction("Profile", new { @id = custId });
        }





        public IActionResult Repository()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = _context.Customers.Where
                (x => x.CustomerId == custId).SingleOrDefault();
            List<Orders> ord = _context.Orders.Where(x => x.CustomerId == cust.CustomerId).ToList();
            ViewBag.ord = ord;
            return View();
        }
        public IActionResult OrderDetail(int id)
        {
            List<OrderBooks> ob = new List<OrderBooks>();
            List<Books> books = new List<Books>();
            ob = _context.OrderBooks.Where(x => x.OrderId == id).ToList();
            foreach (var item in ob)
            {
                Books c = _context.Books.Where(x => x.BookId == item.BookId).SingleOrDefault();
                books.Add(c);
            }
            ViewBag.bookDetail = books;
            return View();
        }

        public ActionResult Repository(int id)
        {

            List<OrderBooks> ob = new List<OrderBooks>();
            List<Books> books = new List<Books>();
            ob = _context.OrderBooks.Where(x => x.OrderId == id).ToList();
            foreach (var item in ob)
            {
                Books c = _context.Books.Where(x => x.BookId == item.BookId).SingleOrDefault();
                books.Add(c);
            }
            ViewBag.bookDetail = books;
            return View();

        }

    }

}
