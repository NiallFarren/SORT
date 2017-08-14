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
    public class SMOReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: SMOReqs
        public ActionResult Index()
        {
            var sMOReqs = db.SMOReqs.Include(s => s.Project);
            return View(sMOReqs.ToList());
        }

        // GET: SMOReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMOReqs sMOReqs = db.SMOReqs.Find(id);
            if (sMOReqs == null)
            {
                return HttpNotFound();
            }
            return View(sMOReqs);
        }

        // GET: SMOReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: SMOReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,SMOContracts,SMOTemplates,SMODocuments,SMOBusinessContacts,SMOChangeManagement,SMOIncidentManagement,SMOUsage,SMOKPIsSLAs,SMOSLMReporting,SMOChReports,SMOIPMRdefined,SMOProgManagement,SMOChManagementTicketing,SMOKPIProbes,SMOComments")] SMOReqs sMOReqs)
        {
            if (ModelState.IsValid)
            {
                db.SMOReqs.Add(sMOReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", sMOReqs.ProjectID);
            return View(sMOReqs);
        }

        // GET: SMOReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMOReqs sMOReqs = db.SMOReqs.Find(id);
            if (sMOReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", sMOReqs.ProjectID);
            return View(sMOReqs);
        }

        // POST: SMOReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,SMOContracts,SMOTemplates,SMODocuments,SMOBusinessContacts,SMOChangeManagement,SMOIncidentManagement,SMOUsage,SMOKPIsSLAs,SMOSLMReporting,SMOChReports,SMOIPMRdefined,SMOProgManagement,SMOChManagementTicketing,SMOKPIProbes,SMOComments")] SMOReqs sMOReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMOReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(sMOReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "SMO Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", sMOReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", sMOReqs.ProjectID);
            return View(sMOReqs);
        }

        // GET: SMOReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMOReqs sMOReqs = db.SMOReqs.Find(id);
            if (sMOReqs == null)
            {
                return HttpNotFound();
            }
            return View(sMOReqs);
        }

        // POST: SMOReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMOReqs sMOReqs = db.SMOReqs.Find(id);
            db.SMOReqs.Remove(sMOReqs);
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
