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
    public class InstitueCityController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: InstitueCity
        public ActionResult Index()
        {
            var rel_institute_city = db.rel_institute_city.Include(r => r.City);
            return View(rel_institute_city.ToList());
        }

        // GET: InstitueCity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_institute_city rel_institute_city = db.rel_institute_city.Find(id);
            if (rel_institute_city == null)
            {
                return HttpNotFound();
            }
            return View(rel_institute_city);
        }

        // GET: InstitueCity/Create
        public ActionResult Create()
        {
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name");
            return View();
        }

        // POST: InstitueCity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rel_institute_city_id,inst_id,city_id,inst_branch_code,inst_branch_name,inst_branch_contact_no,inst_branch_emergency_no,inst_branch_manager,inst_branch_manager_no,inst_branch_address")] rel_institute_city rel_institute_city)
        {
            if (ModelState.IsValid)
            {
                db.rel_institute_city.Add(rel_institute_city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", rel_institute_city.city_id);
            return View(rel_institute_city);
        }

        // GET: InstitueCity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_institute_city rel_institute_city = db.rel_institute_city.Find(id);
            if (rel_institute_city == null)
            {
                return HttpNotFound();
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", rel_institute_city.city_id);
            return View(rel_institute_city);
        }

        // POST: InstitueCity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rel_institute_city_id,inst_id,city_id,inst_branch_code,inst_branch_name,inst_branch_contact_no,inst_branch_emergency_no,inst_branch_manager,inst_branch_manager_no,inst_branch_address")] rel_institute_city rel_institute_city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rel_institute_city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", rel_institute_city.city_id);
            return View(rel_institute_city);
        }

        // GET: InstitueCity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_institute_city rel_institute_city = db.rel_institute_city.Find(id);
            if (rel_institute_city == null)
            {
                return HttpNotFound();
            }
            return View(rel_institute_city);
        }

        // POST: InstitueCity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rel_institute_city rel_institute_city = db.rel_institute_city.Find(id);
            db.rel_institute_city.Remove(rel_institute_city);
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
