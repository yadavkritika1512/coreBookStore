﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Models;

namespace coreBookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BookStoreDbContext _context;

        public AuthorController(BookStoreDbContext context)
        {
            _context = context;
        }
        public ViewResult Index()
        {
            var auth = _context.Authors.ToList();
            return View(auth);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
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

        public object Details()
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(int id)
        {
            Author Authr = _context.Authors.Where(x => x.AuthorId == id).SingleOrDefault();
            _context.SaveChanges();
            return View(Authr);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Author auth = _context.Authors.Find(id);
            return View(auth);
        }
        [HttpPost]
        public ActionResult Delete(int id, Author d1)
        {
            var auth = _context.Authors.Where(x => x.AuthorId == id).SingleOrDefault();
            _context.Authors.Remove(auth);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Author Authr = _context.Authors.Where(x => x.AuthorId == id).SingleOrDefault();


            return View(Authr);
        }
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