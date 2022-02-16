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
    public class BloodRequestController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: BloodRequest
        public ActionResult Index()
        {
            var bloodRequests = db.BloodRequests.Include(b => b.Blood_group);
            return View(bloodRequests.ToList());
        }

        // GET: BloodRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodRequest bloodRequest = db.BloodRequests.Find(id);
            if (bloodRequest == null)
            {
                return HttpNotFound();
            }
            return View(bloodRequest);
        }

        // GET: BloodRequest/Create
        public ActionResult Create()
        {
            ViewBag.BloodGroup = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name");
            return View();
        }

        // POST: BloodRequest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientName,Age,Reason,BloodGroup,Unit,Gender")] BloodRequest bloodRequest)
        {
            if (ModelState.IsValid)
            {
                db.BloodRequests.Add(bloodRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodGroup = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", bloodRequest.BloodGroup);
            return View(bloodRequest);
        }

        // GET: BloodRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodRequest bloodRequest = db.BloodRequests.Find(id);
            if (bloodRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroup = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", bloodRequest.BloodGroup);
            return View(bloodRequest);
        }

        // POST: BloodRequest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientName,Age,Reason,BloodGroup,Unit,Gender")] BloodRequest bloodRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodGroup = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", bloodRequest.BloodGroup);
            return View(bloodRequest);
        }

        // GET: BloodRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodRequest bloodRequest = db.BloodRequests.Find(id);
            if (bloodRequest == null)
            {
                return HttpNotFound();
            }
            return View(bloodRequest);
        }

        // POST: BloodRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodRequest bloodRequest = db.BloodRequests.Find(id);
            db.BloodRequests.Remove(bloodRequest);
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
