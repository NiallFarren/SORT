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
    public class SummariesController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: Summaries
        public ActionResult Index()
        {
            var summaries = db.Summaries.Include(s => s.Project);
            return View(summaries.ToList());
        }

        // GET: Summaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summaries.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            return View(summary);
        }

        // GET: Summaries/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: Summaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,ServiceName,Description,ProductName,ServiceDelivery,CostCentre,ProjectManagers,PCISOX,GoLiveDate,ArchLeadTeams,SupportTeams,SummaryComments")] Summary summary)
        {
            if (ModelState.IsValid)
            {
                db.Summaries.Add(summary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", summary.ProjectID);
            return View(summary);
        }

        // GET: Summaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summaries.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", summary.ProjectID);
            return View(summary);
        }

        // POST: Summaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,ServiceName,Description,ProductName,ServiceDelivery,CostCentre,ProjectManagers,PCISOX,GoLiveDate,ArchLeadTeams,SupportTeams,SummaryComments")] Summary summary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(summary).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(summary.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "Service / Environment Summary Overview section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Details", summary);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", summary.ProjectID);
            return View(summary);
        }

        // GET: Summaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summaries.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            return View(summary);
        }

        // POST: Summaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Summary summary = db.Summaries.Find(id);
            db.Summaries.Remove(summary);
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
