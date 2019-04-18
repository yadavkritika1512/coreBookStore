using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using coreBookStore.Models;

namespace coreBookStore.Controllers
{
    [Route("account")]

    public class AdminController : Controller
    {
        private readonly BookStoreDbContext _context;

        public AdminController(BookStoreDbContext context)
        {
            _context = context;
        }
        [Route("")]
            [Route("index")]
            [Route("~/")]
            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
            [HttpPost]
            public IActionResult Login(string username, string password)
            {
                if (username != null && password != null && username.Equals("harshita") && password.Equals("123"))
                {
                    HttpContext.Session.SetString("uname", username);
                    return View("Home");
                }
                else
                {
                    ViewBag.Error = "Invalid Credential";
                    return View("Index");
                }

            }
        [Route("Home")]

        public IActionResult Home()
        {
            return View();
        }

      

        [Route("logout")]
            [HttpGet]
            public IActionResult Logout()
            {
                HttpContext.Session.Remove("uname");
                return RedirectToAction("Index");
            }

 
    }
    }