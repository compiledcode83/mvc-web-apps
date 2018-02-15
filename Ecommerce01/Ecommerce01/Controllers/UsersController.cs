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
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private Ecommerce01Context db = new Ecommerce01Context();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users
                .Include(u => u.City)
                .Include(u => u.Company)
                .Include(u => u.Departament)
                .Include(u => u.Province);
            return View(users.OrderBy(u => u.UserName).ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             var user = db.Users.Find(id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,FirstName,LastName,DateBirth,Phone,Address,Photo,PhotoFile,DepartamentId,ProvinceId,CityId,CompanyId")] User user)
        {
            if (ModelState.IsValid)
            {
                //
                if (db.Users.Any(u => u.UserName.Equals(user.UserName)))
                {
                    ModelState.AddModelError(string.Empty, "Esiste già un Registro con lo stesso valore");
                }
                else
                {
                    db.Users.Add(user);
                    try
                    {
                        db.SaveChanges();
                        //attention Role User
                        UsersHelper.CreateUserAsp(user.UserName, "User");

                        if (user.PhotoFile != null)
                        {
                            var folder = "~/Content/Users";
                            //can be extention png,jpeg,gif,jpg
                            var file = string.Format("{0}.jpg", user.UserId);
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
            var user = db.Users.Find(id);
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
                    var pic = string.Format("{0}/{1}", folder, file);
                    var response = FilesHelper.UploadPhoto(user.PhotoFile, folder, file);
                    user.Photo = pic;
                }
                // if modify email ??? instanciate another db context
                var db_other = new Ecommerce01Context();
                //search user
                var currentUser = db_other.Users.Find(user.UserId);
                //validate ?
                if (currentUser.UserName != user.UserName)
                {
                    UsersHelper.UpdateUserName(currentUser.UserName, user.UserName);
                }
                //Pay attention
                if (currentUser.DateBirth != user.DateBirth)
                {
                    //UsersHelper.UpdateDataBirthUser(currentUser.UserName, user.UserName);
                    user.DateBirth = new DateTime(1971, 06, 19);
                   
                }

                db_other.Dispose();

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
            var user = db.Users.Find(id);
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
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            //last add
            UsersHelper.DeleteUser(user.UserName, "User");
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
