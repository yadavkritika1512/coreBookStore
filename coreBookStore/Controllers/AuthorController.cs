using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Models;

namespace coreBookStore.Controllers
{
    [Route("Author")]
    public class AuthorController : Controller
    {
        private readonly BookStoreDbContext _context;

        public AuthorController(BookStoreDbContext context)
        {
            _context = context;
        }
        [Route("index")]
        public ViewResult Index()
        {
            var auth = _context.Authors.ToList();
            return View(auth);
        }
        [Route("create")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [Route("create")]
        [HttpPost]
        public ActionResult Create([Bind("AuthorName,AuthorDescription,AuthorImage")]Author a1)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(a1);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(a1);
        }

        [Route("details")]
        public object Details()
        {
            throw new NotImplementedException();
        }

        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            Author Authr = _context.Authors.Where(x => x.AuthorId == id).SingleOrDefault();
            _context.SaveChanges();
            return View(Authr);
        }
        [Route("delete")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Author auth = _context.Authors.Find(id);
            return View(auth);
        }
        [Route("delete/{id}")]
        [HttpPost]
        public ActionResult Delete(int id, Author d1)
        {
            var auth = _context.Authors.Where(x => x.AuthorId == id).SingleOrDefault();
            _context.Authors.Remove(auth);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [Route("edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Author Authr = _context.Authors.Where(x => x.AuthorId == id).SingleOrDefault();


            return View(Authr);
        }
        [Route("edit")]
        [HttpPost]
        public ActionResult Edit([Bind("AuthorName,AuthorDescription,AuthorImage")]Author a1)
        {
            if (ModelState.IsValid)
            {
                Author Authr = _context.Authors.Where
                (x => x.AuthorId == a1.AuthorId).SingleOrDefault();
                _context.Entry(Authr).CurrentValues.SetValues(a1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a1);
        }

        public object Edit(int id, Author auth)
        {
            throw new NotImplementedException();
        }
    }
}