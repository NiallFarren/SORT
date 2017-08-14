using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SORT_doc_app.Context;
using SORT_doc_app.Models;
using Microsoft.AspNet.Identity;

namespace SORT_doc_app.Controllers
{
    public class ChangeManagementReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: ChangeManagementReqs
        public ActionResult Index()
        {
            var changeManagementReqs = db.ChangeManagementReqs.Include(c => c.Project);
            return View(changeManagementReqs.ToList());
        }

        // GET: ChangeManagementReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeManagementReqs changeManagementReqs = db.ChangeManagementReqs.Find(id);
            if (changeManagementReqs == null)
            {
                return HttpNotFound();
            }
            return View(changeManagementReqs);
        }

        // GET: ChangeManagementReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: ChangeManagementReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,ChCustomerClarity,ChCMReqs,ChReleases,ChComments")] ChangeManagementReqs changeManagementReqs)
        {
            if (ModelState.IsValid)
            {
                db.ChangeManagementReqs.Add(changeManagementReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", changeManagementReqs.ProjectID);
            return View(changeManagementReqs);
        }

        // GET: ChangeManagementReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeManagementReqs changeManagementReqs = db.ChangeManagementReqs.Find(id);
            if (changeManagementReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", changeManagementReqs.ProjectID);
            return View(changeManagementReqs);
        }

        // POST: ChangeManagementReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,ChCustomerClarity,ChCMReqs,ChReleases,ChComments")] ChangeManagementReqs changeManagementReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(changeManagementReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(changeManagementReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "Change Management Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", changeManagementReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", changeManagementReqs.ProjectID);
            return View(changeManagementReqs);
        }

        // GET: ChangeManagementReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeManagementReqs changeManagementReqs = db.ChangeManagementReqs.Find(id);
            if (changeManagementReqs == null)
            {
                return HttpNotFound();
            }
            return View(changeManagementReqs);
        }

        // POST: ChangeManagementReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChangeManagementReqs changeManagementReqs = db.ChangeManagementReqs.Find(id);
            db.ChangeManagementReqs.Remove(changeManagementReqs);
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
