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
    public class QAReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: QAReqs
        public ActionResult Index()
        {
            var qAReqs = db.QAReqs.Include(q => q.Project);
            return View(qAReqs.ToList());
        }

        // GET: QAReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QAReqs qAReqs = db.QAReqs.Find(id);
            if (qAReqs == null)
            {
                return HttpNotFound();
            }
            return View(qAReqs);
        }

        // GET: QAReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: QAReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,QAContacts,QATeam,QAFramework,QASmokeTest,QALocation,QAHandestsSIMs,QAIssues,QAJira,QAPlan,Comments")] QAReqs qAReqs)
        {
            if (ModelState.IsValid)
            {
                db.QAReqs.Add(qAReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", qAReqs.ProjectID);
            return View(qAReqs);
        }

        // GET: QAReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QAReqs qAReqs = db.QAReqs.Find(id);
            if (qAReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", qAReqs.ProjectID);
            return View(qAReqs);
        }

        // POST: QAReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,QAContacts,QATeam,QAFramework,QASmokeTest,QALocation,QAHandestsSIMs,QAIssues,QAJira,QAPlan,Comments")] QAReqs qAReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qAReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(qAReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "QA & Test Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", qAReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", qAReqs.ProjectID);
            return View(qAReqs);
        }

        // GET: QAReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QAReqs qAReqs = db.QAReqs.Find(id);
            if (qAReqs == null)
            {
                return HttpNotFound();
            }
            return View(qAReqs);
        }

        // POST: QAReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QAReqs qAReqs = db.QAReqs.Find(id);
            db.QAReqs.Remove(qAReqs);
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
