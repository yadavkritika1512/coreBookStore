using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Models;

namespace coreBookStore.Controllers
{
    public class BookCategoryController : Controller
    {
        private readonly BookStoreDbContext _context;

        public BookCategoryController(BookStoreDbContext context)
        {
            _context = context;
        }
        public ViewResult Index()
        {
            var caty = _context.BookCategories.ToList();
            return View(caty);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind("BookCategoryName,BookCategoryDescription,BookCategoryImage")]BookCategory c1)
        {
            if (ModelState.IsValid)
            {
                _context.BookCategories.Add(c1);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(c1);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BookCategory caty = _context.BookCategories.Find(id);

            return View(caty);
        }
        [HttpPost]
        public ActionResult Delete(int id, BookCategory c1)
        {
            var caty = _context.BookCategories.Where(x => x.BookCategoryId == id).SingleOrDefault();
            _context.BookCategories.Remove(caty);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookCategory caty = _context.BookCategories.Where(x => x.BookCategoryId == id).SingleOrDefault();


            return View(caty);
        }
        [HttpPost]
        public ActionResult Edit([Bind("BookCategoryName,BookCategoryDescription,BookCategoryImage")]BookCategory c1)
        {
            if (ModelState.IsValid)
            {
                BookCategory caty = _context.BookCategories.Where(x => x.BookCategoryId == c1.BookCategoryId).SingleOrDefault();
                _context.Entry(caty).CurrentValues.SetValues(c1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c1);
        }
        public ActionResult Details(int id)
        {
            BookCategory caty = _context.BookCategories.Where(x => x.BookCategoryId == id).SingleOrDefault();
            _context.SaveChanges();
            return View(caty);
        }

        public object Edit(int id, BookCategory bookcategory)
        {
            throw new NotImplementedException();
        }
    }
}