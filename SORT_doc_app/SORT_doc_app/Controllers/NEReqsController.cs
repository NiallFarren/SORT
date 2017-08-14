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
    public class NEReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: NEReqs
        public ActionResult Index()
        {
            var nEReqs = db.NEReqs.Include(n => n.Project);
            return View(nEReqs.ToList());
        }

        // GET: NEReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NEReqs nEReqs = db.NEReqs.Find(id);
            if (nEReqs == null)
            {
                return HttpNotFound();
            }
            return View(nEReqs);
        }

        // GET: NEReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: NEReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,NEYesNo,NEChangeContact,NEChangeDescription,NEChangeLocation,NEChangeIPInfo,NEChangeReasonResult,NEChangeSummary,NEServiceContact,NEServiceDescription,NEServiceLocation,NEServiceIPInfo,NEServiceResult,NEServiceSummary,NEAcqMigrDomain,NEAcqMigrDNS,NEAcqTunnels,NEAcqSummary,NENewConfirmConnectivity,NENewSummary,NEEnvironment,NEComments")] NEReqs nEReqs)
        {
            if (ModelState.IsValid)
            {
                db.NEReqs.Add(nEReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", nEReqs.ProjectID);
            return View(nEReqs);
        }

        // GET: NEReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NEReqs nEReqs = db.NEReqs.Find(id);
            if (nEReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", nEReqs.ProjectID);
            return View(nEReqs);
        }

        // POST: NEReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,NEYesNo,NEChangeContact,NEChangeDescription,NEChangeLocation,NEChangeIPInfo,NEChangeReasonResult,NEChangeSummary,NEServiceContact,NEServiceDescription,NEServiceLocation,NEServiceIPInfo,NEServiceResult,NEServiceSummary,NEAcqMigrDomain,NEAcqMigrDNS,NEAcqTunnels,NEAcqSummary,NENewConfirmConnectivity,NENewSummary,NEEnvironment,NEComments")] NEReqs nEReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nEReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(nEReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "NE Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", nEReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", nEReqs.ProjectID);
            return View(nEReqs);
        }

        // GET: NEReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NEReqs nEReqs = db.NEReqs.Find(id);
            if (nEReqs == null)
            {
                return HttpNotFound();
            }
            return View(nEReqs);
        }

        // POST: NEReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NEReqs nEReqs = db.NEReqs.Find(id);
            db.NEReqs.Remove(nEReqs);
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
