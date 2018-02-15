﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce01.Models;

namespace Ecommerce01.Controllers
{
    [Authorize(Roles = "User")]
    public class CategoriesController : Controller
    {
        private Ecommerce01Context db = new Ecommerce01Context();
        private User user;

        // GET: Categories
        public ActionResult Index()
        {
            user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                //error message ?
                return RedirectToAction("Index", "Home");
            }
            var categories = db.Categories.Where(c => c.CompanyId == user.CompanyId).OrderBy(c => c.Description);
           // categories = categories.OrderBy(d => d.Name).ToList();
            return View(categories.ToList());            
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            //ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name");
            user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var category = new Category()
            {
                CompanyId = user.CompanyId
            };
            return View(category);
          
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Description,CompanyId")] Category category)
        {
            if (ModelState.IsValid)
            {
                //
                if (db.Categories.Any(d => d.Description.Equals(category.Description)))
                {
                    ModelState.AddModelError(string.Empty, "Esiste già un Registro con lo stesso valore");
                }
                else
                {
                    db.Categories.Add(category);
                    try
                    {
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }
            //ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", category.CompanyId);
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", category.CompanyId);
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Description,CompanyId")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (db.Categories.Any(c => c.Description.Equals(category.Description)))
                {
                    ModelState.AddModelError(string.Empty, "Esiste già un Registro con lo stesso valore");
                }
                else
                {
                    ////
                    db.Entry(category).State = EntityState.Modified;
                    try
                    {
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        //if (exception.InnerException?.InnerException != null && exception.InnerException.InnerException.Message.Contains("_Index"))
                        //{
                        //    ModelState.AddModelError(string.Empty," 2 Esiste già un Registro con lo stesso valore");
                        //}
                        //else
                        //{
                        ModelState.AddModelError(string.Empty, ex.Message);
                        //}
                        return View(category);
                    }
                }
            }
               
            //ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", category.CompanyId);
            return View(category);
    }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
