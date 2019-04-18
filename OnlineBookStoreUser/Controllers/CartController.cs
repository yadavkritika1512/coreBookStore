﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Helper;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    [Route("cart")]
    //index
    public class CartController : Controller
    {
        private readonly Book_Store_DbContext _context;

        public CartController(Book_Store_DbContext context)
        {
            _context = context;
        }
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int i = 0;


            if (cart != null)
            {
                foreach (var item in cart)
                {
                    i++;
                }
                if (i != 0)
                {
                    ViewBag.cart = cart;
                    ViewBag.total = cart.Sum(item => item.Books.BookPrice * item.Quantity);
                    return View();
                }
            }

            return View("EmptyCart");


        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> booklist = new List<Item>();

                booklist.Add(new Item
                {
                    Books = _context.Books.Find(id),
                    Quantity = 1
                });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", booklist);
            }


            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item
                    {
                        Books = _context.Books.Find(id),
                        Quantity = 1
                    });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }


            return RedirectToAction("Index", "Home");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            int i = 0;
            foreach (var item in cart)
            {
                i++;
            }

            if (cart == null)
            {
                HttpContext.Session.Remove("cart");
                return View("EmptyCart");

            }
            return RedirectToAction("Index");
        }

        public object EmptyCart(Customers customers)
        {
            throw new NotImplementedException();
        }

        public object EmptyCart(int id, Customers customers)
        {
            throw new NotImplementedException();
        }

        public object Details()
        {
            throw new NotImplementedException();
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Books.BookId.Equals(id))
                {
                    return i;
                }

            }
            return -1;
        }
        [Route("details")]
        public ActionResult Details(int id)
        {
            Books bk = _context.Books.Where(x => x.BookId == id).SingleOrDefault();
            _context.SaveChanges();
            return View(bk);
        }

        [Route("checkout/{id}")]
        [HttpGet]
        public IActionResult CheckOut(int id)
        {
            int i = 0;
            ViewBag.i = i;

            var customers = _context.Customers.Where(x => x.CustomerId == id).SingleOrDefault();

            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Books.BookPrice * item.Quantity);
            TempData["total"] = ViewBag.total;
            TempData["cid"] = id;
            return View(customers);
        }
        [Route("checkout/{id}")]
        [HttpPost]
        public IActionResult CheckOut(int id, Customers c)
        {
            // var cid = (TempData["cid"]).ToString();
            //context.Customers.Add(c);
            //context.SaveChanges();

            Orders ord = new Orders()
            {
                OrderAmount = Convert.ToSingle(TempData["total"]),
                OrderDate = DateTime.Now,
                CustomerId = id
            };
            _context.Orders.Add(ord);
            _context.SaveChanges();
            //    return RedirectToAction("Payment");
            //}
            //return View(customers);

            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            List<OrderBooks> orderBooks = new List<OrderBooks>();
            for (int i = 0; i < cart.Count; i++)
            {
                OrderBooks orderBook = new OrderBooks()
                {
                    OrderId = ord.OrderId,
                    BookId = cart[i].Books.BookId,
                    Quantity = cart[i].Quantity
                };
                orderBooks.Add(orderBook);
            }
            orderBooks.ForEach(n => _context.OrderBooks.Add(n));
            _context.SaveChanges();
            TempData["cust"] = id;
            return RedirectToAction("Invoice", "Cart");
        }

        //return View(customers);

        [Route("emptycart")]
        [HttpGet]

        public IActionResult EmptyCart()
        {
            var customer = _context.Customers.ToList();
            return View(customer);
        }
        [Route("invoice")]
        [HttpGet]
        public IActionResult Invoice()
        {
            int CustId = int.Parse(TempData["cust"].ToString());
            Customers customers = _context.Customers.Where(x => x.CustomerId == CustId).SingleOrDefault();
            ViewBag.Customers = customers;
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Books.BookPrice * item.Quantity);
            TempData["total"] = ViewBag.total;
            HttpContext.Session.Remove("cart");
            return View();


        }

        [Route("Plus")]
        [HttpGet]
        public IActionResult Plus(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (index != -1)
            {
                cart[index].Quantity++;

            }

            else
            {
                cart.Add(new Item
                {
                    Books = _context.Books.Find(id),
                    Quantity = 1
                });
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        [Route("Minus")]
        [HttpGet]
        public IActionResult Minus(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (index != -1)
            {
                if (cart[index].Quantity != 1)
                {
                    cart[index].Quantity--;
                }
                else
                    return RedirectToAction("Remove", "Cart", new { @id = id });
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

    }
}