﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
            //var userWithRoles = (from users in db.SecUsers
            //               join userRoles in db.SecUserRoles on users.Id equals userRoles.SecUserId
            //               select new
            //               {
            //                   users.Id,
            //                   users.LogInName,
            //                   users.Email,
            //                   users.Password,
            //                   users.CreatedBy,
            //                   users.CreationDateTime,
            //                   users.ModifiedBy,
            //                   users.ModificationDateTime,
            //                   users.Status,
            //                   userRoles.SecRoleId,
            //               }).ToList();
            //var userWithRoles = (from users in db.SecUsers
            //    join userRoles in db.SecUserRoles on users.Id equals userRoles.SecUserId into ur
            //                     from userRoles in ur.DefaultIfEmpty()
            //                     join roles in db.SecRoles on userRoles.Id equals roles.Id
            //                     select new
            //    {
            //        users.Id,
            //        users.LogInName,
            //        users.Email,
            //        users.Password,
            //        users.CreatedBy,
            //        users.CreationDateTime,
            //        users.ModifiedBy,
            //        users.ModificationDateTime,
            //        users.Status,
            //       Role= userRoles.SecRoleId  ? null:"Not Assigned"
            //    }).ToList();
            //List<UserVM> userVMs = new List<UserVM>();
            //using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RoleResourceConnection"].ConnectionString))
            //{

            //    connection.Open();
            //    using (SqlCommand command =new SqlCommand(@"Exec GetUserWithRoles",connection))
            //    {

            //        SqlDataReader reader = command.ExecuteReader();

            //        var userWithRoles = reader.Cast<IDataRecord>()
            //            .Select(x => new
            //            {
            //                //Id = (int)x["Id"],
            //                Id = (int)x["Id"],
            //                LogInName = (string)x["LogInName"],
            //                Email = (string)x["Email"],
            //                Status = (bool)x["Status"],
            //            }).ToList();
            //        connection.Close();

            //        foreach (var item in userWithRoles)
            //        {
            //            var user = new UserVM
            //            {
            //                Id = item.Id,
            //                LogInName = item.LogInName,
            //                Email = item.Email,
            //                //Password = item.Password,
            //                //CreatedBy = item.CreatedBy,
            //                //CreationDateTime = item.CreationDateTime,
            //                //ModifiedBy = item.ModifiedBy,
            //                //ModificationDateTime = item.ModificationDateTime,
            //                Status = item.Status

            //            };

            //            //if (item.SecRoleId != 0)
            //            //{
            //            //    user.Role = db.SecRoles.FirstOrDefault(i => i.Id == item.SecRoleId);
            //            //}
            //            //else
            //            //{
            //            //    user.RoleId = 0;
            //            //}



            //            userVMs.Add(user);
            //        }

            //    }
            //}

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
            SecUserRole userRole = db.SecUserRoles.FirstOrDefault(r => r.SecUserId == user.Id);
            var userVm = new UserVM
            {

                Id = user.Id,
                LogInName = user.LogInName,
                Email = user.Email,
                Password = user.Password,
                CreatedBy = user.CreatedBy,
                CreationDateTime = user.CreationDateTime,
                ModifiedBy = user.ModifiedBy,
                ModificationDateTime = user.ModificationDateTime,
                Status = user.Status,
               // Role = db.SecRoles.FirstOrDefault(i => i.Id == userRole.SecRoleId)
                Role = db.SecRoles.FirstOrDefault(i => i.Id == user.RoleId)
            };
            return View(userVm);
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
                SecUserRole userRole = new SecUserRole();
                userRole.SecUserId = db.SecUsers.Max(i => i.Id);
                userRole.SecRoleId = (int)userVM.RoleId;
                userRole.CreatedBy = 1;
                userRole.CreationDateTime = DateTime.Now;
                db.SecUserRoles.Add(userRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.SecRoles, "Id", "RoleName", userVM.RoleId);
            return View(userVM);
        }
        public ActionResult CreateWithoutRole()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWithoutRole([Bind(Include = "LogInName,Password,Email,Status")] SecUser userVM)
        {
            if (ModelState.IsValid)
            {
                userVM.CreatedBy = 1;
                userVM.CreationDateTime = DateTime.Now;
                db.SecUsers.Add(userVM);
                db.SaveChanges();
                //SecUserRole userRole = new SecUserRole();
                //userRole.SecUserId = db.SecUsers.Max(i => i.Id);
                //userRole.SecRoleId = userVM.RoleId;
                //userRole.CreatedBy = 1;
                //userRole.CreationDateTime = DateTime.Now;
                //db.SecUserRoles.Add(userRole);
                //db.SaveChanges();
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
                var userRole = db.SecUserRoles.FirstOrDefault(r => r.SecUserId == userVM.Id);
                if (user != null)
                {
                    user.ModifiedBy = 2;
                    user.ModificationDateTime = DateTime.Now;
                    user.Status = userVM.Status;
                    user.LogInName = userVM.LogInName;
                    user.Password = userVM.Password;
                    user.Email = userVM.Email;

                    user.RoleId = userVM.RoleId;

                    userRole.SecRoleId = (int)userVM.RoleId;
                    db.Entry(user).State = EntityState.Modified;
                    db.Entry(userRole).State = EntityState.Modified;

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.SecRoles, "Id", "RoleName", userVM.RoleId);
            return View(userVM);
        }
        public ActionResult AssignRole(int? id)
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
        public ActionResult AssignRole([Bind(Include = "Id,RoleId")] SecUser userVM)
        {
            if (ModelState.IsValid)
            {
                var user = db.SecUsers.FirstOrDefault(r => r.Id == userVM.Id);
                if (user != null)
                {
                    //user.ModifiedBy = 2;
                    //user.ModificationDateTime = DateTime.Now;
                    //user.Status = userVM.Status;
                    //user.LogInName = userVM.LogInName;
                    //user.Password = userVM.Password;
                    //user.Email = userVM.Email;
                    //userRole.SecRoleId = userVM.RoleId;
                    //db.Entry(user).State = EntityState.Modified;
                    //db.Entry(userRole).State = EntityState.Modified;

                    //SecUserRole userRole = new SecUserRole();
                    //userRole.SecUserId = user.Id;
                    //userRole.SecRoleId = (int)userVM.RoleId;
                    //userRole.CreatedBy = 1;
                    //userRole.CreationDateTime = DateTime.Now;
                    //db.SecUserRoles.Add(userRole);
                    user.RoleId = userVM.RoleId;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

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
