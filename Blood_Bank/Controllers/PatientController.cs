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
    public class PatientController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: Patient
        public ActionResult Index()
        {
            var patients = db.patients.Include(p => p.Blood_group);
            return View(patients.ToList());
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name");
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "patient_id,patient_name,patient_mbl,patient_birth_day,patient_address,blood_group_id,sex,photo")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", patient.blood_group_id);
            return View(patient);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", patient.blood_group_id);
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "patient_id,patient_name,patient_mbl,patient_birth_day,patient_address,blood_group_id,sex,photo")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", patient.blood_group_id);
            return View(patient);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            patient patient = db.patients.Find(id);
            db.patients.Remove(patient);
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
