﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarAppDBFirst;

namespace CarAppDBFirst.Controllers
{
    public class PointsController : Controller
    {
        private CarsContext db = new CarsContext();

        // GET: Points
        public ActionResult Index()
        {
            return View(db.Points.ToList());
        }

        // GET: Points/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Point point = db.Points.Find(id);
            if (point == null)
            {
                return HttpNotFound();
            }
            return View(point);
        }

        // GET: Points/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Points/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PointId,Name")] Point point)
        {
            if (ModelState.IsValid)
            {
                db.Points.Add(point);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(point);
        }

        // GET: Points/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Point point = db.Points.Find(id);
            if (point == null)
            {
                return HttpNotFound();
            }
            return View(point);
        }

        // POST: Points/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PointId,Name")] Point point)
        {
            if (ModelState.IsValid)
            {
                db.Entry(point).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(point);
        }

        // GET: Points/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Point point = db.Points.Find(id);
            if (point == null)
            {
                return HttpNotFound();
            }
            return View(point);
        }

        // POST: Points/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Point point = db.Points.Find(id);
            db.Points.Remove(point);
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
