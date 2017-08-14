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
    public class GISReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: GISReqs
        public ActionResult Index()
        {
            var gISReqs = db.GISReqs.Include(g => g.Project);
            return View(gISReqs.ToList());
        }

        // GET: GISReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GISReqs gISReqs = db.GISReqs.Find(id);
            if (gISReqs == null)
            {
                return HttpNotFound();
            }
            return View(gISReqs);
        }

        // GET: GISReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: GISReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,GISQAPersonnel,GISArchReview,GISSecInfra,GISVulnerabilityScan,GISEventTool,GISIntrusionDetect,GISHardening,GISAdditional,GISDataClassification,GISEncryption,GISProcess,GISAccess,GISSourceAssure,GISPenetration,GISComments")] GISReqs gISReqs)
        {
            if (ModelState.IsValid)
            {
                db.GISReqs.Add(gISReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", gISReqs.ProjectID);
            return View(gISReqs);
        }

        // GET: GISReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GISReqs gISReqs = db.GISReqs.Find(id);
            if (gISReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", gISReqs.ProjectID);
            return View(gISReqs);
        }

        // POST: GISReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,GISQAPersonnel,GISArchReview,GISSecInfra,GISVulnerabilityScan,GISEventTool,GISIntrusionDetect,GISHardening,GISAdditional,GISDataClassification,GISEncryption,GISProcess,GISAccess,GISSourceAssure,GISPenetration,GISComments")] GISReqs gISReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gISReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(gISReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "GIS Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", gISReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", gISReqs.ProjectID);
            return View(gISReqs);
        }

        // GET: GISReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GISReqs gISReqs = db.GISReqs.Find(id);
            if (gISReqs == null)
            {
                return HttpNotFound();
            }
            return View(gISReqs);
        }

        // POST: GISReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GISReqs gISReqs = db.GISReqs.Find(id);
            db.GISReqs.Remove(gISReqs);
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
