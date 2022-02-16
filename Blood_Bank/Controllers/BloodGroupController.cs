using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blood_Bank.Models;

namespace Blood_Bank.Controllers
{
    [Authorize]
    public class BloodGroupController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: BloodGroup
        public ActionResult Index()
        {
            return View(db.Blood_group.ToList());
        }

        // GET: BloodGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_group blood_group = db.Blood_group.Find(id);
            if (blood_group == null)
            {
                return HttpNotFound();
            }
            return View(blood_group);
        }

        // GET: BloodGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "blood_group_id,blood_group_name")] Blood_group blood_group)
        {
            if (ModelState.IsValid)
            {
                db.Blood_group.Add(blood_group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blood_group);
        }

        // GET: BloodGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_group blood_group = db.Blood_group.Find(id);
            if (blood_group == null)
            {
                return HttpNotFound();
            }
            return View(blood_group);
        }

        // POST: BloodGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "blood_group_id,blood_group_name")] Blood_group blood_group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blood_group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blood_group);
        }

        // GET: BloodGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_group blood_group = db.Blood_group.Find(id);
            if (blood_group == null)
            {
                return HttpNotFound();
            }
            return View(blood_group);
        }

        // POST: BloodGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blood_group blood_group = db.Blood_group.Find(id);
            db.Blood_group.Remove(blood_group);
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
