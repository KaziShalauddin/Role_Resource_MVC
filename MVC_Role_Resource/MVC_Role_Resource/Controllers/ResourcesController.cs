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
    public class ResourcesController : Controller
    {
        private RoleResourceDBContext db = new RoleResourceDBContext();

        // GET: Resources
        public ActionResult Index()
        {
            return View(db.SecResources.ToList());
        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecResource secResource = db.SecResources.Find(id);
            if (secResource == null)
            {
                return HttpNotFound();
            }
            return View(secResource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FileName,MenuName,DisplayName,ModuleId,Order,Level,ActionUrl,Status")] SecResource secResource)
        {
            if (ModelState.IsValid)
            {
                secResource.CreatedBy = 1;
                secResource.CreationDateTime = DateTime.Now;
                db.SecResources.Add(secResource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(secResource);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecResource secResource = db.SecResources.Find(id);
            if (secResource == null)
            {
                return HttpNotFound();
            }
            return View(secResource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,MenuName,DisplayName,ModuleId,Order,Level,ActionUrl,Status")] SecResource secResource)
        {
            if (ModelState.IsValid)
            {
                var resource = db.SecResources.FirstOrDefault(r => r.Id == secResource.Id);
                if (resource != null)
                {
                    resource.ModifiedBy = 2;
                    resource.ModificationDateTime = DateTime.Now;
                    resource.FileName = secResource.FileName;
                    resource.MenuName = secResource.MenuName;
                    resource.DisplayName = secResource.DisplayName;
                    resource.ModuleId = secResource.ModuleId;
                    resource.Order = secResource.Order;
                    resource.Level = secResource.Level;
                    resource.ActionUrl = secResource.ActionUrl;
                    resource.Status = secResource.Status;
                    db.Entry(resource).State = EntityState.Modified;
                    db.SaveChanges();
                }

               
               
                return RedirectToAction("Index");
            }
            return View(secResource);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecResource secResource = db.SecResources.Find(id);
            if (secResource == null)
            {
                return HttpNotFound();
            }
            return View(secResource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecResource secResource = db.SecResources.Find(id);
            db.SecResources.Remove(secResource);
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
