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
    public class SCVReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: SCVReqs
        public ActionResult Index()
        {
            var sCVReqs = db.SCVReqs.Include(s => s.Project);
            return View(sCVReqs.ToList());
        }

        // GET: SCVReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCVReqs sCVReqs = db.SCVReqs.Find(id);
            if (sCVReqs == null)
            {
                return HttpNotFound();
            }
            return View(sCVReqs);
        }

        // GET: SCVReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: SCVReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,SCVYesNo,SCVIpsCreds,SCVNetwork,SCVInventory,SCVSupport,SCVChangeControl,SCVSecurity,SCVSPOC,SCVCapacity,SCVForecast,SCVTraining,SCVComments")] SCVReqs sCVReqs)
        {
            if (ModelState.IsValid)
            {
                db.SCVReqs.Add(sCVReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", sCVReqs.ProjectID);
            return View(sCVReqs);
        }

        // GET: SCVReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCVReqs sCVReqs = db.SCVReqs.Find(id);
            if (sCVReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", sCVReqs.ProjectID);
            return View(sCVReqs);
        }

        // POST: SCVReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,SCVYesNo,SCVIpsCreds,SCVNetwork,SCVInventory,SCVSupport,SCVChangeControl,SCVSecurity,SCVSPOC,SCVCapacity,SCVForecast,SCVTraining,SCVComments")] SCVReqs sCVReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCVReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(sCVReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "SCV Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", sCVReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", sCVReqs.ProjectID);
            return View(sCVReqs);
        }

        // GET: SCVReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCVReqs sCVReqs = db.SCVReqs.Find(id);
            if (sCVReqs == null)
            {
                return HttpNotFound();
            }
            return View(sCVReqs);
        }

        // POST: SCVReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCVReqs sCVReqs = db.SCVReqs.Find(id);
            db.SCVReqs.Remove(sCVReqs);
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
