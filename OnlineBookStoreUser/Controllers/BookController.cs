using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class BookController : Controller
    {
        private readonly Book_Store_DbContext _context;

        public BookController(Book_Store_DbContext context)
        {
            _context = context;
        }

        public IActionResult BookCategoryIndex()
        {
            //ViewBag.bookcategoryAuthor = _context.Books.Include(c => c.Author).ToList();
            //ViewBag.bookcategoryPublication = _context.Books.Include(p => p.Publication).ToList();
            //ViewBag.bookcategoryBook = _context.Books.Include(b => b.BookCategory).ToList();

            var book = _context.Books.ToList();
            return View(book);
        }

        [Route("details")]
        public ActionResult Details(int id)
        {
            var book = _context.Books.Where(x => x.BookId == id);
            return View(book);
        }

        public IActionResult Display(int id)
        {
            var book = _context.Books.Where(x => x.BookId == id);
            return View(book);
        }
    }
}