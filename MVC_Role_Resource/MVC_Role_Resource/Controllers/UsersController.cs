using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Role_Resource.Models;
using MVC_Role_Resource.Models.RoleResource;
using MVC_Role_Resource.ViewModel;

namespace MVC_Role_Resource.Controllers
{
    public class UsersController : Controller
    {
        private RoleResourceDBContext db = new RoleResourceDBContext();

        // GET: Users
        public ActionResult Index()
        {
            var userVMs = db.SecUsers.Include(u => u.Role);
            return View(userVMs.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecUser user = db.SecUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.SecRoles, "Id", "RoleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LogInName,Password,Email,Status,RoleId")] SecUser userVM)
        {
            if (ModelState.IsValid)
            {
                userVM.CreatedBy = 1;
                userVM.CreationDateTime = DateTime.Now;
                db.SecUsers.Add(userVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.SecRoles, "Id", "RoleName", userVM.RoleId);
            return View(userVM);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecUser userVM = db.SecUsers.Find(id);
            if (userVM == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.SecRoles, "Id", "RoleName", userVM.RoleId);
            return View(userVM);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LogInName,Password,Email,Status,RoleId")] SecUser userVM)
        {
            if (ModelState.IsValid)
            {
                var user = db.SecUsers.FirstOrDefault(r => r.Id == userVM.Id);
                if (user != null)
                {
                    user.ModifiedBy = 1;
                    user.ModificationDateTime = DateTime.Now;
                    user.Status = userVM.Status;
                    user.LogInName = userVM.LogInName;
                    user.Password = userVM.Password;
                    user.Email = userVM.Email;
                    user.RoleId = userVM.RoleId;
                    db.Entry(user).State = EntityState.Modified;
                    
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.SecRoles, "Id", "RoleName", userVM.RoleId);
            return View(userVM);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecUser userVM = db.SecUsers.Find(id);
            if (userVM == null)
            {
                return HttpNotFound();
            }
            return View(userVM);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecUser userVM = db.SecUsers.Find(id);
            db.SecUsers.Remove(userVM);
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
