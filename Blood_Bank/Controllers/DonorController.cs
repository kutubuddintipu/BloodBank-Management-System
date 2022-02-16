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
    public class DonorController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: Donor
        public ActionResult Index()
        {
            var donors = db.Donors.Include(d => d.Blood_group).Include(d => d.City);
            return View(donors.ToList());
        }

        // GET: Donor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // GET: Donor/Create
        public ActionResult Create()
        {
            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name");
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name");
            return View();
        }

        // POST: Donor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "donor_id,donor_reg_no,city_id,donor_name,donor_mobile,donor_birth_day,last_donate_date,donation_count,blood_group_id,address,sex")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(donor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", donor.blood_group_id);
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", donor.city_id);
            return View(donor);
        }

        // GET: Donor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", donor.blood_group_id);
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", donor.city_id);
            return View(donor);
        }

        // POST: Donor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "donor_id,donor_reg_no,city_id,donor_name,donor_mobile,donor_birth_day,last_donate_date,donation_count,blood_group_id,address,sex")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", donor.blood_group_id);
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", donor.city_id);
            return View(donor);
        }

        // GET: Donor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Donor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor donor = db.Donors.Find(id);
            db.Donors.Remove(donor);
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
