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
    public class ITCSController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: ITCS
        public ActionResult Index()
        {
            var iTCS = db.ITCS.Include(i => i.Project);
            return View(iTCS.ToList());
        }

        // GET: ITCS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITCS iTCS = db.ITCS.Find(id);
            if (iTCS == null)
            {
                return HttpNotFound();
            }
            return View(iTCS);
        }

        // GET: ITCS/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: ITCS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,ITCSContacts,ITCSEmail,ITCSDomains,ITCSSoftware,ITCSBuying,ITCSOwner,ITCSEmailConfig,ITCSInventory,ITCSListing,ITCSComments")] ITCS iTCS)
        {
            if (ModelState.IsValid)
            {
                db.ITCS.Add(iTCS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", iTCS.ProjectID);
            return View(iTCS);
        }

        // GET: ITCS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITCS iTCS = db.ITCS.Find(id);
            if (iTCS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", iTCS.ProjectID);
            return View(iTCS);
        }

        // POST: ITCS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,ITCSContacts,ITCSEmail,ITCSDomains,ITCSSoftware,ITCSBuying,ITCSOwner,ITCSEmailConfig,ITCSInventory,ITCSListing,ITCSComments")] ITCS iTCS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTCS).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(iTCS.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "ITCS Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", iTCS);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", iTCS.ProjectID);
            return View(iTCS);
        }

        // GET: ITCS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITCS iTCS = db.ITCS.Find(id);
            if (iTCS == null)
            {
                return HttpNotFound();
            }
            return View(iTCS);
        }

        // POST: ITCS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITCS iTCS = db.ITCS.Find(id);
            db.ITCS.Remove(iTCS);
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
