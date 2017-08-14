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
    public class EOCReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: EOCReqs
        public ActionResult Index()
        {
            var eOCReqs = db.EOCReqs.Include(e => e.Project);
            return View(eOCReqs.ToList());
        }

        // GET: EOCReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EOCReqs eOCReqs = db.EOCReqs.Find(id);
            if (eOCReqs == null)
            {
                return HttpNotFound();
            }
            return View(eOCReqs);
        }

        // GET: EOCReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: EOCReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,EOCContacts,EOCLocation,EOCPOCs,EOCDocsAndDemo,EOCProcessFlows,EOCMonitoring,EOCSignOff,EOCCustomers,EOCSevEmail,EOCCrisis,EOCProcess,EOCExceptions,EOCComments")] EOCReqs eOCReqs)
        {
            if (ModelState.IsValid)
            {
                db.EOCReqs.Add(eOCReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", eOCReqs.ProjectID);
            return View(eOCReqs);
        }

        // GET: EOCReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EOCReqs eOCReqs = db.EOCReqs.Find(id);
            if (eOCReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", eOCReqs.ProjectID);
            return View(eOCReqs);
        }

        // POST: EOCReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,EOCContacts,EOCLocation,EOCPOCs,EOCDocsAndDemo,EOCProcessFlows,EOCMonitoring,EOCSignOff,EOCCustomers,EOCSevEmail,EOCCrisis,EOCProcess,EOCExceptions,EOCComments")] EOCReqs eOCReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eOCReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(eOCReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "EOC Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", eOCReqs.ProjectID);
            return View(eOCReqs);
        }

        // GET: EOCReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EOCReqs eOCReqs = db.EOCReqs.Find(id);
            if (eOCReqs == null)
            {
                return HttpNotFound();
            }
            return View(eOCReqs);
        }

        // POST: EOCReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EOCReqs eOCReqs = db.EOCReqs.Find(id);
            db.EOCReqs.Remove(eOCReqs);
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
