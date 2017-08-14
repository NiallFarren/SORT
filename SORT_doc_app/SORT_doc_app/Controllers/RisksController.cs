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
    public class RisksController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: Risks
        public ActionResult Index()
        {
            var risks = db.Risks.Include(r => r.Project);
            return View(risks.ToList());
        }

        // GET: Risks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risks risks = db.Risks.Find(id);
            if (risks == null)
            {
                return HttpNotFound();
            }
            return View(risks);
        }

        // GET: Risks/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: Risks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,RisksPrePlan,RisksPreAccept,RisksPreOwner,RisksPreDate,RisksWarrantyPlan,RisksWarrantyAccept,RisksWarrantyOwner,RisksWarrantyDate,RisksComments")] Risks risks)
        {
            if (ModelState.IsValid)
            {
                db.Risks.Add(risks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", risks.ProjectID);
            return View(risks);
        }

        // GET: Risks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risks risks = db.Risks.Find(id);
            if (risks == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", risks.ProjectID);
            return View(risks);
        }

        // POST: Risks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,RisksPrePlan,RisksPreAccept,RisksPreOwner,RisksPreDate,RisksWarrantyPlan,RisksWarrantyAccept,RisksWarrantyOwner,RisksWarrantyDate,RisksComments")] Risks risks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(risks).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(risks.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "Risks Identified section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", risks);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", risks.ProjectID);
            return View(risks);
        }

        // GET: Risks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risks risks = db.Risks.Find(id);
            if (risks == null)
            {
                return HttpNotFound();
            }
            return View(risks);
        }

        // POST: Risks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Risks risks = db.Risks.Find(id);
            db.Risks.Remove(risks);
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
