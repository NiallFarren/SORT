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
    public class AppsSupportReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: AppsSupportReqs
        public ActionResult Index()
        {
            var appsSupportReqs = db.AppsSupportReqs.Include(a => a.Project);
            return View(appsSupportReqs.ToList());
        }

        // GET: AppsSupportReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppsSupportReqs appsSupportReqs = db.AppsSupportReqs.Find(id);
            if (appsSupportReqs == null)
            {
                return HttpNotFound();
            }
            return View(appsSupportReqs);
        }

        // GET: AppsSupportReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: AppsSupportReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,SupContacts,SupAccountsAccess,SupToolsA,SupToolsB,SupToolsC,SupToolsD,SupDemoTraining,SupContactsProvided,SupCustContact,SupComments")] AppsSupportReqs appsSupportReqs)
        {
            if (ModelState.IsValid)
            {
                db.AppsSupportReqs.Add(appsSupportReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", appsSupportReqs.ProjectID);
            return View(appsSupportReqs);
        }

        // GET: AppsSupportReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppsSupportReqs appsSupportReqs = db.AppsSupportReqs.Find(id);
            if (appsSupportReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", appsSupportReqs.ProjectID);
            return View(appsSupportReqs);
        }

        // POST: AppsSupportReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,SupContacts,SupAccountsAccess,SupToolsA,SupToolsB,SupToolsC,SupToolsD,SupDemoTraining,SupContactsProvided,SupCustContact,SupComments")] AppsSupportReqs appsSupportReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appsSupportReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(appsSupportReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody =  "Apps Support Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", appsSupportReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", appsSupportReqs.ProjectID);
            return View(appsSupportReqs);
        }

        // GET: AppsSupportReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppsSupportReqs appsSupportReqs = db.AppsSupportReqs.Find(id);
            if (appsSupportReqs == null)
            {
                return HttpNotFound();
            }
            return View(appsSupportReqs);
        }

        // POST: AppsSupportReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppsSupportReqs appsSupportReqs = db.AppsSupportReqs.Find(id);
            db.AppsSupportReqs.Remove(appsSupportReqs);
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
