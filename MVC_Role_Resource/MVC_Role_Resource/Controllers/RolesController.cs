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

namespace MVC_Role_Resource.Controllers
{
    public class RolesController : Controller
    {
        private RoleResourceDBContext db = new RoleResourceDBContext();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.SecRoles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecRole secRole = db.SecRoles.Find(id);
            if (secRole == null)
            {
                return HttpNotFound();
            }
            return View(secRole);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleName")] SecRole secRole)
        {
            if (ModelState.IsValid)
            {
                secRole.CreatedBy = 1;
                secRole.CreationDateTime=DateTime.Now;
                
                db.SecRoles.Add(secRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(secRole);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecRole secRole = db.SecRoles.Find(id);
            if (secRole == null)
            {
                return HttpNotFound();
            }
            return View(secRole);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleName,Status")] SecRole secRole)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = db.SecRoles.FirstOrDefault(r => r.Id == secRole.Id);
                    if (role != null)
                    {
                        role.RoleName = secRole.RoleName;
                        role.ModifiedBy = 1;
                        role.ModificationDateTime = DateTime.Now;
                        role.Status = secRole.Status;
                        db.Entry(role).State = EntityState.Modified;
                    }

                    //db.SecRoles.Attach(secRole);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", ex.Message);
                }
                return RedirectToAction("Index");
            }
            return View(secRole);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecRole secRole = db.SecRoles.Find(id);
            if (secRole == null)
            {
                return HttpNotFound();
            }
            return View(secRole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecRole secRole = db.SecRoles.Find(id);
            db.SecRoles.Remove(secRole);
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
