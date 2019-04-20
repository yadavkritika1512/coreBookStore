using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreBookStore.Controllers
{
    [Route("Publication")]

    public class PublicationController : Controller
    {
        private readonly BookStoreDbContext _context;

        public PublicationController(BookStoreDbContext context)
        {
            _context = context;
        }
        [Route("index")]
        public ViewResult Index()
        {
            var publications = _context.Publications.ToList();
            return View(publications);
        }
        [Route("create")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [Route("create")]
        [HttpPost]
        public ActionResult Create([Bind("PublicationName,PublicationDescription,PublicationImage")]Publication p1)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.GetString("uname");
               
                _context.Publications.Add(p1);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(p1);
        }
        [Route("details")]
        public ActionResult Details(int id)
        {
            Publication Pub = _context.Publications.Where(x => x.PublicationId == id).SingleOrDefault();
            _context.SaveChanges();
            return View(Pub);
        }
        [Route("delete")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Publication Pub = _context.Publications.Find(id);

            return View(Pub);
        }
        [HttpPost]
        public ActionResult Delete(int id, Author p1)
        {
            var Pub = _context.Publications.Where(x => x.PublicationId == id).SingleOrDefault();
            _context.Publications.Remove(Pub);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Publication Pub = _context.Publications.Where(x => x.PublicationId == id).SingleOrDefault();


            return View(Pub);
        }
        [Route("edit")]
        [HttpPost]
        public ActionResult Edit([Bind("PublicationName,PublicationDescription,PublicationImage")]Publication p1)
        {
            if (ModelState.IsValid)
            {
                Publication Pub = _context.Publications.Where
                (x => x.PublicationId == p1.PublicationId).SingleOrDefault();

                _context.Entry(Pub).CurrentValues.SetValues(p1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p1);
        }

        public object Edit(int id, Publication pub)
        {
            throw new NotImplementedException();
        }
    }
}