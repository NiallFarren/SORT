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
    public class SignOffsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: SignOffs
        public ActionResult Index()
        {
            var signOffs = db.SignOffs.Include(s => s.Project);
            return View(signOffs.ToList());
        }

        // GET: SignOffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignOff signOff = db.SignOffs.Find(id);
            if (signOff == null)
            {
                return HttpNotFound();
            }
            return View(signOff);
        }

        // GET: SignOffs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: SignOffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,SignOffDate,SignOffPM,SignOffSRE,SignOffGIS,SignOffEOC,SignOffSupport,SignOffCCT,SignOffSDM")] SignOff signOff)
        {
            if (ModelState.IsValid)
            {
                db.SignOffs.Add(signOff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", signOff.ProjectID);
            return View(signOff);
        }

        // GET: SignOffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignOff signOff = db.SignOffs.Find(id);
            if (signOff == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", signOff.ProjectID);
            return View(signOff);
        }

        // POST: SignOffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,SignOffDate,SignOffPM,SignOffSRE,SignOffGIS,SignOffEOC,SignOffSupport,SignOffCCT,SignOffSDM")] SignOff signOff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signOff).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(signOff.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "Sign Off Post Warranty Phase section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", signOff);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", signOff.ProjectID);
            return View(signOff);
        }

        // GET: SignOffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignOff signOff = db.SignOffs.Find(id);
            if (signOff == null)
            {
                return HttpNotFound();
            }
            return View(signOff);
        }

        // POST: SignOffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SignOff signOff = db.SignOffs.Find(id);
            db.SignOffs.Remove(signOff);
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
