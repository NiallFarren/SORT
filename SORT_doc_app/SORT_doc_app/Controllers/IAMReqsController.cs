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
    public class IAMReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: IAMReqs
        public ActionResult Index()
        {
            var iAMReqs = db.IAMReqs.Include(i => i.Project);
            return View(iAMReqs.ToList());
        }

        // GET: IAMReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IAMReqs iAMReqs = db.IAMReqs.Find(id);
            if (iAMReqs == null)
            {
                return HttpNotFound();
            }
            return View(iAMReqs);
        }

        // GET: IAMReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: IAMReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,IAMContacts,IAMTraining,IAMSummary,IAMApproval,IAMUserAccess,IAMUrls,IAMPassword,IAMAccLockout,IAMOLA,IAMPermission,IAMComments")] IAMReqs iAMReqs)
        {
            if (ModelState.IsValid)
            {
                db.IAMReqs.Add(iAMReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", iAMReqs.ProjectID);
            return View(iAMReqs);
        }

        // GET: IAMReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IAMReqs iAMReqs = db.IAMReqs.Find(id);
            if (iAMReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", iAMReqs.ProjectID);
            return View(iAMReqs);
        }

        // POST: IAMReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,IAMContacts,IAMTraining,IAMSummary,IAMApproval,IAMUserAccess,IAMUrls,IAMPassword,IAMAccLockout,IAMOLA,IAMPermission,IAMComments")] IAMReqs iAMReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iAMReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(iAMReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "IAM Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", iAMReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", iAMReqs.ProjectID);
            return View(iAMReqs);
        }

        // GET: IAMReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IAMReqs iAMReqs = db.IAMReqs.Find(id);
            if (iAMReqs == null)
            {
                return HttpNotFound();
            }
            return View(iAMReqs);
        }

        // POST: IAMReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IAMReqs iAMReqs = db.IAMReqs.Find(id);
            db.IAMReqs.Remove(iAMReqs);
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
