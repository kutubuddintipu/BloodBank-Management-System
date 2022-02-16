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
    public class InstituteStockController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: InstituteStock
        public ActionResult Index()
        {
            var institute_Blood_Bank_stock = db.Institute_Blood_Bank_stock.Include(i => i.Blood_group).Include(i => i.rel_institute_city);
            return View(institute_Blood_Bank_stock.ToList());
        }

        // GET: InstituteStock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute_Blood_Bank_stock institute_Blood_Bank_stock = db.Institute_Blood_Bank_stock.Find(id);
            if (institute_Blood_Bank_stock == null)
            {
                return HttpNotFound();
            }
            return View(institute_Blood_Bank_stock);
        }

        // GET: InstituteStock/Create
        public ActionResult Create()
        {
            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name");
            ViewBag.rel_institute_city_id = new SelectList(db.rel_institute_city, "rel_institute_city_id", "inst_branch_name");
            return View();
        }

        // POST: InstituteStock/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stock_id,rel_institute_city_id,blood_group_id,blood_bag_qty")] Institute_Blood_Bank_stock institute_Blood_Bank_stock)
        {
            if (ModelState.IsValid)
            {
                db.Institute_Blood_Bank_stock.Add(institute_Blood_Bank_stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", institute_Blood_Bank_stock.blood_group_id);
            ViewBag.rel_institute_city_id = new SelectList(db.rel_institute_city, "rel_institute_city_id", "inst_branch_name", institute_Blood_Bank_stock.rel_institute_city_id);
            return View(institute_Blood_Bank_stock);
        }

        // GET: InstituteStock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute_Blood_Bank_stock institute_Blood_Bank_stock = db.Institute_Blood_Bank_stock.Find(id);
            if (institute_Blood_Bank_stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", institute_Blood_Bank_stock.blood_group_id);
            ViewBag.rel_institute_city_id = new SelectList(db.rel_institute_city, "rel_institute_city_id", "inst_branch_name", institute_Blood_Bank_stock.rel_institute_city_id);
            return View(institute_Blood_Bank_stock);
        }

        // POST: InstituteStock/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stock_id,rel_institute_city_id,blood_group_id,blood_bag_qty")] Institute_Blood_Bank_stock institute_Blood_Bank_stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institute_Blood_Bank_stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.blood_group_id = new SelectList(db.Blood_group, "blood_group_id", "blood_group_name", institute_Blood_Bank_stock.blood_group_id);
            ViewBag.rel_institute_city_id = new SelectList(db.rel_institute_city, "rel_institute_city_id", "inst_branch_name", institute_Blood_Bank_stock.rel_institute_city_id);
            return View(institute_Blood_Bank_stock);
        }

        // GET: InstituteStock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute_Blood_Bank_stock institute_Blood_Bank_stock = db.Institute_Blood_Bank_stock.Find(id);
            if (institute_Blood_Bank_stock == null)
            {
                return HttpNotFound();
            }
            return View(institute_Blood_Bank_stock);
        }

        // POST: InstituteStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Institute_Blood_Bank_stock institute_Blood_Bank_stock = db.Institute_Blood_Bank_stock.Find(id);
            db.Institute_Blood_Bank_stock.Remove(institute_Blood_Bank_stock);
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
