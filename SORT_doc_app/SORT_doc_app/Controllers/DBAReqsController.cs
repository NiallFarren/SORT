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
    public class DBAReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: DBAReqs
        public ActionResult Index()
        {
            var dBAReqs = db.DBAReqs.Include(d => d.Project);
            return View(dBAReqs.ToList());
        }

        // GET: DBAReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBAReqs dBAReqs = db.DBAReqs.Find(id);
            if (dBAReqs == null)
            {
                return HttpNotFound();
            }
            return View(dBAReqs);
        }

        // GET: DBAReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: DBAReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,DBAYesNo,DBAContacts,DBADbInstance,DBADbVersion,DBADbOS,DBAUserIDs,DBALinks,DBAFeatures,DBAAppTouchPoints,DBADbTouchPoints,DBAVolumeEstimates,DBAUserVolume,DBAArchPurging,DBAPools,DBACRUDMatrix,DBAPerformance,DBADBMSJobs,DBARollback,DBARollbackTest,DBABRProcess,DBABackupReqs,DBARecoveryReqs,DBARetentionReqs,DBAComments")] DBAReqs dBAReqs)
        {
            if (ModelState.IsValid)
            {
                db.DBAReqs.Add(dBAReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", dBAReqs.ProjectID);
            return View(dBAReqs);
        }

        // GET: DBAReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBAReqs dBAReqs = db.DBAReqs.Find(id);
            if (dBAReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", dBAReqs.ProjectID);
            return View(dBAReqs);
        }

        // POST: DBAReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,DBAYesNo,DBAContacts,DBADbInstance,DBADbVersion,DBADbOS,DBAUserIDs,DBALinks,DBAFeatures,DBAAppTouchPoints,DBADbTouchPoints,DBAVolumeEstimates,DBAUserVolume,DBAArchPurging,DBAPools,DBACRUDMatrix,DBAPerformance,DBADBMSJobs,DBARollback,DBARollbackTest,DBABRProcess,DBABackupReqs,DBARecoveryReqs,DBARetentionReqs,DBAComments")] DBAReqs dBAReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dBAReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(dBAReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "DBA Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", dBAReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", dBAReqs.ProjectID);
            return View(dBAReqs);
        }

        // GET: DBAReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBAReqs dBAReqs = db.DBAReqs.Find(id);
            if (dBAReqs == null)
            {
                return HttpNotFound();
            }
            return View(dBAReqs);
        }

        // POST: DBAReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBAReqs dBAReqs = db.DBAReqs.Find(id);
            db.DBAReqs.Remove(dBAReqs);
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
