using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce01.Classes;
using Ecommerce01.Models;

namespace Ecommerce01.Controllers
{
    public class UsersController : Controller
    {
        private Ecommerce01Context db = new Ecommerce01Context();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.City).Include(u => u.Company).Include(u => u.Departament).Include(u => u.Province);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(DropDownHelper.GetCities(), "CityId", "Name");
            ViewBag.CompanyId = new SelectList(DropDownHelper.GetCompanies(), "CompanyId", "Name");
            ViewBag.DepartamentId = new SelectList(DropDownHelper.GetDepartaments(), "DepartamentId", "Name");
            ViewBag.ProvinceId = new SelectList(DropDownHelper.GetProvinces(), "ProvinceId", "Name");
            return View();
        }

        // POST: Users/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,FirstName,LastName,DateBirth,Phone,Address,Photo,PhotoFile,DepartamentId,ProvinceId,CityId,CompanyId")] User user)
        {

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                try
                {
                    db.SaveChanges();


                    //attention Role
                    UsersHelper.CreateUserAsp(user.UserName, "User");
                    var folder = "~/Content/Users";
                    //can be extention png,jpeg,gif,jpg
                    var file = string.Format("{0}.jpg", user.UserId);

                    if (user.PhotoFile != null)
                    {
                        var response = FilesHelper.UploadPhoto(user.PhotoFile, folder, file);
                        if (response)
                        {
                            var pic = string.Format("{0}/{1}", folder, file);
                            user.Photo = pic;
                            db.Entry(user).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewBag.CityId = new SelectList(DropDownHelper.GetCities(), "CityId","Name", user.CityId);
            ViewBag.CompanyId = new SelectList(DropDownHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartamentId = new SelectList(DropDownHelper.GetDepartaments(), "DepartamentId", "Name", user.DepartamentId);
            ViewBag.ProvinceId = new SelectList(DropDownHelper.GetProvinces(), "ProvinceId", "Name", user.ProvinceId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(DropDownHelper.GetCities(), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(DropDownHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartamentId = new SelectList(DropDownHelper.GetDepartaments(), "DepartamentId", "Name", user.DepartamentId);
            ViewBag.ProvinceId = new SelectList(DropDownHelper.GetProvinces(), "ProvinceId", "Name", user.ProvinceId);
            return View(user);
        }

        // POST: Users/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,FirstName,LastName,DateBirth,Phone,Address,Photo,PhotoFile,DepartamentId,ProvinceId,CityId,CompanyId")] User user)
        {
            if (ModelState.IsValid)
            {
                var folder = "~/Content/Users";
                var file = string.Format("{0}.jpg", user.UserId);
                if (user.PhotoFile != null)
                {
                    var pic = string.Format("{0}/{1}.jpg", folder, file);
                    var response = FilesHelper.UploadPhoto(user.PhotoFile, folder, file);
                    user.Photo = pic;
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.CityId = new SelectList(DropDownHelper.GetCities(), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(DropDownHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartamentId = new SelectList(DropDownHelper.GetDepartaments(), "DepartamentId", "Name", user.DepartamentId);
            ViewBag.ProvinceId = new SelectList(DropDownHelper.GetProvinces(), "ProvinceId", "Name", user.ProvinceId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
