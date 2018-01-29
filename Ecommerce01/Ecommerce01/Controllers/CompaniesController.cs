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
    public class CompaniesController : Controller
    {
        private Ecommerce01Context db = new Ecommerce01Context();

        // GET: Companies
        public ActionResult Index()
        {
            var companies = db.Companies.Include(c => c.City).Include(c => c.Departament).Include(c => c.Province);
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name");
            ViewBag.DepartamentId = new SelectList(db.Departaments, "DepartamentId", "Name");
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "Name");
            return View();
        }

        // POST: Companies/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,Name,ProvinceId,DepartamentId,CityId,AddressO,AddressL,Locality,Logo,PartitaIva,CodiceFiscale,Phone,PhoneMobil,Fax,Email,http")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", company.CityId);
            ViewBag.DepartamentId = new SelectList(db.Departaments, "DepartamentId", "Name", company.DepartamentId);
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "Name", company.ProvinceId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", company.CityId);
            ViewBag.DepartamentId = new SelectList(db.Departaments, "DepartamentId", "Name", company.DepartamentId);
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "Name", company.ProvinceId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyId,Name,ProvinceId,DepartamentId,CityId,AddressO,AddressL,Locality,Logo,PartitaIva,CodiceFiscale,Phone,PhoneMobil,Fax,Email,http")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", company.CityId);
            ViewBag.DepartamentId = new SelectList(db.Departaments, "DepartamentId", "Name", company.DepartamentId);
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "Name", company.ProvinceId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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
